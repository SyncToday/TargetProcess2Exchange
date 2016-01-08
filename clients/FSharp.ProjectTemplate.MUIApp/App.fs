#if MONO
let main argv = 
  ()
#else
open System
open FsXaml

type App = XAML<"App.xaml">

[<STAThread>]
[<EntryPoint>]
let main argv = 
    App().Root.Run()
#endif
