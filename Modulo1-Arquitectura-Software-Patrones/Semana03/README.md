# Semana 3: Arquitectura Monolítica vs Microservicios: Estrategias de decisión

**Módulo:** 1  
**Bloque:** Diseño de Componentes y Limpieza de Código  
**Duración sincrónica:** 1h30  
**Carga total sugerida:** 7.5 horas semanales  
**Producto de la semana:** evidencia técnica en GitHub.

---

## 1. Resultado de aprendizaje

Al finalizar la semana, el estudiante será capaz de:

- Comparar monolito, monolito modular y microservicios.
- Construir una matriz de decisión técnica.
- Diseñar límites de módulos antes de separar procesos.

---

## 2. Contexto profesional


La discusión no debe ser monolito contra microservicios, sino qué arquitectura reduce mejor el riesgo del negocio en el contexto actual. Un monolito bien modularizado puede ser más mantenible que un conjunto de microservicios mal delimitados. Los microservicios agregan independencia de despliegue, escalabilidad granular y autonomía de equipos, pero también introducen observabilidad distribuida, latencia, consistencia eventual, automatización obligatoria y mayor carga operacional.

La recomendación profesional es iniciar con límites claros dentro del código y separar servicios solo cuando existan razones fuertes: escalamiento independiente, ciclos de cambio diferentes, aislamiento de fallas, autonomía de equipos o requisitos regulatorios.


---

## 3. Conceptos clave

- **Monolito modular**
- **Microservicios**
- **Bounded Context**
- **Acoplamiento operacional**
- **Consistencia distribuida**

---

## 4. Mapa visual del tema

```mermaid
flowchart LR
    subgraph ModularMonolith[Monolito modular]
      A[Ventas] --> DB[(Base compartida controlada)]
      B[Inventario] --> DB
      C[Facturación] --> DB
    end
    subgraph Microservices[Microservicios]
      S1[Servicio Ventas] --> D1[(DB Ventas)]
      S2[Servicio Inventario] --> D2[(DB Inventario)]
      S3[Servicio Facturación] --> D3[(DB Facturación)]
      S1 -. eventos .-> S2
      S1 -. eventos .-> S3
    end

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

Tomar la aplicación de órdenes y dividirla en módulos internos: Catálogo, Órdenes, Seguridad y Notificaciones. Documentar qué módulo podría convertirse en microservicio y por qué.

### Evidencia mínima de práctica

El estudiante debe incluir en su repositorio:

```text
/semana-03
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

Crear una matriz de decisión para una empresa ficticia que desea migrar a microservicios. Incluir riesgos, beneficios, requisitos previos y recomendación final.

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

- https://learn.microsoft.com/dotnet/architecture/microservices/
- https://learn.microsoft.com/azure/architecture/guide/architecture-styles/microservices

---

## 10. Checklist de cierre

- [ ] Leí la teoría y entendí el mapa visual.
- [ ] Realicé la práctica o análisis sugerido.
- [ ] Documenté decisiones técnicas.
- [ ] Subí el trabajo a GitHub.
- [ ] Compartí el enlace en Classroom.
