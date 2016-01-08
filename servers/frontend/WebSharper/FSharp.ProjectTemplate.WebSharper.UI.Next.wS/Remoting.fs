namespace FSharp.ProjectTemplate.WebSharper.UI.Next.wS

open WebSharper
open FSharp.ProjectTemplate.Backend

module Server =

    [<Rpc>]
    let DoSomething firstName lastName =        
        async {
            return Client.hello firstName lastName
        }
