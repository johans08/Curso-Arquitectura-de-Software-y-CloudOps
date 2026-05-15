# Semana 2: Patrones de diseño esenciales: Creacionales y Estructurales

**Módulo:** 1  
**Bloque:** Diseño de Componentes y Limpieza de Código  
**Duración sincrónica:** 1h30  
**Carga total sugerida:** 7.5 horas semanales  
**Producto de la semana:** evidencia técnica en GitHub.

---

## 1. Resultado de aprendizaje

Al finalizar la semana, el estudiante será capaz de:

- Reconocer patrones creacionales y estructurales comunes.
- Implementar Factory, Builder, Adapter, Decorator y Facade en .NET.
- Evitar sobreingeniería al aplicar patrones.

---

## 2. Contexto profesional


Un patrón de diseño es una solución reutilizable a un problema recurrente de diseño. No debe aplicarse por obligación, sino cuando el problema realmente existe. En sistemas empresariales, los patrones ayudan a aislar variaciones: creación de objetos, integración con servicios externos, enriquecimiento de comportamiento o simplificación de subsistemas.

Los patrones creacionales controlan cómo se construyen objetos complejos o variables. Los patrones estructurales organizan relaciones entre objetos para reducir acoplamiento. En .NET, muchos patrones aparecen dentro del framework: la inyección de dependencias actúa como mecanismo de composición, los middleware se comportan como cadena/decoradores, y los HttpClient typed clients funcionan como adaptadores hacia servicios externos.


---

## 3. Conceptos clave

- **Factory Method**
- **Builder**
- **Adapter**
- **Decorator**
- **Facade**
- **Composición sobre herencia**

---

## 4. Mapa visual del tema

```mermaid
classDiagram
    class INotificationSender { <<interface>> Send(message) }
    class EmailSender { Send(message) }
    class LoggingNotificationDecorator { Send(message) }
    INotificationSender <|.. EmailSender
    INotificationSender <|.. LoggingNotificationDecorator
    LoggingNotificationDecorator --> INotificationSender : envuelve

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

Implementar un servicio de notificaciones con Factory para elegir canal, Decorator para logging y Adapter para simular proveedor externo.

### Evidencia mínima de práctica

El estudiante debe incluir en su repositorio:

```text
/semana-02
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

Diseñar un módulo de pagos simulado aplicando al menos dos patrones. Documentar qué problema resuelve cada patrón y por qué no se eligió una solución más simple.

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

- https://learn.microsoft.com/dotnet/standard/design-guidelines/
- https://refactoring.guru/design-patterns/csharp

---

## 10. Checklist de cierre

- [ ] Leí la teoría y entendí el mapa visual.
- [ ] Realicé la práctica o análisis sugerido.
- [ ] Documenté decisiones técnicas.
- [ ] Subí el trabajo a GitHub.
- [ ] Compartí el enlace en Classroom.
