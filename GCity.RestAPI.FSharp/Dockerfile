#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["GCity.RestAPI.FSharp/GCity.RestAPI.FSharp.fsproj", "GCity.RestAPI.FSharp/"]
RUN dotnet restore "GCity.RestAPI.FSharp/GCity.RestAPI.FSharp.fsproj"
COPY . .
WORKDIR "/src/GCity.RestAPI.FSharp"
RUN dotnet build "GCity.RestAPI.FSharp.fsproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "GCity.RestAPI.FSharp.fsproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GCity.RestAPI.FSharp.dll"]