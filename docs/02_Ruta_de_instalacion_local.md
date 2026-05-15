# Ruta de instalación local

## Herramientas principales

Para los primeros dos meses se prioriza un entorno simple:

- .NET SDK 8 o superior.
- SQL Server Developer, Express o LocalDB.
- Git.
- Editor de código.
- Cuenta GitHub.

## Validación rápida

```powershell
dotnet --version
git --version
```

Para SQL Server LocalDB en Windows:

```powershell
sqllocaldb info
sqllocaldb start MSSQLLocalDB
```

## Cadena de conexión sugerida

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=(localdb)\MSSQLLocalDB;Database=CloudOpsCourseDb;Trusted_Connection=True;TrustServerCertificate=True"
  }
}
```

## Principio del entorno

El entorno debe ser lo más sencillo posible al inicio. El estudiante debe concentrarse primero en comprender arquitectura, separación de responsabilidades, persistencia, seguridad y APIs. Las herramientas de nube y automatización aparecen progresivamente cuando el fundamento de software ya está claro.
