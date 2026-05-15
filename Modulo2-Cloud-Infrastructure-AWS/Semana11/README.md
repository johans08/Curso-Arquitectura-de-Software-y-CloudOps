# Semana 11: Almacenamiento: S3, EBS y ciclos de vida de datos

**Módulo:** 2  
**Bloque:** Redes y Cómputo en la Nube  
**Duración sincrónica:** 1h30  
**Carga total sugerida:** 7.5 horas semanales  
**Producto de la semana:** evidencia técnica en GitHub.

---

## 1. Resultado de aprendizaje

Al finalizar la semana, el estudiante será capaz de:

- Diferenciar S3, EBS y almacenamiento de base de datos.
- Diseñar políticas de ciclo de vida de datos.
- Aplicar criterios de cifrado, versionado y backup.

---

## 2. Contexto profesional


S3 es almacenamiento de objetos, no un disco tradicional. Es ideal para archivos, respaldos, artefactos, imágenes, logs y contenido estático. EBS es almacenamiento de bloque asociado a instancias EC2, útil para sistemas operativos y discos persistentes. RDS administra el almacenamiento de la base de datos como parte del servicio.

Una arquitectura madura define clasificación de datos, cifrado, retención, versionado y ciclo de vida. No todos los datos deben vivir en almacenamiento de alto costo; algunos pueden moverse a clases más económicas con reglas automáticas.


---

## 3. Conceptos clave

- **S3**
- **EBS**
- **Versioning**
- **Lifecycle**
- **Encryption**
- **Backup**
- **Object Storage**

---

## 4. Mapa visual del tema

```mermaid
flowchart TD
    App[Aplicación .NET] -->|Archivos de usuario| S3[(Amazon S3)]
    EC2[Instancia EC2] -->|Disco del sistema| EBS[(Amazon EBS)]
    API[API] -->|Datos transaccionales| RDS[(Amazon RDS)]
    S3 --> Lifecycle[Reglas de ciclo de vida]

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

Diseñar flujo para guardar archivos de órdenes en S3 y metadatos en SQL Server/RDS.

### Evidencia mínima de práctica

El estudiante debe incluir en su repositorio:

```text
/semana-11
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

Proponer una política de almacenamiento para documentos, logs y respaldos del sistema final.

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

- https://docs.aws.amazon.com/s3/
- https://docs.aws.amazon.com/ebs/

---

## 10. Checklist de cierre

- [ ] Leí la teoría y entendí el mapa visual.
- [ ] Realicé la práctica o análisis sugerido.
- [ ] Documenté decisiones técnicas.
- [ ] Subí el trabajo a GitHub.
- [ ] Compartí el enlace en Classroom.
