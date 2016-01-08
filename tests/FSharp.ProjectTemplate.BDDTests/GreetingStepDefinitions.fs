module GreetingStepDefinitions

open TickSpec
open NUnit.Framework
      
let [<When>] ``I meet (.*)`` (someone:string) =  
    ()
      
let [<Then>] ``I say (.*)`` (greeting:string) =     
     Assert.True("Hello John Doe" = greeting)
