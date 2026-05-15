# Semana 8: Laboratorio integrador: backend con frontend moderno en .NET

**Módulo:** 1  
**Bloque:** Comunicación y Seguridad del Sistema  
**Duración sincrónica:** 1h30  
**Carga total sugerida:** 7.5 horas semanales  
**Producto de la semana:** evidencia técnica en GitHub.

---

## 1. Resultado de aprendizaje

Al finalizar la semana, el estudiante será capaz de:

- Integrar API, Blazor, SQL Server y seguridad.
- Documentar arquitectura de extremo a extremo.
- Preparar el entregable integrador del módulo 1.

---

## 2. Contexto profesional


La integración backend-frontend obliga a validar si las decisiones anteriores son coherentes. Una API bien documentada facilita el consumo desde Blazor; una capa de aplicación clara evita duplicar reglas en la interfaz; una base de datos bien diseñada soporta consultas y transacciones; y una estrategia de seguridad protege los recursos.

Blazor permite construir UI con C# y componentes Razor. Esto reduce el número de lenguajes para estudiantes centrados en .NET y permite compartir modelos o contratos cuando sea apropiado. Aun así, el frontend no debe convertirse en una extensión sin control de la base de datos: debe consumir APIs y respetar contratos.


---

## 3. Conceptos clave

- **Backend for Frontend**
- **Blazor**
- **API Client**
- **Arquitectura limpia**
- **Integración vertical**

---

## 4. Mapa visual del tema

```mermaid
flowchart LR
    Browser[Usuario en navegador] --> Blazor[Blazor .NET]
    Blazor --> API[ASP.NET Core API]
    API --> App[Application Layer]
    App --> Domain[Domain Layer]
    App --> Infra[Infrastructure]
    Infra --> SQL[(SQL Server)]
    Infra --> Outbox[(Outbox)]

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

Construir una pantalla Blazor para listar y crear órdenes consumiendo la API protegida.

### Evidencia mínima de práctica

El estudiante debe incluir en su repositorio:

```text
/semana-08
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

Proyecto integrador del módulo 1: sistema mínimo de órdenes con API, UI Blazor, SQL Server, JWT, Swagger, Outbox y README técnico.

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

- https://learn.microsoft.com/aspnet/core/blazor/
- https://learn.microsoft.com/aspnet/core/
- https://learn.microsoft.com/aspnet/core/fundamentals/openapi/aspnetcore-openapi

---

## 10. Checklist de cierre

- [ ] Leí la teoría y entendí el mapa visual.
- [ ] Realicé la práctica o análisis sugerido.
- [ ] Documenté decisiones técnicas.
- [ ] Subí el trabajo a GitHub.
- [ ] Compartí el enlace en Classroom.
