#r "System.Xml.Linq.dll"
#r """..\..\packages\FSharp.Data\lib\net40\FSharp.Data.DesignTime.dll"""
#r """..\..\packages\FSharp.Data\lib\net40\FSharp.Data.dll"""
#r """..\..\packages\Serilog\lib\net45\Serilog.dll"""

#load "Secret.fs"
#load "DomainTypes.fs"
#load "Library.fs"


let stories = TargetProcess2Exchange.Library.load 
printfn "%A" stories
