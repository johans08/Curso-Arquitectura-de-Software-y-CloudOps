# ReferenceArchitecture

Aplicación de referencia del curso.

## Stack

- ASP.NET Core Web API.
- Blazor Web App.
- Entity Framework Core.
- SQL Server o LocalDB.
- JWT Bearer.
- Outbox Pattern con SQL Server.

## Estructura

```text
ReferenceArchitecture
├── CloudOps.Domain
├── CloudOps.Application
├── CloudOps.Infrastructure
├── CloudOps.Api
└── CloudOps.Web
```

## Creación de solución sugerida

```powershell
dotnet new sln -n CloudOps.ReferenceArchitecture

dotnet new classlib -n CloudOps.Domain -o CloudOps.Domain
dotnet new classlib -n CloudOps.Application -o CloudOps.Application
dotnet new classlib -n CloudOps.Infrastructure -o CloudOps.Infrastructure
dotnet new webapi -n CloudOps.Api -o CloudOps.Api
dotnet new blazor -n CloudOps.Web -o CloudOps.Web

dotnet sln add .\CloudOps.Domain\CloudOps.Domain.csproj
dotnet sln add .\CloudOps.Application\CloudOps.Application.csproj
dotnet sln add .\CloudOps.Infrastructure\CloudOps.Infrastructure.csproj
dotnet sln add .\CloudOps.Api\CloudOps.Api.csproj
dotnet sln add .\CloudOps.Web\CloudOps.Web.csproj
```

## Nota

Los archivos incluidos son plantillas académicas. El estudiante puede copiarlos sobre proyectos creados con `dotnet new` para mantener compatibilidad con su versión local de SDK.
