# --- Base runtime ---
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS base
WORKDIR /app
EXPOSE 8080

# --- Build stage ---
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /app

COPY ServiceTemplate.sln ./
COPY src/ ./src
COPY tests/ ./tests

RUN dotnet restore ServiceTemplate.sln

RUN dotnet publish src/ServiceTemplate.Web/ServiceTemplate.Web.csproj -c Release -o /app/publish

# --- Runtime stage ---
FROM base AS final
WORKDIR /app

COPY --from=build /app/publish .

ENTRYPOINT ["dotnet", "ServiceTemplate.Web.dll"]
