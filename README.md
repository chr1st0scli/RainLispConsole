# RainLisp Console

[![nuget](https://img.shields.io/nuget/vpre/RainLispConsole?color=blue)](https://www.nuget.org/packages/RainLispConsole/)
[![docker](https://img.shields.io/docker/v/chr1st0scli/rainlispconsole?label=docker%20version)](https://hub.docker.com/r/chr1st0scli/rainlispconsole)
[![License](https://img.shields.io/github/license/chr1st0scli/rainlispconsole)](LICENSE.txt)

![RainLisp Console](RainLispConsole/Images/RainLisp-Colored-128x128.png)

![RainLisp Console Demo](RainLispConsole/Images/RainLispConsole.gif)

RainLisp Console allows you to run the programs you write in [RainLisp](https://github.com/chr1st0scli/RainLisp).

It can be used in three ways:

- In REPL mode (Read-Evaluate-Print Loop) that allows you to evaluate code incrementally.
- As a code editor with syntax highlighting, basic code completion, source code file management and code evaluation.
- As a tool with command line arguments that allows the interpreter to be used with other editors or tools.

## Installation
You need to have .NET 6 or later installed.

In order to download RainLispConsole from NuGet and install it as a global tool, run the following command in a command line shell.
```
dotnet tool install -g RainLispConsole
```

If you already have it installed and you want to update it, run the following command.
```
dotnet tool update -g RainLispConsole
```

## Usage
Run the following command.
```
RainLispConsole
```
If needed, you can then choose the *Help* mode to see more information.

## Docker Installation & Usage
Alternatively, if you have docker installed and don't want to install RainLisp Console in your system as a tool,
you can run it inside a docker container.

Run the following command to download the latest docker image.
```
docker pull chr1st0scli/rainlispconsole
```

To run it, execute the following command.
```
docker run -it chr1st0scli/rainlispconsole
```

In order to get started with RainLisp, you can visit its [repository](https://github.com/chr1st0scli/RainLisp), where you can find
a [tutorial](https://github.com/chr1st0scli/RainLisp/blob/master/RainLisp/Docs/quick-start.md) and other material.
