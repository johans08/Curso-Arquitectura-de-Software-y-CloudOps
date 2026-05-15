# Proyecto final del curso

## Nombre

Arquitectura Cloud automatizada para una aplicación .NET

## Objetivo

Entregar una solución completa donde una aplicación .NET con SQL Server o base administrada se pueda construir, contenerizar, desplegar, monitorear y evolucionar mediante prácticas DevOps.

## Alcance mínimo

- Código fuente de API y frontend.
- Dockerfile optimizado.
- Manifiestos Kubernetes o diseño equivalente si no se ejecuta clúster.
- Terraform para infraestructura mínima.
- Pipeline CI/CD en GitHub Actions o CodePipeline.
- Estrategia de despliegue Blue/Green o Canary.
- Documentación de arquitectura, seguridad, costos y operación.
- Runbook operativo.

## Estructura esperada del repositorio final

```text
.
├── README.md
├── docs/
│   ├── arquitectura.md
│   ├── seguridad.md
│   ├── costos.md
│   ├── runbook.md
│   └── decisiones-adr.md
├── src/
├── database/
├── docker/
├── k8s/
├── terraform/
└── .github/workflows/
```

## Presentación final

Duración sugerida:

- 10 a 12 minutos de presentación.
- 5 minutos de demo.
- 5 minutos de preguntas.

## Rúbrica

| Criterio | Ponderación |
|---|---:|
| Arquitectura de software y nube | 25% |
| Automatización e IaC | 20% |
| CI/CD y estrategia de despliegue | 20% |
| Seguridad, observabilidad y costos | 20% |
| Documentación y presentación | 15% |
