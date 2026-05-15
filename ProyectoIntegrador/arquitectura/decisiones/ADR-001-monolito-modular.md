# ADR-001: Usar monolito modular

## Estado

Aceptado

## Contexto

El proyecto integrador necesita enseñar límites de arquitectura sin introducir complejidad operacional.

## Decisión

Se usará un monolito modular en .NET.

## Consecuencias positivas

- Menor complejidad.
- Una sola base de datos.
- Fácil ejecución local.
- Permite practicar límites internos.

## Consecuencias negativas

- No hay despliegue independiente por módulo.
- Escalabilidad separada limitada.
