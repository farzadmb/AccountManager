#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["AccountManager.WebApi/AccountManager.WebApi.csproj", "AccountManager.WebApi/"]
COPY ["AccountManager.Application/AccountManager.Application.csproj", "AccountManager.Application/"]
COPY ["AccountManager.Data/AccountManager.Data.csproj", "AccountManager.Data/"]

RUN dotnet restore "AccountManager.WebApi/AccountManager.WebApi.csproj"

COPY . .

WORKDIR "/src/AccountManager.Data"
RUN dotnet build "AccountManager.Data.csproj" -c Release -o /app/build

WORKDIR "/src/AccountManager.Application"
RUN dotnet build "AccountManager.Application.csproj" -c Release -o /app/build

WORKDIR "/src/AccountManager.WebApi"
RUN dotnet build "AccountManager.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AccountManager.WebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AccountManager.WebApi.dll"]