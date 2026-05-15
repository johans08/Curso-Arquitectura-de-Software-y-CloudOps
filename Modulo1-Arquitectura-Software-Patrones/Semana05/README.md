# Semana 5: Comunicación asíncrona y patrones de mensajería

**Módulo:** 1  
**Bloque:** Comunicación y Seguridad del Sistema  
**Duración sincrónica:** 1h30  
**Carga total sugerida:** 7.5 horas semanales  
**Producto de la semana:** evidencia técnica en GitHub.

---

## 1. Resultado de aprendizaje

Al finalizar la semana, el estudiante será capaz de:

- Explicar comunicación síncrona vs asíncrona.
- Aplicar Outbox Pattern con SQL Server.
- Diseñar mensajes idempotentes.

---

## 2. Contexto profesional


La comunicación asíncrona desacopla el momento en que ocurre una acción del momento en que otros componentes reaccionan. En producción se usan brokers como SQS, RabbitMQ, Kafka o Service Bus, pero antes de introducir infraestructura externa conviene entender los patrones fundamentales.

El Outbox Pattern resuelve un problema clásico: guardar datos y publicar un mensaje deben comportarse como una unidad lógica. Si se guarda una orden pero falla la publicación del evento, otros sistemas nunca se enteran. Con Outbox, el evento se guarda en la misma transacción de SQL Server y un proceso posterior lo publica o procesa.

La idempotencia es obligatoria: un consumidor debe tolerar recibir el mismo mensaje más de una vez sin duplicar efectos críticos.


---

## 3. Conceptos clave

- **Queue**
- **Event**
- **Command**
- **Outbox**
- **Inbox**
- **Idempotencia**
- **Consistencia eventual**

---

## 4. Mapa visual del tema

```mermaid
flowchart TD
    A[Crear Orden] --> T{Transacción SQL}
    T --> O[(Tabla Orders)]
    T --> X[(Tabla OutboxMessages)]
    X --> W[Worker en .NET]
    W --> H[Handler de evento]
    H --> N[Notificación / Proyección / Integración]

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

Agregar tabla OutboxMessages a SQL Server y un BackgroundService en .NET que procese mensajes pendientes.

### Evidencia mínima de práctica

El estudiante debe incluir en su repositorio:

```text
/semana-05
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

Implementar un flujo asíncrono para notificar creación de producto o pedido. Debe evitar duplicados y documentar el criterio de idempotencia.

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

- https://learn.microsoft.com/dotnet/core/extensions/workers
- https://learn.microsoft.com/dotnet/api/microsoft.extensions.hosting.backgroundservice

---

## 10. Checklist de cierre

- [ ] Leí la teoría y entendí el mapa visual.
- [ ] Realicé la práctica o análisis sugerido.
- [ ] Documenté decisiones técnicas.
- [ ] Subí el trabajo a GitHub.
- [ ] Compartí el enlace en Classroom.
