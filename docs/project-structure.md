# Estructura del Proyecto

## Raiz

- `catalog-service.sln`: punto de entrada de la solucion
- `global.json`: version fijada del SDK de .NET
- `compose.yaml`: archivo de orquestacion de contenedores
- `README.md`: guia rapida e indice de documentacion
- `docs/`: documentacion detallada del proyecto

## Aplicacion Principal

Proyecto principal: `catalog-service/`

Archivos importantes:

- `Program.cs`: configuracion de DI, middleware, Swagger y proveedor de base de datos
- `appsettings.json`: configuracion de ejecucion
- `catalog-service.csproj`: definicion del proyecto
- `Catalog-Service.http`: ejemplos locales para pruebas manuales
- `Properties/launchSettings.json`: perfiles de ejecucion local

## Capas

### `catalog-service/adapter/restful/v1/controller/`

Proposito:

- punto de entrada HTTP publico para la API v1

Contiene:

- controladores
- DTOs del adaptador dentro de `Entity/`
- mapeadores del adaptador dentro de `Mapper/`

Controladores actuales:

- `ProductController`
- `SubCategoryController`

### `catalog-service/application/Service/`

Proposito:

- interfaces de servicio usadas por los controladores

Contratos actuales:

- `IProductService`
- `ISubCategoryService`

### `catalog-service/domain/`

Proposito:

- implementaciones de servicios orientadas al negocio

Contiene:

- `ProductServiceImp`
- `SubCategoryServiceImp`
- entidades del dominio dentro de `Entity/`

Entidades actuales:

- `DomainProductEntity`
- `DomainSubCategoryEntity`

### `catalog-service/infrastructure/`

Proposito:

- persistencia y mapeo de datos

Subareas:

- `DbContext/`: contexto EF Core y repositorios
- `Entity/`: entidades orientadas a base de datos
- `Mapper/`: conversion entre infraestructura y dominio

Repositorios actuales:

- `ProductRepository`
- `SubCategoryRepository`

## Organizacion por Feature

El codigo esta organizado por capa tecnica y no por carpetas de feature.

Eso significa que un concepto como `Product` se reparte entre:

- controlador
- DTO del adaptador
- mapeador del adaptador
- interfaz de servicio
- servicio de dominio
- entidad de dominio
- repositorio
- entidad de infraestructura
- mapeador de infraestructura

Esa estructura es coherente con la arquitectura actual y conviene mantenerla salvo que el equipo decida un refactor mayor.

## Donde Cambiar Cada Cosa

- agregar o modificar endpoints: `adapter/restful/v1/controller/`
- cambiar modelos de request/response: `adapter/.../Entity/`
- cambiar conversion API/dominio: `adapter/.../Mapper/`
- agregar reglas de negocio: `domain/`
- agregar contratos de servicio: `application/Service/`
- cambiar consultas a base de datos: `infrastructure/DbContext/`
- cambiar mapeo de persistencia: `infrastructure/Mapper/`
- cambiar forma de entidades de BD: `infrastructure/Entity/`

## Areas Actuales

Actualmente la API expone dos areas principales:

- `products`
- `subcategories`

Las operaciones de producto ya dependen de la existencia de una subcategoria valida en los flujos de crear y actualizar.
