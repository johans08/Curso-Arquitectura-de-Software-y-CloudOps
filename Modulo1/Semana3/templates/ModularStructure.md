# Estructura sugerida de monolito modular

```text
ArchitectureAcademy.Api/
├── Features/
│   ├── Courses/
│   │   ├── Course.cs
│   │   ├── CourseDtos.cs
│   │   ├── CourseEndpoints.cs
│   │   └── CourseConfiguration.cs
│   ├── Students/
│   ├── Enrollments/
│   └── Notifications/
├── Data/
└── Security/
```

## Regla

Un módulo no debe acceder directamente a detalles internos de otro módulo.  
Debe comunicarse mediante casos de uso, eventos internos o contratos explícitos.
