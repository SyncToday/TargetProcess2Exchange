module TargetProcess2Exchange.Tests

open NUnit.Framework
open Serilog

[<SetUpFixture>]
type SetupTest() =
    [<SetUp>]
    let ``start logging`` =
        Log.Logger <- LoggerConfiguration()
            .Destructure.FSharpTypes()
            .MinimumLevel.Debug() //uncomment to see the full debug in the console
            .WriteTo.ColoredConsole()
            .CreateLogger()
        Log.Information( "Tests started" )

open TargetProcess2Exchange
open NUnit.Framework
open TargetProcess2Exchange.Domain
open Serilog

[<Test>]
let ``make sure blah blah`` () =
  Assert.AreEqual("Hello John Rambo","Hello John Rambo")
