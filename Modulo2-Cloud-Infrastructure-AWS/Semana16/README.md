# Semana 16: Laboratorio: Arquitectura web completa en AWS

**Módulo:** 2  
**Bloque:** Gestión y Alta Disponibilidad  
**Duración sincrónica:** 1h30  
**Carga total sugerida:** 7.5 horas semanales  
**Producto de la semana:** evidencia técnica en GitHub.

---

## 1. Resultado de aprendizaje

Al finalizar la semana, el estudiante será capaz de:

- Integrar VPC, EC2, RDS, S3, IAM y CloudWatch.
- Explicar una arquitectura web completa en AWS.
- Preparar entregable integrador del módulo 2.

---

## 2. Contexto profesional


El laboratorio integrador de AWS une los servicios estudiados en una arquitectura coherente. La meta no es crear recursos al azar, sino justificar cada componente: red aislada, balanceador público, cómputo privado, base de datos protegida, almacenamiento de objetos, roles IAM mínimos, logs, métricas y alarmas.

Una arquitectura cloud profesional debe poder explicarse desde cinco perspectivas: seguridad, disponibilidad, operación, costo y evolución. Si un componente no puede justificarse en esas dimensiones, probablemente se está agregando complejidad innecesaria.


---

## 3. Conceptos clave

- **Arquitectura web AWS**
- **Alta disponibilidad**
- **Capas**
- **Operación**
- **Seguridad**

---

## 4. Mapa visual del tema

```mermaid
flowchart TB
    Users((Usuarios)) --> ALB[ALB público]
    ALB --> AppA[EC2 App AZ-A]
    ALB --> AppB[EC2 App AZ-B]
    AppA --> RDS[(RDS privado)]
    AppB --> RDS
    AppA --> S3[(S3 archivos)]
    AppB --> S3
    AppA --> CW[CloudWatch]
    AppB --> CW
    IAM[IAM Roles] -. permisos .-> AppA
    IAM -. permisos .-> AppB

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

Preparar diseño completo de despliegue de la aplicación .NET en AWS con diagrama y checklist de recursos.

### Evidencia mínima de práctica

El estudiante debe incluir en su repositorio:

```text
/semana-16
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

Proyecto integrador del módulo 2: documento de arquitectura AWS con diagrama, seguridad, costos, monitoreo y plan de despliegue.

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

- https://docs.aws.amazon.com/wellarchitected/latest/framework/welcome.html
- https://docs.aws.amazon.com/vpc/
- https://docs.aws.amazon.com/ec2/
- https://docs.aws.amazon.com/AmazonRDS/latest/UserGuide/Welcome.html

---

## 10. Checklist de cierre

- [ ] Leí la teoría y entendí el mapa visual.
- [ ] Realicé la práctica o análisis sugerido.
- [ ] Documenté decisiones técnicas.
- [ ] Subí el trabajo a GitHub.
- [ ] Compartí el enlace en Classroom.
