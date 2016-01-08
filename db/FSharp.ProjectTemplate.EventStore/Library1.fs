﻿namespace FSharp.ProjectTemplate.EventStore

module internal Utilities = 

    open Logary
    open EventStore.ClientAPI

    let lm : (Logary.LogManager option ref) = ref None

(** 
    let withConnection factory f =
      factory <| fun _ ->
        let conn =
          let logger, internalLogger =
            (!lm).Value.GetLogger("EventStore"),
            (!lm).Value.GetLogger("EventStore.Internal")
          ConnectionSettings.configureStart()
          |> ConnectionSettings.useCustomLogger (EventStoreAdapter(logger, internalLogger))
          |> ConnectionSettings.configureEnd (IPEndPoint(IPAddress.Loopback, 1113))
        conn |> Conn.connect |> Async.RunSynchronously
        try f conn
        finally conn |> Conn.close
**)