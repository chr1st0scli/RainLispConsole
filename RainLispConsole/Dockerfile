#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# This is the original dockerfile produced by VS.

#FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
#WORKDIR /app
#
#FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
#WORKDIR /src
#COPY ["RainLispConsole/RainLispConsole.csproj", "RainLispConsole/"]
#RUN dotnet restore "RainLispConsole/RainLispConsole.csproj"
#COPY . .
#WORKDIR "/src/RainLispConsole"
#RUN dotnet build "RainLispConsole.csproj" -c Release -o /app/build
#
#FROM build AS publish
#RUN dotnet publish "RainLispConsole.csproj" -c Release -o /app/publish /p:UseAppHost=false
#
#FROM base AS final
#WORKDIR /app
#COPY --from=publish /app/publish .
#ENTRYPOINT ["dotnet", "RainLispConsole.dll"]


# Modifications to support the terminal gui library (editor mode) in docker.
FROM mcr.microsoft.com/dotnet/runtime:6.0-alpine3.16-amd64 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0-alpine3.16-amd64 AS build
WORKDIR /src
COPY ["RainLispConsole/RainLispConsole.csproj", "RainLispConsole/"]
RUN dotnet restore "RainLispConsole/RainLispConsole.csproj"
COPY . .
WORKDIR "/src/RainLispConsole"
RUN dotnet build "RainLispConsole.csproj" -c Release -o /app/build

FROM build AS publish
# Added the "-r linux-musl-x64 --no-self-contained" part. --no-self-contained is needed because this application is published as a tool package.
RUN dotnet publish "RainLispConsole.csproj" -c Release -r linux-musl-x64 --no-self-contained -o /app/publish /p:UseAppHost=false

FROM base AS final
# Install needed libraries to launch terminal gui without exceptions.
RUN apk upgrade --no-cache && apk add --no-cache libgcc libstdc++ icu-libs ncurses bash
WORKDIR /app
COPY --from=publish /app/publish .
# Without this environment variable, only a black screen appears in terminal gui.
ENV TERM=xterm-256color
ENTRYPOINT ["dotnet", "RainLispConsole.dll"]