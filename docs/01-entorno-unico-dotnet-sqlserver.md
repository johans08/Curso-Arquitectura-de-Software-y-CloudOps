# Entorno único: .NET + SQL Server

## Objetivo

Configurar un entorno sencillo y coherente para todo el módulo.

---

## Herramientas necesarias

### Obligatorias

1. .NET SDK 10 o superior.
2. SQL Server Express LocalDB o SQL Server Developer Edition.
3. Visual Studio o Visual Studio Code.

### Recomendadas

- Visual Studio con carga de trabajo ASP.NET and web development.
- SQL Server Object Explorer incluido en Visual Studio.
- Git.

---

## Por qué SQL Server LocalDB

SQL Server LocalDB permite trabajar con SQL Server de forma liviana en ambientes de desarrollo. No requiere administrar un servicio completo como en SQL Server Developer Edition y es suficiente para practicar:

- Tablas.
- Relaciones.
- Índices.
- Transacciones.
- Constraints.
- Stored procedures básicos.
- JSON en SQL Server.
- Consultas T-SQL.
- Entity Framework Core.

---

## Cadena de conexión base

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=(localdb)\\MSSQLLocalDB;Database=ArchitectureAcademyDb;Trusted_Connection=True;TrustServerCertificate=True"
  }
}
```

---

## Comandos .NET útiles

```powershell
dotnet --info
dotnet new webapi -n ArchitectureAcademy.Api
dotnet new blazor -n ArchitectureAcademy.Frontend
dotnet build
dotnet run
dotnet test
```

Para EF Core:

```powershell
dotnet tool install --global dotnet-ef
dotnet ef migrations add InitialCreate
dotnet ef database update
```

---

## Decisión del módulo

No se utilizarán herramientas externas para mensajería, frontend o cloud durante este módulo.

| Necesidad | Solución del módulo |
|---|---|
| Frontend | Blazor |
| API | ASP.NET Core |
| Persistencia | SQL Server |
| ORM | EF Core |
| Mensajería | Outbox en SQL Server |
| Jobs internos | BackgroundService |
| Tiempo real | SignalR opcional |
| NoSQL | Conceptual + JSON en SQL Server |
