namespace TargetProcess2Exchange

open TargetProcess2Exchange.Domain
open Serilog
open System
open System.Net

/// Documentation for my library
///
/// ## Example
///
///     let h = Library.hello {"John";"Rambo"}
///     printfn "%s" h
///
module Library = 
  
    open Microsoft.Exchange.WebServices.Data

    let load =
      let credentials = NetworkCredential(Secret.TargetProcessUserName, Secret.TargetProcessPassword)
      let client = new WebClient()
      client.Credentials <- credentials
      let content = client.DownloadString( Secret.TargetProcessUrl + "/api/v1/UserStories/" )
      Domain.UserStories.Parse(content)

    let private getService () =
        let service = new ExchangeService()
        service.EnableScpLookup <- true 
        
        service.Credentials <- 
            new WebCredentials(
                Secret.ExchangeUserEmail, 
                Secret.ExchangePassword
            )

        service.AutodiscoverUrl(Secret.ExchangeUserEmail, (fun _ -> true))
        service

    let private getTasksFolder service =
        Folder.Bind(service, WellKnownFolderName.Tasks)

    let getTasks =
        let service = getService ()
        let folder = getTasksFolder service
        let view = new ItemView(1000)
        let folderItems = folder.FindItems(view)
        folderItems 
        //|> Seq.map toTask
        //|> Seq.toArray
