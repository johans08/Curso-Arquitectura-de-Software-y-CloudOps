# Semana 20: Gestión de configuraciones y despliegues automáticos

**Módulo:** 3  
**Bloque:** Contenedores e Infraestructura como Código  
**Duración sincrónica:** 1h30  
**Carga total sugerida:** 7.5 horas semanales  
**Producto de la semana:** evidencia técnica en GitHub.

---

## 1. Resultado de aprendizaje

Al finalizar la semana, el estudiante será capaz de:

- Gestionar configuración por ambiente.
- Separar secretos de configuración no sensible.
- Diseñar despliegues reproducibles.

---

## 2. Contexto profesional


La configuración permite que la misma aplicación se ejecute en desarrollo, pruebas y producción sin recompilar. Valores como URLs, nombres de colas, niveles de logging o feature flags pueden ser configuración. Secretos como contraseñas, tokens y claves privadas requieren almacenamiento protegido.

En .NET, appsettings, variables de entorno y providers externos pueden combinarse. En AWS, servicios como Systems Manager Parameter Store o Secrets Manager permiten centralizar valores de configuración y secretos.


---

## 3. Conceptos clave

- **Configuration**
- **Secrets**
- **Environment**
- **Parameter Store**
- **AppSettings**
- **Release**

---

## 4. Mapa visual del tema

```mermaid
flowchart TD
    App[Aplicación .NET] --> ConfigProvider[Configuration Providers]
    ConfigProvider --> AppSettings[appsettings.json]
    ConfigProvider --> Env[Variables de entorno]
    ConfigProvider --> SSM[AWS Parameter Store]
    ConfigProvider --> Secrets[AWS Secrets Manager]

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

Modificar la app para leer configuración desde variables de entorno y preparar appsettings por ambiente.

### Evidencia mínima de práctica

El estudiante debe incluir en su repositorio:

```text
/semana-20
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

Crear estrategia de configuración para dev, test y prod. Identificar qué valores son secretos y cómo protegerlos.

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

- https://learn.microsoft.com/aspnet/core/fundamentals/configuration/
- https://docs.aws.amazon.com/systems-manager/latest/userguide/systems-manager-parameter-store.html

---

## 10. Checklist de cierre

- [ ] Leí la teoría y entendí el mapa visual.
- [ ] Realicé la práctica o análisis sugerido.
- [ ] Documenté decisiones técnicas.
- [ ] Subí el trabajo a GitHub.
- [ ] Compartí el enlace en Classroom.
