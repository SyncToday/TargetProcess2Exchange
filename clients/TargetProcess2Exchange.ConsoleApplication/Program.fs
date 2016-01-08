open TargetProcess2Exchange
open TargetProcess2Exchange.Domain
open Serilog
open System.Runtime.Serialization.Formatters.Binary
open System.IO
open System

[<EntryPoint>]
let main argv = 
    Log.Logger <- LoggerConfiguration()
        .Destructure.FSharpTypes()
        .WriteTo.Console()
        .CreateLogger()
    Log.Information( "Console application started" )

    printfn "%A" argv
    0 // return an integer exit code
