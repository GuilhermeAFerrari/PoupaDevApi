# PoupaDev - Jornada .NET Direto ao Ponto

Development of a complete financial objective management REST API.

## Technologies and practices
- ASP.NET Core with .NET 6
- Entity Framework Core
- SQL Server
- Swagger
- Dependency injection
- OOP
- Hosted Services

## Features
- Registration, Listing, Financial Purpose Details
- Withdrawal and Deposit of Financial Purpose
- Automatic Yield

## Tool Entity Framework Core (migrations)
```
dotnet tool install --global dotnet-ef
```

## Migrations
```
dotnet ef migrations add InitialMigration -o Persistence/Migrations
dotnet ef database update
```