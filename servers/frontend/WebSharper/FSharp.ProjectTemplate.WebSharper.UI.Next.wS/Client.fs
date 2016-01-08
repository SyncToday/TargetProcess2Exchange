namespace FSharp.ProjectTemplate.WebSharper.UI.Next.wS

open WebSharper
open WebSharper.JavaScript
open WebSharper.UI.Next
open WebSharper.UI.Next.Client
open WebSharper.UI.Next.Html

[<JavaScript>]
module Client =

    // Var cannot be used on a record so we need to create our own Var-ed type
    type Person =
        {
            FirstName : Var<string>
            LastName : Var<string>
        }

    let createPerson first last =
        { FirstName = Var.Create first ; LastName = Var.Create last }

    let Main () =
        let rvFirstName = Var.Create "First name"
        let rvLastName = Var.Create "Last name"
        let viewFullName = View.Map2 ( fun f l -> createPerson f l ) rvFirstName.View rvLastName.View
        let submit = Submitter.CreateOption viewFullName
        let vReversed =
            submit.View.MapAsync(function
                | None -> async { return "" }
                | Some input -> Server.DoSomething input.FirstName.Value input.LastName.Value
            )
        div [
            Doc.Input [] rvFirstName
            Doc.Input [] rvLastName
            Doc.Button "Send" [] submit.Trigger
            hr []
            h4Attr [attr.``class`` "text-muted"] [text "The server responded:"]
            divAttr [attr.``class`` "jumbotron"] [h1 [textView vReversed]]
        ]
