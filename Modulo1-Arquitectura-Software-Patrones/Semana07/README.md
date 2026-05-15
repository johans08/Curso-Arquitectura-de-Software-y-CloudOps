# Semana 7: Seguridad en el diseño: OAuth2 y JWT

**Módulo:** 1  
**Bloque:** Comunicación y Seguridad del Sistema  
**Duración sincrónica:** 1h30  
**Carga total sugerida:** 7.5 horas semanales  
**Producto de la semana:** evidencia técnica en GitHub.

---

## 1. Resultado de aprendizaje

Al finalizar la semana, el estudiante será capaz de:

- Explicar OAuth2, JWT, claims, roles y scopes.
- Configurar autenticación JWT en ASP.NET Core.
- Diseñar autorización por roles y políticas.

---

## 2. Contexto profesional


La seguridad debe diseñarse desde la arquitectura, no agregarse al final. JWT permite transportar claims firmados que una API puede validar sin consultar sesión en cada request. OAuth2 define flujos de autorización para que clientes obtengan tokens de manera controlada.

Un token no debe contener secretos ni información sensible innecesaria. Debe tener expiración razonable, issuer, audience, firma fuerte y claims mínimos. La autorización debe validarse del lado servidor mediante roles, scopes o políticas. En sistemas profesionales se recomienda delegar identidad a un proveedor especializado, pero para fines del curso se implementa un emisor simple para comprender los fundamentos.


---

## 3. Conceptos clave

- **OAuth2**
- **JWT**
- **Claims**
- **Scopes**
- **Roles**
- **Bearer Token**
- **Refresh Token**
- **Least Privilege**

---

## 4. Mapa visual del tema

```mermaid
sequenceDiagram
    participant User
    participant Web as Blazor Web
    participant Auth as API Auth
    participant API
    User->>Web: Credenciales
    Web->>Auth: POST /login
    Auth-->>Web: JWT
    Web->>API: Authorization: Bearer JWT
    API->>API: Validar firma, issuer, audience y claims
    API-->>Web: Recurso autorizado

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

Agregar endpoint de login, generación de JWT y protección de endpoints de órdenes por rol.

### Evidencia mínima de práctica

El estudiante debe incluir en su repositorio:

```text
/semana-07
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

Implementar autorización para Admin y Student. Documentar claims, expiración del token y riesgos de seguridad.

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

- https://learn.microsoft.com/aspnet/core/security/authentication/configure-jwt-bearer-authentication
- https://learn.microsoft.com/aspnet/core/security/authorization/introduction
- https://oauth.net/2/

---

## 10. Checklist de cierre

- [ ] Leí la teoría y entendí el mapa visual.
- [ ] Realicé la práctica o análisis sugerido.
- [ ] Documenté decisiones técnicas.
- [ ] Subí el trabajo a GitHub.
- [ ] Compartí el enlace en Classroom.
