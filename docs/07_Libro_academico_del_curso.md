# Libro académico del curso

Este documento reúne la intención pedagógica de las 24 semanas. Su objetivo es que el estudiante no dependa únicamente de instrucciones de laboratorio, sino que pueda estudiar el razonamiento detrás de cada decisión técnica.

## Enfoque global

La certificación se construye alrededor de una progresión: primero se aprende a diseñar software mantenible, luego se aprende a desplegarlo en nube y finalmente se automatiza su ciclo de vida. La aplicación de referencia .NET + SQL Server + Blazor funciona como hilo conductor para que las tecnologías no se estudien aisladas.

## Módulo 1: Arquitectura de Software y Patrones

### Semana 1: SOLID y Clean Code

La calidad del diseño se mide por la facilidad con la que el sistema puede cambiar. SOLID proporciona criterios para controlar dependencias, separar responsabilidades y evitar que una clase concentre demasiadas razones para cambiar. En una API ASP.NET Core, una mala señal es encontrar controladores que validan, consultan la base de datos, calculan reglas de negocio y formatean respuestas al mismo tiempo.

Clean Code se relaciona con la lectura cotidiana del código. Una función clara, un nombre preciso y un error bien expresado reducen el esfuerzo cognitivo del equipo. La arquitectura no empieza con diagramas grandes; empieza con unidades pequeñas que comunican intención.

### Semana 2: Patrones de diseño

Los patrones son vocabulario compartido para resolver problemas frecuentes. Factory ayuda cuando la creación de objetos depende de reglas. Builder es útil cuando un objeto se construye por pasos. Adapter traduce una interfaz externa al lenguaje interno del sistema. Decorator agrega comportamiento sin modificar la clase original. Facade simplifica un subsistema complejo.

El riesgo principal es aplicar patrones sin necesidad. Un patrón debe resolver un problema visible: variación, complejidad, integración, extensibilidad o aislamiento. Si el patrón no reduce complejidad, probablemente la aumenta.

### Semana 3: Monolito vs Microservicios

El monolito no es sinónimo de mala arquitectura. Un monolito modular puede ser una excelente primera decisión cuando el equipo es pequeño, el dominio aún cambia y no existe automatización madura. Los microservicios ofrecen independencia, pero exigen observabilidad, CI/CD, manejo de fallas distribuidas, seguridad entre servicios y consistencia eventual.

La decisión responsable es diseñar límites de dominio antes de separar procesos. Separar mal un sistema puede producir más acoplamiento, no menos.

### Semana 4: APIs profesionales

Una API es un contrato. La documentación OpenAPI no debe ser un accesorio final; debe reflejar las decisiones del contrato: nombres de recursos, formatos de entrada, respuestas, errores, códigos HTTP, autenticación y versionado.

El consumidor de una API necesita previsibilidad. Si la API devuelve distintos formatos de error, no pagina respuestas grandes o cambia contratos sin versión, se convierte en una fuente de fallos para otros equipos.

### Semana 5: Comunicación asíncrona

La comunicación asíncrona permite desacoplar procesos y mejorar resiliencia. Sin embargo, introduce nuevos problemas: duplicados, orden de mensajes, reintentos, mensajes muertos y consistencia eventual. El Outbox Pattern es una forma práctica de enseñar estos fundamentos usando SQL Server antes de incorporar brokers externos.

La pregunta clave es: ¿qué debe ocurrir dentro de la transacción principal y qué puede ocurrir después?

### Semana 6: SQL vs NoSQL

SQL Server es adecuado para transacciones, relaciones, integridad y consultas estructuradas. NoSQL puede ser mejor cuando el acceso es por documento, clave, grafo o cuando el esquema cambia con mucha frecuencia. La decisión debe surgir del patrón de uso, no de la popularidad de la tecnología.

La persistencia políglota es común en sistemas maduros: se usan diferentes modelos para diferentes necesidades. Aun así, cada base adicional aumenta operación, monitoreo, seguridad y respaldo.

### Semana 7: OAuth2 y JWT

JWT permite validar identidad y claims sin mantener sesión local en cada request. OAuth2 define cómo un cliente obtiene permisos para acceder a recursos. El diseño seguro exige expiración, firma, audiencia, emisor y claims mínimos.

El error más común es tratar JWT como una sesión mágica o guardar datos sensibles dentro del token. Un token firmado no está necesariamente cifrado.

### Semana 8: Integración backend + frontend

La integración revela la calidad de las decisiones. Si el frontend necesita conocer detalles internos de la base de datos, la API está mal diseñada. Si la API no documenta errores, la UI no puede reaccionar bien. Si las reglas de negocio se duplican en Blazor y backend, el sistema se vuelve inconsistente.

Blazor permite mantener el stack .NET y concentrar el aprendizaje en arquitectura, contratos y operación.

## Módulo 2: Cloud Infrastructure & AWS

### Semana 9: Fundamentos de nube y VPC

La nube no es solo servidores de otra persona. Es un modelo operativo donde red, identidad, cómputo, almacenamiento, seguridad y costos se definen como capacidades administrables. La VPC es el límite de red principal para aislar recursos. Diseñar subredes públicas y privadas enseña una regla básica: no todo componente que funciona necesita estar expuesto a Internet.

### Semana 10: EC2 y Auto Scaling

EC2 enseña cómputo de forma explícita: sistema operativo, capacidad, parches, puertos y servicios. Auto Scaling agrega resiliencia porque reemplaza instancias no saludables y ajusta capacidad. El balanceador separa a los usuarios de las instancias específicas.

La lección arquitectónica es evitar dependencia de servidores únicos.

### Semana 11: Almacenamiento

S3, EBS y RDS resuelven necesidades diferentes. S3 almacena objetos, EBS provee bloque para instancias y RDS administra almacenamiento de bases de datos. Una estrategia de datos debe considerar retención, clasificación, cifrado, versionado y costo.

La nube facilita crear almacenamiento, pero no define por sí sola cuánto tiempo guardar ni cómo proteger la información.

### Semana 12: Serverless

Lambda y API Gateway permiten construir componentes event-driven con baja operación inicial. Serverless es poderoso cuando el trabajo es stateless, acotado y activado por eventos. No siempre reemplaza a una API tradicional; debe evaluarse por latencia, límites, costo, arranque y complejidad de integración.

### Semana 13: RDS y alta disponibilidad

RDS reduce trabajo operativo, pero no elimina responsabilidad del arquitecto. Se deben definir backups, ventanas de mantenimiento, cifrado, Multi-AZ, pruebas de restauración, RTO y RPO. Alta disponibilidad es una combinación de servicio administrado, diseño de aplicación y procedimientos operativos.

### Semana 14: Observabilidad

Un sistema que no se puede observar es difícil de operar. CloudWatch permite centralizar métricas y logs; CloudTrail registra actividad de API. La observabilidad debe diseñarse antes del incidente. Cada alerta debe tener dueño, severidad y acción.

### Semana 15: Costos e IAM

IAM es el sistema nervioso de seguridad en AWS. Menor privilegio significa dar solo los permisos necesarios, en el momento necesario y al principal correcto. El costo también es una decisión de arquitectura: cada recurso debe etiquetarse, medirse y justificarse.

### Semana 16: Arquitectura web completa en AWS

El módulo se integra diseñando una solución con red, cómputo, almacenamiento, base de datos, seguridad y monitoreo. El objetivo no es crear recursos, sino demostrar que cada recurso tiene una razón y un plan de operación.

## Módulo 3: DevOps & Automatización

### Semana 17: Docker

Docker mejora portabilidad y consistencia entre ambientes. El Dockerfile debe separar construcción y ejecución, minimizar capas, evitar secretos y permitir configuración externa. Una imagen debe ser un artefacto confiable, no una copia improvisada de la máquina del desarrollador.

### Semana 18: Kubernetes

Kubernetes declara el estado deseado de aplicaciones contenerizadas. Deployment, Service, ConfigMap, Secret e Ingress son piezas básicas para operar cargas. La complejidad se justifica cuando existe necesidad de escalamiento, resiliencia, estandarización y despliegues controlados.

### Semana 19: Terraform

Terraform permite versionar infraestructura. El cambio de infraestructura pasa por revisión, plan y aplicación. El estado debe protegerse porque representa el vínculo entre código y recursos reales.

### Semana 20: Configuración y despliegues

Un mismo binario debe poder moverse entre ambientes cambiando configuración, no código. Los secretos deben administrarse en mecanismos seguros. La configuración mal gestionada produce errores difíciles de diagnosticar y riesgos de seguridad.

### Semana 21: CI/CD

CI/CD convierte la disciplina del equipo en automatización. Cada commit debe poder compilarse y validarse. Cada despliegue debe ser repetible. Los pipelines también requieren seguridad: secretos protegidos, permisos mínimos y revisión de cambios.

### Semana 22: Blue/Green y Canary

Las estrategias de despliegue reducen riesgo. Blue/Green permite cambiar tráfico entre ambientes. Canary libera gradualmente a un porcentaje de usuarios. Ambas requieren métricas confiables y rollback.

### Semana 23: Preparación final

El proyecto final debe demostrar diseño, ejecución y operación. ADR, diagramas, runbook y pipeline son tan importantes como el código, porque muestran madurez profesional.

### Semana 24: Presentación y graduación

La presentación final evalúa la capacidad de comunicar arquitectura. Un profesional no solo implementa: explica decisiones, reconoce riesgos, defiende trade-offs y propone mejoras.
