# Semana 15: Optimización de costos y seguridad: IAM y Roles

**Módulo:** 2  
**Bloque:** Gestión y Alta Disponibilidad  
**Duración sincrónica:** 1h30  
**Carga total sugerida:** 7.5 horas semanales  
**Producto de la semana:** evidencia técnica en GitHub.

---

## 1. Resultado de aprendizaje

Al finalizar la semana, el estudiante será capaz de:

- Aplicar principio de menor privilegio en IAM.
- Relacionar roles, políticas y servicios AWS.
- Diseñar controles de costos y etiquetado.

---

## 2. Contexto profesional


IAM define quién puede hacer qué sobre cuáles recursos. En producción se prefiere usar roles temporales y políticas mínimas en lugar de credenciales permanentes. Cada permiso debe responder a una necesidad concreta.

La seguridad en nube también incluye costos. Un diseño sin presupuestos, límites y etiquetas puede generar gastos imprevistos. Las etiquetas permiten asociar recursos a proyectos, ambientes, responsables y centros de costo.


---

## 3. Conceptos clave

- **IAM**
- **Role**
- **Policy**
- **Least Privilege**
- **Budget**
- **Tagging**
- **KMS**

---

## 4. Mapa visual del tema

```mermaid
flowchart LR
    User[Usuario o Pipeline] --> Role[Rol IAM]
    Role --> Policy[Política con permisos mínimos]
    Policy --> Resource[Recurso AWS]
    Resource --> Tags[Etiquetas de costo]
    Resource --> KMS[Cifrado KMS]

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

Diseñar una política IAM mínima para que una aplicación lea un secreto y escriba logs.

### Evidencia mínima de práctica

El estudiante debe incluir en su repositorio:

```text
/semana-15
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

Crear un plan de seguridad y costos para el despliegue del proyecto final.

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

- https://docs.aws.amazon.com/IAM/latest/UserGuide/introduction.html
- https://docs.aws.amazon.com/cost-management/latest/userguide/budgets-managing-costs.html

---

## 10. Checklist de cierre

- [ ] Leí la teoría y entendí el mapa visual.
- [ ] Realicé la práctica o análisis sugerido.
- [ ] Documenté decisiones técnicas.
- [ ] Subí el trabajo a GitHub.
- [ ] Compartí el enlace en Classroom.
