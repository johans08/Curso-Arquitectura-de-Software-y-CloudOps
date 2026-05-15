# Semana 18: Orquestación básica y fundamentos de Kubernetes

**Módulo:** 3  
**Bloque:** Contenedores e Infraestructura como Código  
**Duración sincrónica:** 1h30  
**Carga total sugerida:** 7.5 horas semanales  
**Producto de la semana:** evidencia técnica en GitHub.

---

## 1. Resultado de aprendizaje

Al finalizar la semana, el estudiante será capaz de:

- Explicar Pods, Deployments y Services.
- Crear manifiestos básicos de Kubernetes.
- Comprender escalamiento y rolling updates.

---

## 2. Contexto profesional


Kubernetes orquesta contenedores declarando el estado deseado. En lugar de iniciar contenedores manualmente, se define cuántas réplicas deben existir, cómo se exponen, qué configuración usan y cómo se actualizan.

Un Pod es la unidad mínima de ejecución. Un Deployment administra réplicas y actualizaciones. Un Service proporciona una dirección estable para acceder a Pods que pueden cambiar. La complejidad de Kubernetes solo se justifica si se necesita orquestación, escalamiento, resiliencia y operación estandarizada.


---

## 3. Conceptos clave

- **Pod**
- **Deployment**
- **Service**
- **ConfigMap**
- **Secret**
- **Ingress**
- **Rolling Update**

---

## 4. Mapa visual del tema

```mermaid
flowchart TD
    Ingress[Ingress] --> Service[Service]
    Service --> Pod1[Pod API 1]
    Service --> Pod2[Pod API 2]
    Deployment[Deployment] -. controla .-> Pod1
    Deployment -. controla .-> Pod2
    Config[ConfigMap/Secret] -. configura .-> Pod1
    Config -. configura .-> Pod2

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

Crear manifiestos Deployment y Service para la API contenerizada.

### Evidencia mínima de práctica

El estudiante debe incluir en su repositorio:

```text
/semana-18
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

Diseñar despliegue Kubernetes para API y Web con variables de entorno, réplicas y estrategia de actualización.

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

- https://kubernetes.io/docs/concepts/overview/
- https://kubernetes.io/docs/concepts/workloads/controllers/deployment/
- https://kubernetes.io/docs/concepts/services-networking/service/

---

## 10. Checklist de cierre

- [ ] Leí la teoría y entendí el mapa visual.
- [ ] Realicé la práctica o análisis sugerido.
- [ ] Documenté decisiones técnicas.
- [ ] Subí el trabajo a GitHub.
- [ ] Compartí el enlace en Classroom.
