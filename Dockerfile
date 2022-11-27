FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 5000

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src

COPY ["SolarPhage.Api/SolarPhage.Api.fsproj", "SolarPhage.Api/"]
COPY ["nuget.config", ""]

RUN dotnet restore "SolarPhage.Api/SolarPhage.Api.fsproj"

WORKDIR $HOME/src
COPY . .
RUN dotnet build "SolarPhage.Api/SolarPhage.Api.fsproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "SolarPhage.Api/SolarPhage.Api.fsproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "SolarPhage.Api.dll"]