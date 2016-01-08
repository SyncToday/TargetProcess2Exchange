namespace FSharp.ProjectTemplate.Backend

open FSharp.Data

module Client =
    let hello firstName lastName =
        Http.RequestString( 
            "http://localhost:8083/api/FSharp.ProjectTemplate.Suave.Program+GreeterSQL/http_test/Greet", 
            httpMethod = "POST", headers = [ "Content-Type", "orleankka/vnd.actor+json" ], body = TextRequest (sprintf """{ "FirstName" : "%s", "LastName" : "%s"  }""" firstName lastName)
        )


