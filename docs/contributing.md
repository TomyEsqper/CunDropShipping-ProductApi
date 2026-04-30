# Contribucion

## Ramas

Usa el estilo de ramas que ya existe en el repositorio:

- `main`
- `Develop`
- `feature/*`
- `task/*`
- `docs/*`

Regla recomendada:

- cambios funcionales en ramas `feature/*` o `task/*`
- cambios solo de documentacion en ramas `docs/*`

## Commits

Usa Conventional Commits.

Ejemplos:

- `feat(catalog): add category status states`
- `fix(product): return 404 for missing entity`
- `docs(readme): reorganize project documentation`

Intenta que cada commit tenga un solo objetivo claro.

## Pull Requests

Antes de abrir un PR:

- verifica que la rama destino sea la correcta
- resume que cambio
- lista como lo verificaste
- menciona si hubo impacto de configuracion

Si cambias comportamiento de la API:

- incluye ejemplos de request/response
- menciona los endpoints afectados

## Regla para Documentacion

Mantén la documentacion separada por proposito:

- `README.md` para entrada rapida y navegacion
- `docs/architecture.md` para reglas de arquitectura
- `docs/project-structure.md` para responsabilidades de carpetas
- `docs/api-overview.md` para guia de endpoints

Evita meter explicaciones largas de arquitectura dentro del `README.md`.

## Seguridad de Configuracion

No confirmes credenciales reales.

Prefiere variables de entorno para valores sensibles, especialmente:

- `ConnectionStrings__DefaultConnection`

Cualquier cambio a `catalog-service/appsettings.json` debe revisarse con cuidado antes de merge.
