namespace FSharp.ProjectTemplate.Suave

#if !MONO

module Program =

    open System

    open Suave
    open Suave.Web
    open Suave.Http
    open Suave.Http.Successful
    open Suave.Http.Writers
    open Suave.Http.RequestErrors
    open Suave.Http.Applicatives
    open Suave.Types
    open Suave.Utils

    open Orleankka
    open Orleankka.Http
    open Orleankka.Playground

    open System.Reflection
    open Newtonsoft.Json

    open FSharp.ProjectTemplate.Actors

    open Serilog
    open Orleans.Serialization

    open FSharp.ProjectTemplate.Domain

    open Support

    let db = DI.Load<FSharp.ProjectTemplate.IHelloPersistency> ()
    //let db = DI.Register<FSharp.ProjectTemplate.NMemory.Impl.Database, FSharp.ProjectTemplate.IHelloPersistency> ()

    type GreeterSQL() = 
        inherit Greeter()

        override x.SaveLastHello (p : Person) = 
            db.Save(p)
        override x.LoadLastHello (p : Person) = 
            db.Load(p)

    [<EntryPoint>]
    let main argv = 
      Log.Logger <- LoggerConfiguration()
            .Destructure.FSharpTypes()
            .WriteTo.Console()
            .CreateLogger()
      Log.Information( "Web server started" )

      let assemblies:Assembly [] = [| Assembly.GetExecutingAssembly();(typeof<Greeter>).Assembly |]

      // configure actor system
      use system = ActorSystem.Configure()
                              .Playground()
                              .Register(assemblies)
                              .Done()
  
      let testActor = system.ActorOf<GreeterSQL>("http_test")

      Log.Debug( "Actor path {@ActorPath}", testActor.Path )
      printfn "%A" testActor.Path

      // configure actor routing
      let router = [(MessageType.DU(typeof<HelloMessage>), testActor.Path)]
                    |> Seq.collect HttpRoute.create
                    |> ActorRouter.create JsonConvert.DeserializeObject


      let hasContentType (ctx:HttpContext) = async {
        printfn "ctx.request.header 'content-type' %A" (ctx.request.header "content-type")

        match ctx.request.header "content-type" with
        | Choice1Of2 v when v.Contains( ContentType.Orleankka ) -> 
               return Some ctx
        | _ -> return None
      }    

      let setCORSHeaders = 
        setHeader  "Access-Control-Allow-Origin" "*" 
        >>= setHeader "Access-Control-Allow-Headers" "content-type"

      // sends msg to actor 
      let sendMsg actorPath (ctx:HttpContext) = async {    
    
        let msgBody = ctx.request.rawForm |> UTF8.toString
        printfn "msgBody %A" msgBody
        
        match router.Dispatch(actorPath, msgBody) with
        | Some t -> let! result = Async.AwaitTask t
                    printfn "result %A" (result.ToString())
                    printfn "----------------------------------"
                    return! 
                        ctx |> (
                            setCORSHeaders
                            >>=  OK (result.ToString()) 
                        )
        | None   -> return! BAD_REQUEST "actor was not found, or message has invalid format" ctx  
      }  

        let allow_cors : WebPart =
                choose [
                    OPTIONS >>= 
                        fun context -> 
                            context |> ( 
                                setCORSHeaders
                                >>=  OK "CORS approved")
            ]

      // configure Suave routing
      let app = 
        choose [
            allow_cors
            POST >>= hasContentType >>= pathScan "/api/%s" (fun path -> request (fun req ctx -> 
                sendMsg path ctx))  
        ]

      printfn "Finished booting cluster...\n"

      startWebServer defaultConfig app
      0 

#endif