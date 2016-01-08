#r "System.Xml.Linq.dll"
#r """..\..\packages\FSharp.Data\lib\net40\FSharp.Data.DesignTime.dll"""
#r """..\..\packages\FSharp.Data\lib\net40\FSharp.Data.dll"""
#r """..\..\packages\Serilog\lib\net45\Serilog.dll"""
#r """..\..\packages\EWS-Api-2.0\lib\net35\Microsoft.Exchange.WebServices.dll"""

#load "Secret.fs"
#load "DomainTypes.fs"
#load "Library.fs"


let stories = TargetProcess2Exchange.Library.load 
//printfn "%A" stories
stories.UserStories |> Seq.iter (fun t -> printfn "%A-%A\n%A" t.Id t.Name t.Description )
let tasks = TargetProcess2Exchange.Library.getTasks
tasks |> Seq.iter ( fun t -> printfn "%A" t.Subject )
