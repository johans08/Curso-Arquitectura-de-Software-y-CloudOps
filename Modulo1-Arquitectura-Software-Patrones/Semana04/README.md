# Semana 4: Diseño y documentación de APIs profesionales con Swagger/OpenAPI

**Módulo:** 1  
**Bloque:** Diseño de Componentes y Limpieza de Código  
**Duración sincrónica:** 1h30  
**Carga total sugerida:** 7.5 horas semanales  
**Producto de la semana:** evidencia técnica en GitHub.

---

## 1. Resultado de aprendizaje

Al finalizar la semana, el estudiante será capaz de:

- Diseñar APIs con contratos claros.
- Documentar endpoints con OpenAPI/Swagger.
- Aplicar convenciones de status codes, errores y versionado.

---

## 2. Contexto profesional


Una API profesional es un contrato entre equipos y sistemas. No basta con exponer endpoints funcionales: se deben definir recursos, nombres, códigos HTTP, modelos de error, autenticación, paginación, filtros, versionado y documentación interactiva.

OpenAPI permite describir el contrato de una API de forma estándar. Swagger UI facilita la exploración, pero la meta principal es que el contrato sea comprensible, testeable y estable. En ASP.NET Core se puede generar documentación OpenAPI y enriquecerla con metadatos, ejemplos, respuestas esperadas y seguridad.


---

## 3. Conceptos clave

- **REST**
- **OpenAPI**
- **DTO**
- **ProblemDetails**
- **Versionado**
- **Paginación**

---

## 4. Mapa visual del tema

```mermaid
sequenceDiagram
    participant Client
    participant API
    participant Service
    participant DB as SQL Server
    Client->>API: POST /api/orders
    API->>API: Validar DTO
    API->>Service: Crear orden
    Service->>DB: Guardar orden
    DB-->>Service: Id generado
    Service-->>API: Resultado
    API-->>Client: 201 Created + Location

```

---

## 5. Explicación detallada

### 5.1 Problema que resuelve el tema

En un entorno profesional, el valor de este tema aparece cuando el sistema necesita crecer sin perder control. El crecimiento puede ser técnico, como más tráfico, más módulos o más integraciones; o puede ser organizacional, como más personas modificando el código al mismo tiempo. Sin criterios de arquitectura, cada cambio aumenta el riesgo de romper funcionalidades existentes.

### 5.2 Decisión arquitectónica principal

La decisión central de esta semana consiste en identificar qué parte del sistema debe permanecer simple y qué parte necesita una estructura más formal. Una solución profesional no es la que usa más herramientas, sino la que reduce incertidumbre, facilita mantenimiento y permite operar el sistema con seguridad.

### 5.3 Señales de una mala implementación

- El código funciona, pero nadie puede explicar por qué está organizado de esa forma.
- Las responsabilidades están mezcladas entre interfaz, lógica, datos y seguridad.
- Los errores se ocultan o se manejan con respuestas genéricas.
- No existe documentación para ejecutar, probar o revisar la solución.
- La solución depende de pasos manuales que no están escritos.

### 5.4 Buenas prácticas esperadas

- Documentar las decisiones en el README.
- Mantener nombres claros y consistentes.
- Evitar secretos en código fuente.
- Usar Git con commits pequeños y descriptivos.
- Separar configuración por ambiente.
- Probar al menos el flujo principal.

---

## 6. Práctica técnica sugerida

Documentar la API de órdenes con OpenAPI, agregar ProblemDetails, respuestas 400/404/201 y ejemplos de DTOs.

### Evidencia mínima de práctica

El estudiante debe incluir en su repositorio:

```text
/semana-04
├── README.md
├── src/
├── diagrams/
└── evidencias/
```

El README de la práctica debe explicar:

- Qué problema se resolvió.
- Cómo se diseñó la solución.
- Qué decisiones se tomaron.
- Cómo se ejecuta.
- Qué se aprendió.

---

## 7. Tarea semanal desde cero

Diseñar una API de inventario con documentación completa, versionado simple y README explicando decisiones de contrato.

### Criterios de aceptación

- Repositorio en GitHub con historial de commits.
- README técnico con diagrama Mermaid o imagen exportada.
- Código o documento ejecutable/revisable según la naturaleza de la semana.
- Evidencia de pruebas, ejecución, diseño o análisis.
- Enlace compartido en Classroom mientras se habilita el sistema propio.

---

## 8. Preguntas de repaso

1. ¿Qué problema real resuelve el tema de esta semana?
2. ¿Qué riesgo aparece si se aplica incorrectamente?
3. ¿Qué alternativa más simple existe?
4. ¿Qué indicador usaría para saber si la solución funciona bien?
5. ¿Cómo explicaría esta decisión a un líder técnico o arquitecto?

---

## 9. Recursos adicionales

- https://learn.microsoft.com/aspnet/core/fundamentals/openapi/aspnetcore-openapi
- https://learn.microsoft.com/aspnet/core/
- https://learn.microsoft.com/aspnet/core/web-api/handle-errors

---

## 10. Checklist de cierre

- [ ] Leí la teoría y entendí el mapa visual.
- [ ] Realicé la práctica o análisis sugerido.
- [ ] Documenté decisiones técnicas.
- [ ] Subí el trabajo a GitHub.
- [ ] Compartí el enlace en Classroom.
