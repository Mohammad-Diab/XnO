# XnO

A small X and O (tic-tac-toe) game for two players on the same PC. Written in C# with WPF on .NET Framework 4.0.

## Features

- Players take turns clicking the squares of a 3 by 3 board; X and O are drawn as images.
- Detects a win on any row, column or diagonal, and a draw when the board is full, then starts a new round.
- Keeps the score of each player until you reset it.
- **New Game** clears the board; **Rest** clears the board and the score.

## Requirements

Windows with .NET Framework 4.0 or later. Windows 8, 10 and 11 already include it.

## Usage

Download `XnO-v1.0.0.7z` from [Releases](https://github.com/Mohammad-Diab/XnO/releases), extract it, and run `XnO.exe`. There is no installer.

The exe is not signed, so Windows SmartScreen may warn the first time you run it: click **More info**, then **Run anyway**.

## Building

```
git clone https://github.com/Mohammad-Diab/XnO.git
```

Open `XnO.sln` in Visual Studio and build, or run:

```
MSBuild XnO.sln /p:Configuration=Release
```

The exe is written to `XnO\bin\Release`.

The project targets .NET Framework 4.0. Recent Visual Studio versions don't ship its reference assemblies; if the build stops with `MSB3644`, extract the [Microsoft.NETFramework.ReferenceAssemblies.net40](https://www.nuget.org/packages/Microsoft.NETFramework.ReferenceAssemblies.net40) NuGet package and point MSBuild at its `build` folder:

```
MSBuild XnO.sln /p:Configuration=Release /p:TargetFrameworkRootPath=<package>\build
```

## Windows 8 version

The `App15` folder holds a separate version of the game written as a Windows 8 Store app (C# and XAML, Arabic interface). It is not part of the Release. Building it needs Visual Studio 2012 or 2013 with the Windows 8.0 SDK, and a test certificate of your own: open `Package.appxmanifest`, go to **Packaging** and use **Choose Certificate** to create one.

## Author

Mohammad Diab

## License

[Apache 2.0](LICENSE)
