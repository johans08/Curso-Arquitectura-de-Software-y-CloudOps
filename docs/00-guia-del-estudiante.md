# Guía del estudiante

## Propósito

Este módulo no busca que el estudiante memorice comandos. Busca que aprenda a tomar decisiones de arquitectura usando un stack controlado:

- .NET
- ASP.NET Core
- Blazor
- Entity Framework Core
- SQL Server

El objetivo es reducir ruido tecnológico. Una vez que el estudiante domina los conceptos, podrá trasladarlos a otras herramientas como Azure, AWS, Kubernetes, Kafka, RabbitMQ, React o Angular.

---

## Cómo leer el material

Cada semana debe estudiarse en este orden:

1. Leer el mapa de aprendizaje.
2. Leer la explicación conceptual.
3. Revisar los diagramas.
4. Revisar los ejemplos de código.
5. Resolver la tarea desde cero.
6. Completar la autoevaluación.
7. Registrar decisiones importantes en formato ADR.

---

## Qué debe entregar el estudiante por semana

Cada semana debe crear una carpeta de entrega con:

```text
entregas/
└── semana-n/
    ├── README.md
    ├── src/
    ├── diagrams/
    ├── adr/
    └── evidencias/
```

El `README.md` de entrega debe responder:

- ¿Qué problema resuelve la solución?
- ¿Qué decisiones arquitectónicas tomé?
- ¿Qué patrón o principio apliqué?
- ¿Qué cambiaría si el sistema creciera?
- ¿Qué riesgos técnicos identifiqué?
- ¿Qué deuda técnica acepté conscientemente?

---

## Criterios generales de evaluación

| Criterio | Peso |
|---|---:|
| Comprensión conceptual | 25% |
| Diseño arquitectónico | 25% |
| Implementación en .NET | 20% |
| Uso correcto de SQL Server | 15% |
| Documentación técnica | 10% |
| Claridad de decisiones | 5% |

---

## Reglas de calidad

El estudiante debe evitar:

- Controladores con lógica de negocio.
- Servicios que hacen demasiadas cosas.
- Entidades sin reglas.
- SQL Server usado solo como almacenamiento sin restricciones.
- APIs sin contrato claro.
- Endpoints que devuelven estructuras improvisadas.
- Seguridad agregada al final.
- Código que solo funciona en el caso feliz.

---

## Mentalidad del módulo

Una arquitectura profesional no es la más compleja.  
Una arquitectura profesional es aquella que:

- Resuelve el problema real.
- Explica sus decisiones.
- Tiene límites claros.
- Permite mantenimiento.
- Permite pruebas.
- Permite evolución.
- No introduce herramientas innecesarias.
