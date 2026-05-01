# Arquitectura

## Modelo por Capas

El servicio sigue una estructura de cuatro capas con limites claros apoyados por mapeadores:

1. `adapter`
2. `application`
3. `domain`
4. `infrastructure`

Cada capa tiene una responsabilidad concreta.

## Responsabilidades

### Adapter

Ubicacion: `catalog-service/adapter/restful/v1/controller/`

Responsabilidades:

- exponer endpoints HTTP
- recibir y devolver DTOs de la API
- mapear DTOs hacia entidades de dominio y viceversa
- traducir resultados de servicios en respuestas HTTP

Ejemplos:

- `ProductController`
- `SubCategoryController`
- `ProductAdapterMapper`
- `AdapterProductEntity`

### Application

Ubicacion: `catalog-service/application/Service/`

Responsabilidades:

- definir contratos de servicio usados por los controladores
- separar los controladores de las implementaciones concretas

Ejemplos:

- `IProductService`
- `ISubCategoryService`

### Domain

Ubicacion: `catalog-service/domain/`

Responsabilidades:

- contener entidades orientadas al negocio
- coordinar casos de uso
- validar precondiciones de negocio antes de persistir

Ejemplos:

- `DomainProductEntity`
- `DomainSubCategoryEntity`
- `ProductServiceImp`
- `SubCategoryServiceImp`

Regla actual importante:

- un producto debe referenciar una subcategoria existente antes de guardarse o actualizarse

### Infrastructure

Ubicacion: `catalog-service/infrastructure/`

Responsabilidades:

- acceso a base de datos con Entity Framework Core
- entidades acopladas a persistencia
- mapeo entre entidades de persistencia y entidades de dominio

Ejemplos:

- `AppDbContext`
- `ProductRepository`
- `SubCategoryRepository`
- `ProductEntity`
- `SubCategoryEntity`

## Flujo de una Peticion

Flujo tipico para operaciones de producto:

1. `ProductController` recibe la solicitud HTTP.
2. `ProductAdapterMapper` convierte el DTO de la API en `DomainProductEntity`.
3. Se invoca `IProductService` a traves de `ProductServiceImp`.
4. `ProductServiceImp` valida el contexto de negocio necesario, incluyendo la existencia de la subcategoria.
5. `ProductRepository` consulta o persiste usando `AppDbContext`.
6. `ProductInfrastructureMapperImpl` convierte entidades de infraestructura en entidades de dominio.
7. `ProductAdapterMapper` convierte el resultado otra vez a DTO de API.
8. El controlador retorna la respuesta HTTP.

## Direccion de Dependencias

La direccion esperada de dependencias apunta hacia contratos y entidades del dominio:

- `adapter` depende de tipos de `application` y `domain`
- `domain` depende de contratos de aplicacion y del uso de repositorios
- `infrastructure` depende de entidades de dominio para mapear

Reglas practicas para este repo:

- mantener los controladores delgados
- dejar las validaciones de negocio en `domain/`
- dejar las preocupaciones de EF Core en `infrastructure/`
- mantener la conversion de modelos dentro de mapeadores, no en los controladores

## Inyeccion de Dependencias

Los registros estan definidos en [`catalog-service/Program.cs`](../catalog-service/Program.cs).

Actualmente se registran:

- repositorios como servicios scoped
- mapeadores de infraestructura como servicios scoped
- mapeadores del adaptador como servicios scoped
- interfaces de aplicacion enlazadas a implementaciones del dominio
- `AppDbContext` con proveedor MySQL

## Serializacion

`Program.cs` configura la serializacion JSON para emitir valores enum como texto usando `JsonStringEnumConverter`.

Eso afecta respuestas de la API como los estados de producto.
