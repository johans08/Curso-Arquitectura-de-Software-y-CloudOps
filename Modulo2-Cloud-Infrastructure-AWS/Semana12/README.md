# Semana 12: Computación Serverless: AWS Lambda y API Gateway

**Módulo:** 2  
**Bloque:** Redes y Cómputo en la Nube  
**Duración sincrónica:** 1h30  
**Carga total sugerida:** 7.5 horas semanales  
**Producto de la semana:** evidencia técnica en GitHub.

---

## 1. Resultado de aprendizaje

Al finalizar la semana, el estudiante será capaz de:

- Explicar serverless y sus trade-offs.
- Diseñar una API con Lambda y API Gateway.
- Comparar Lambda con EC2 para cargas web.

---

## 2. Contexto profesional


Serverless no significa que no existan servidores; significa que el proveedor administra la infraestructura subyacente y el equipo se concentra en funciones, eventos y configuración. Lambda ejecuta código bajo demanda, escala automáticamente y cobra por uso, pero tiene límites de duración, memoria, tamaño y comportamiento de arranque.

API Gateway expone endpoints HTTP y puede enrutar solicitudes hacia Lambda, servicios AWS o backends privados. El diseño serverless es conveniente para tareas event-driven, APIs de bajo mantenimiento, procesamiento de archivos y automatizaciones.


---

## 3. Conceptos clave

- **Lambda**
- **API Gateway**
- **Cold Start**
- **Timeout**
- **Event-driven**
- **Stateless**

---

## 4. Mapa visual del tema

```mermaid
sequenceDiagram
    participant Client
    participant APIGW as API Gateway
    participant Lambda
    participant DB as RDS o DynamoDB
    Client->>APIGW: HTTP Request
    APIGW->>Lambda: Evento
    Lambda->>DB: Lee o escribe datos
    Lambda-->>APIGW: Respuesta
    APIGW-->>Client: HTTP Response

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

Diseñar una función Lambda para procesar mensajes pendientes del Outbox o generar reportes.

### Evidencia mínima de práctica

El estudiante debe incluir en su repositorio:

```text
/semana-12
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

Comparar EC2, Lambda y contenedores para tres escenarios de negocio. Justificar la selección.

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

- https://docs.aws.amazon.com/lambda/
- https://docs.aws.amazon.com/apigateway/

---

## 10. Checklist de cierre

- [ ] Leí la teoría y entendí el mapa visual.
- [ ] Realicé la práctica o análisis sugerido.
- [ ] Documenté decisiones técnicas.
- [ ] Subí el trabajo a GitHub.
- [ ] Compartí el enlace en Classroom.
