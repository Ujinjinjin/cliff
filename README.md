# Readme

## About

Cliff is a lightweight framework for cli application development based on `System.CommandLine` standard library.

## Getting started

### Installation

To add Cliff to the existing project use:

```shell
dotnet add package Cliff
```

### New project

To start a new `cliff` project, first you need to install a template:

```shell
dotnet new -i Cliff.Template
```

then you need to create a new project:

```shell
dotnet new cliff -n <project-name>
```

to validate that project was created successfully, run:

```shell
$ dotnet run --project <project-name>/<project-name>.csproj --version

1.0.0
```

```shell
$ dotnet run --project <project-name>/<project-name>.csproj display -t 15

Temperature: 15°
The weather is perfect! Enjoy your day :)
```

### Project structure

Lets look at an empty `CliApp` project folder tree:

```shell
CliApp/
├── Controllers
│   └── WeatherController.cs
├── Infrastructure
│   └── IocModule.cs
├── Services
│   ├── IWeatherService.cs
│   └── WeatherService.cs
├── Program.cs
└── CliApp.csproj
```

**_Controllers_** - define cli commands and their signature\
**_IocModule_** - dependency injection container where all classes must be registered\
**_Services_** - services used by the application

For more info take a look at: https://github.com/Ujinjinjin/cliff/tree/main/Cliff.Playground

## Examples

See https://github.com/Ujinjinjin/cliff/tree/main/Cliff.Playground
