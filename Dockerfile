FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY ExerciceApi.sln .
COPY ExerciceApi/ExerciceApi.csproj ExerciceApi/
COPY ExerciceApi.Tests/ExerciceApi.Tests.csproj ExerciceApi.Tests/
RUN dotnet restore

COPY . .
RUN dotnet publish ExerciceApi -c Release --no-restore -o /app/publish

WORKDIR /app
COPY --from=build /app/publish .
EXPOSE 80
ENTRYPOINT ["dotnet", "ExerciceApi.dll"]