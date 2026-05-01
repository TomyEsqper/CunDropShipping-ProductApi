# Resumen de la API

## Convenciones Base

- prefijo de version: `/api/v1`
- Swagger UI habilitado en `Development`
- los enums JSON se serializan como texto

## Endpoints de Productos

Ruta base: `/api/v1/products`

### `GET /api/v1/products`

Devuelve todos los productos.

### `GET /api/v1/products/{id}`

Devuelve un producto por identificador.

Comportamiento:

- retorna `404` cuando el producto no existe

### `POST /api/v1/products`

Crea un producto.

Comportamiento:

- valida que la subcategoria referenciada exista
- retorna `201 Created` con `Location` apuntando al recurso creado

### `PUT /api/v1/products/{id}`

Actualiza un producto existente.

Comportamiento:

- valida que la subcategoria referenciada exista
- retorna `404` cuando el producto no existe

### `DELETE /api/v1/products/{id}`

Elimina un producto.

Comportamiento:

- retorna `404` cuando el producto no existe
- retorna el payload del producto eliminado cuando tiene exito

### `GET /api/v1/products/search?searchTerm={valor}`

Busca productos por nombre usando una consulta `Contains`.

### `GET /api/v1/products/filter/price?minPrice={min}&maxPrice={max}`

Filtra productos cuyo precio esta dentro del rango enviado.

### `GET /api/v1/products/filter/stock?stockThreshold={valor}`

Devuelve productos cuyo stock es menor o igual al umbral enviado.

## Endpoints de Subcategorias

Ruta base: `/api/v1/subcategories`

### `GET /api/v1/subcategories`

Devuelve todas las subcategorias ordenadas por nombre.

### `GET /api/v1/subcategories/{id}`

Devuelve una subcategoria por identificador.

Comportamiento:

- retorna `404` cuando la subcategoria no existe

### `POST /api/v1/subcategories`

Crea una subcategoria y retorna `201 Created`.

### `PUT /api/v1/subcategories/{id}`

Actualiza una subcategoria existente.

Comportamiento:

- retorna `404` cuando la subcategoria no existe

### `DELETE /api/v1/subcategories/{id}`

Elimina una subcategoria.

Comportamiento:

- retorna `204 No Content` cuando tiene exito
- retorna `404` cuando la subcategoria no existe

## Modelos Principales

Los modelos publicos actuales estan definidos en:

- `catalog-service/adapter/restful/v1/controller/Entity/AdapterProductEntity.cs`
- `catalog-service/adapter/restful/v1/controller/Entity/AdapterSubCategoryEntity.cs`

El flujo actual de productos incluye:

- identificadores del producto
- identificador del seller
- referencia a subcategoria
- SKU
- campos descriptivos
- campos de precio
- cantidad de stock
- estado del producto
- timestamps

## Notas para Consumidores

- las respuestas de productos incluyen la subcategoria relacionada cuando la lectura del repositorio la trae cargada
- los enums se devuelven como texto, no como numero
- las rutas definidas actualmente en controladores usan nombres en minuscula
