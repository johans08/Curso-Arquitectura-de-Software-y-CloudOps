# Código base del módulo

Este directorio contiene una referencia base para el módulo. No pretende ser una aplicación final completa, sino una estructura reusable para estudiar arquitectura con .NET y SQL Server.

## Proyectos

```text
src/
├── ArchitectureAcademy.Api/
├── ArchitectureAcademy.Frontend/
├── ArchitectureAcademy.SharedKernel/
└── Database/
```

## Responsabilidad de cada proyecto

| Proyecto | Responsabilidad |
|---|---|
| ArchitectureAcademy.Api | Endpoints HTTP, JWT, OpenAPI, integración con servicios |
| ArchitectureAcademy.Frontend | UI Blazor |
| ArchitectureAcademy.SharedKernel | Abstracciones compartidas, Result, Entity, DomainEvent |
| Database | Scripts SQL Server de referencia |

## Ejecución sugerida

```powershell
cd src
dotnet build
dotnet run --project .\ArchitectureAcademy.Api
dotnet run --project .\ArchitectureAcademy.Frontend
```

## Base de datos

La cadena de conexión por defecto usa SQL Server LocalDB:

```text
Server=(localdb)\MSSQLLocalDB;Database=ArchitectureAcademyDb;Trusted_Connection=True;TrustServerCertificate=True
```
