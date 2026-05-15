# Arquitectura de referencia del módulo

## Vista general

```mermaid
flowchart TB
    subgraph Presentation
        BLAZOR[Blazor Web App]
    end

    subgraph API
        ENDPOINTS[Controllers / Minimal APIs]
        AUTH[JWT Auth]
        OPENAPI[OpenAPI Docs]
    end

    subgraph Application
        USECASES[Use Cases]
        DTO[DTOs]
        VALIDATION[Validation]
    end

    subgraph Domain
        ENTITIES[Entities]
        VALUEOBJECTS[Value Objects]
        RULES[Business Rules]
        EVENTS[Domain Events]
    end

    subgraph Infrastructure
        EF[EF Core]
        OUTBOX[Outbox Processor]
        EMAIL[Notification Adapter]
    end

    SQL[(SQL Server)]

    BLAZOR --> ENDPOINTS
    ENDPOINTS --> AUTH
    ENDPOINTS --> USECASES
    USECASES --> DOMAIN
    DOMAIN --> EVENTS
    USECASES --> EF
    EF --> SQL
    OUTBOX --> SQL
    OUTBOX --> EMAIL
```

---

## Principios de diseño

### 1. La interfaz no debe conocer la base de datos

Blazor debe consumir la API o servicios de aplicación.  
No debe construir SQL ni depender de EF Core directamente en una arquitectura separada.

### 2. La API no debe contener lógica de negocio compleja

La API debe:

- Recibir requests.
- Validar estructura básica.
- Autenticar.
- Autorizar.
- Delegar casos de uso.
- Responder con contratos claros.

### 3. La lógica importante vive en Application y Domain

La capa de aplicación coordina operaciones.  
El dominio protege reglas que no deben romperse.

### 4. SQL Server debe proteger integridad

Una base profesional no depende solo del código. Debe tener:

- Llaves primarias.
- Llaves foráneas.
- Índices.
- Constraints.
- Tipos adecuados.
- Campos de auditoría.
- Estrategia de migraciones.

---

## Flujo típico de un caso de uso

```mermaid
sequenceDiagram
    participant U as Usuario
    participant UI as Blazor
    participant API as ASP.NET Core API
    participant APP as Application Service
    participant DB as SQL Server
    participant OB as Outbox

    U->>UI: Completa formulario
    UI->>API: POST /api/enrollments
    API->>API: Autentica y valida contrato
    API->>APP: Execute command
    APP->>DB: Guarda matrícula
    APP->>DB: Registra evento en Outbox
    API-->>UI: 201 Created
    OB->>DB: Lee eventos pendientes
    OB->>OB: Procesa notificación
```

---

## Decisiones importantes

| Decisión | Razón |
|---|---|
| Usar SQL Server como motor principal | Reduce complejidad y fortalece modelado relacional |
| Usar Blazor como frontend | Mantiene todo el stack en .NET |
| Usar Outbox con SQL Server | Enseña mensajería sin introducir RabbitMQ/Kafka |
| Usar JWT | Permite entender APIs stateless |
| Usar OpenAPI | Formaliza contratos de integración |
| Usar ADRs | Enseña documentación de decisiones reales |
