# Certificación Profesional en Arquitectura de Software y Cloud Ops

Repositorio oficial de clase para una certificación práctica de **6 meses**, diseñada para formar profesionales capaces de diseñar, construir, documentar, proteger, desplegar y operar soluciones modernas con **.NET, arquitectura de software y prácticas Cloud Ops**.

> Duración total: **24 sesiones sincrónicas**  
> Frecuencia sugerida: **1 sesión semanal**  
> Duración por sesión: **1h30**  
> Modalidad: **clase práctica paso a paso + tarea desde cero**  
> Enfoque: **arquitectura aplicada, laboratorios guiados, evidencias en GitHub y proyecto integrador**

---

## Objetivo general

Al finalizar el curso, el estudiante podrá diseñar y construir aplicaciones backend modernas con .NET, aplicar patrones de arquitectura, documentar APIs profesionales, integrar seguridad con JWT/OAuth2, usar estrategias de datos SQL/NoSQL, comprender comunicación asíncrona y preparar soluciones para operación en entornos cloud.

---

## Perfil del estudiante

Este curso está diseñado para estudiantes o profesionales con bases de programación que desean avanzar hacia roles como:

- Software Developer .NET
- Backend Developer
- Software Architect Junior / Semi Senior
- Cloud Engineer Junior
- DevOps / Cloud Ops Associate
- Integration Engineer
- Technical Lead en formación

---

## Requisitos técnicos

Instalar antes de iniciar el curso:

| Herramienta | Uso en el curso |
|---|---|
| .NET SDK 10 o superior | Desarrollo de APIs, servicios y laboratorios backend |
| Visual Studio Code o Visual Studio | Editor principal |
| Git | Control de versiones y entregas |
| Docker Desktop | Contenedores, RabbitMQ, bases de datos y laboratorios Cloud Ops |
| Postman, Insomnia o REST Client | Pruebas de APIs |
| Node.js LTS | Frontend moderno en el laboratorio integrador |
| SQL Server, SQLite o contenedor SQL | Prácticas de bases de datos |

> Nota: si el estudiante usa .NET 8 LTS, puede adaptar los proyectos cambiando `net10.0` por `net8.0` en los archivos `.csproj`.

---

## Metodología de clase

Cada semana contiene material listo para impartir una sesión de 1h30:

1. **Teoría resumida y visual**  
   Conceptos clave, diagramas Mermaid/ASCII, ejemplos y criterios de decisión.

2. **Laboratorio guiado en clase**  
   Paso a paso para construir una solución .NET desde una plantilla base.

3. **Tarea desde cero**  
   Ejercicio independiente para reforzar lo aprendido.

4. **Evidencia en GitHub**  
   El estudiante entrega código, README técnico, capturas de pruebas y reflexión.

5. **Proyecto integrador por módulo**  
   Al final de cada módulo se consolida el aprendizaje en una solución completa.

---

## Cómo usar este repositorio

```bash
# 1. Clonar el repositorio
git clone <url-del-repositorio>
cd Arquitectura-Software-CloudOps

# 2. Entrar a la semana correspondiente
cd Modulo1/Semana1

# 3. Leer el README de la semana
# 4. Ejecutar el laboratorio guiado
# 5. Resolver la tarea desde cero
# 6. Subir evidencia a GitHub
```

Cada carpeta semanal incluye:

```text
SemanaX/
├── README.md              # Guía completa de clase
├── src/                   # Plantilla/laboratorio .NET
├── diagrams/              # Diagramas Mermaid o ASCII
└── tarea/                 # Enunciado o guía de entrega
```

---

## Cronograma general de 6 meses

| Mes | Semana | Módulo | Tema |
|---:|---:|---|---|
| 1 | 1 | Módulo 1 | Principios SOLID y Clean Code aplicados a entornos web |
| 1 | 2 | Módulo 1 | Patrones de diseño esenciales: creacionales y estructurales |
| 1 | 3 | Módulo 1 | Arquitectura monolítica vs microservicios |
| 1 | 4 | Módulo 1 | Diseño y documentación de APIs profesionales con Swagger/OpenAPI |
| 2 | 5 | Módulo 1 | Comunicación asíncrona y patrones de mensajería |
| 2 | 6 | Módulo 1 | Estrategias de bases de datos: SQL vs NoSQL |
| 2 | 7 | Módulo 1 | Seguridad en el diseño: OAuth2 y JWT |
| 2 | 8 | Módulo 1 | Laboratorio integrador backend + frontend moderno |
| 3 | 9 | Módulo 2 | Docker para aplicaciones .NET |
| 3 | 10 | Módulo 2 | CI/CD con GitHub Actions |
| 3 | 11 | Módulo 2 | Introducción a Kubernetes y orquestación |
| 3 | 12 | Módulo 2 | Configuración, secretos y despliegues por ambiente |
| 4 | 13 | Módulo 2 | Infraestructura como código y fundamentos de Terraform |
| 4 | 14 | Módulo 2 | Observabilidad: logs, métricas y trazas |
| 4 | 15 | Módulo 2 | Resiliencia: retry, circuit breaker, timeout y bulkhead |
| 4 | 16 | Módulo 2 | Proyecto integrador Cloud Native |
| 5 | 17 | Módulo 3 | SRE, SLIs, SLOs y error budgets |
| 5 | 18 | Módulo 3 | Seguridad operacional y hardening cloud |
| 5 | 19 | Módulo 3 | FinOps y optimización de costos |
| 5 | 20 | Módulo 3 | Alta disponibilidad y recuperación ante desastres |
| 6 | 21 | Módulo 3 | Well-Architected Framework aplicado |
| 6 | 22 | Módulo 3 | Arquitectura de integraciones empresariales |
| 6 | 23 | Módulo 3 | Preparación de proyecto final y revisión técnica |
| 6 | 24 | Módulo 3 | Defensa final, retroalimentación y plan profesional |

---

## Evaluación sugerida

| Componente | Peso |
|---|---:|
| Laboratorios guiados completados | 30% |
| Tareas semanales | 30% |
| Proyecto integrador del módulo | 30% |
| Participación, documentación y buenas prácticas Git | 10% |

---

## Estructura generada para los primeros 2 meses

```text
Modulo1/
├── Semana1/  # SOLID y Clean Code
├── Semana2/  # Patrones de diseño
├── Semana3/  # Monolito vs Microservicios
├── Semana4/  # APIs profesionales con Swagger
├── Semana5/  # Comunicación asíncrona
├── Semana6/  # SQL vs NoSQL
├── Semana7/  # OAuth2 y JWT
├── Semana8/  # Integrador backend + frontend
└── ProyectoIntegrador/
```

---

## Convenciones de entrega

Cada estudiante debe crear una rama por semana:

```bash
git checkout -b semana-01-solid-clean-code
git add .
git commit -m "Semana 01: laboratorio SOLID y Clean Code"
git push origin semana-01-solid-clean-code
```

Cada entrega debe incluir:

- Código funcional.
- README propio con explicación técnica.
- Capturas o ejemplos de requests/responses.
- Reflexión: qué aprendí, qué mejoraría, qué decisión arquitectónica tomé.

---

## Recursos transversales

- Documentación oficial .NET: https://learn.microsoft.com/dotnet/
- ASP.NET Core: https://learn.microsoft.com/aspnet/core/
- Entity Framework Core: https://learn.microsoft.com/ef/core/
- Arquitectura de microservicios en .NET: https://learn.microsoft.com/dotnet/architecture/microservices/
- Mejores prácticas REST API en Azure Architecture Center: https://learn.microsoft.com/azure/architecture/best-practices/api-design
- OWASP API Security Top 10: https://owasp.org/API-Security/
- RabbitMQ tutorials for .NET: https://www.rabbitmq.com/tutorials/tutorial-one-dotnet
- OAuth 2.0 RFC 6749: https://datatracker.ietf.org/doc/html/rfc6749
