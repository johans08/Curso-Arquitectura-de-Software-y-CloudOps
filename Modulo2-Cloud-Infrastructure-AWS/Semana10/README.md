# Semana 10: Servicios de Cómputo: EC2 y Auto Scaling

**Módulo:** 2  
**Bloque:** Redes y Cómputo en la Nube  
**Duración sincrónica:** 1h30  
**Carga total sugerida:** 7.5 horas semanales  
**Producto de la semana:** evidencia técnica en GitHub.

---

## 1. Resultado de aprendizaje

Al finalizar la semana, el estudiante será capaz de:

- Explicar EC2, AMI, tipos de instancia y user data.
- Diseñar escalamiento horizontal con Auto Scaling.
- Entender health checks detrás de un balanceador.

---

## 2. Contexto profesional


EC2 proporciona máquinas virtuales configurables. Aunque servicios administrados y serverless reducen carga operativa, EC2 sigue siendo fundamental para entender cómputo en la nube. Una instancia aislada es frágil; por eso una arquitectura profesional usa plantillas de lanzamiento, grupos de Auto Scaling y balanceadores.

Auto Scaling no solo escala por demanda; también reemplaza instancias no saludables. El Application Load Balancer distribuye tráfico HTTP/HTTPS y usa health checks para enviar tráfico solo a destinos disponibles.


---

## 3. Conceptos clave

- **EC2**
- **AMI**
- **Launch Template**
- **Auto Scaling Group**
- **ALB**
- **Health Check**
- **User Data**

---

## 4. Mapa visual del tema

```mermaid
flowchart LR
    User[Usuarios] --> ALB[Application Load Balancer]
    ALB --> EC2A[EC2 App AZ-A]
    ALB --> EC2B[EC2 App AZ-B]
    ASG[Auto Scaling Group] -. mantiene capacidad .-> EC2A
    ASG -. mantiene capacidad .-> EC2B

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

Preparar script user-data conceptual para instalar runtime .NET y levantar la API como servicio.

### Evidencia mínima de práctica

El estudiante debe incluir en su repositorio:

```text
/semana-10
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

Diseñar una estrategia de cómputo para soportar crecimiento de tráfico con métricas de escalamiento y health checks.

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

- https://docs.aws.amazon.com/ec2/
- https://docs.aws.amazon.com/autoscaling/ec2/userguide/what-is-amazon-ec2-auto-scaling.html

---

## 10. Checklist de cierre

- [ ] Leí la teoría y entendí el mapa visual.
- [ ] Realicé la práctica o análisis sugerido.
- [ ] Documenté decisiones técnicas.
- [ ] Subí el trabajo a GitHub.
- [ ] Compartí el enlace en Classroom.
