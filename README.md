[![Issue Stats](http://issuestats.com/github/NaseUkolyCZ/ProjectScaffoldWithApps/badge/issue)](http://issuestats.com/github/NaseUkolyCZ/ProjectScaffoldWithApps)
[![Issue Stats](http://issuestats.com/github/NaseUkolyCZ/ProjectScaffoldWithApps/badge/pr)](http://issuestats.com/github/NaseUkolyCZ/ProjectScaffoldWithApps)

# ProjectScaffoldWithApps

This project is adding just a few projects to famous [ProjectScaffold](http://fsprojects.github.io/ProjectScaffold). 
It can be used to scaffold a prototypical .NET solution including file system layout, tooling and applications. This includes a build process that: 

* updates all AssemblyInfo files
* compiles the application and runs all test projects
* generates [SourceLinks](https://github.com/ctaggart/SourceLink)
* generates API docs based on XML document tags
* generates [documentation based on Markdown files](http://fsprojects.github.io/ProjectScaffold/writing-docs.html)
* generates [NuGet](http://www.nuget.org) packages
* and allows a simple [one step release process](http://fsprojects.github.io/ProjectScaffold/release-process.html).
* have application prototypes for different technologies

In order to start the scaffolding process run 

    > build.cmd // on windows    
    $ ./build.sh  // on unix
    
Read the [Getting started tutorial](http://fsprojects.github.io/ProjectScaffold/index.html#Getting-started) to learn more.

Documentation: http://fsprojects.github.io/ProjectScaffold

## Solution Structure
![Solution Structure](https://raw.githubusercontent.com/NaseUkolyCZ/ProjectScaffoldWithApps/master/docs/FSharp.ProjectTemplate%20Structure.png)

## Build Status

Mono | .NET
---- | ----
[![Mono CI Build Status](https://img.shields.io/travis/NaseUkolyCZ/ProjectScaffoldWithApps/master.svg)](https://travis-ci.org/NaseUkolyCZ/ProjectScaffoldWithApps) | [![.NET Build Status](https://img.shields.io/appveyor/ci/davidpodhola/ProjectScaffoldWithApps/master.svg)](https://ci.appveyor.com/project/davidpodhola/ProjectScaffoldWithApps)

## Maintainer(s) of [ProjectScaffold](http://fsprojects.github.io/ProjectScaffold) are

- [@forki](https://github.com/forki)
- [@pblasucci](https://github.com/pblasucci)
- [@sergey-tihon](https://github.com/sergey-tihon)

The default maintainer account for projects under "fsprojects" is [@fsprojectsgit](https://github.com/fsprojectsgit) - F# Community Project Incubation Space (repo management)
This project is maintained by [@davidpodhola](https://github.com/davidpodhola)
