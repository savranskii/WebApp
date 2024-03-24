# Web application on .NET 8 and Blazor

## Navigate to Infrastructure folder
cd .\WebApp.Infrastructure

## Add migration
dotnet ef migrations add Initial --startup-project ..\WebApp.Api --context WebApp.Infrastructure.Contexts.ApplicationDbContext -o Migrations

## Apply migrations
dotnet ef database update --startup-project ..\WebApp.Api --context WebApp.Infrastructure.Contexts.ApplicationDbContext
