using Catalog.domain.Entity;

namespace Catalog.adapter.restful.v1.controller.Entity;

/// <summary>
/// Entidad usada por el adaptador (API) que representa un producto en las respuestas y peticiones HTTP.
/// Esta clase corresponde al contrato público expuesto por la API REST.
/// </summary>
public class AdapterProductEntity
{
    /// <summary>
    /// Identificador único del producto expuesto por la API.
    /// </summary>
    public int IdProduct { get; set; }

    /// <summary>
    /// Identificador del vendedor (GUID).
    /// </summary>
    public Guid SellerId { get; set; }

    /// <summary>
    /// Identificador de la subcategoría.
    /// </summary>
    public int SubCategoryId { get; set; }

    /// <summary>
    /// Código SKU único del producto.
    /// </summary>
    public string Sku { get; set; }

    /// <summary>
    /// Nombre del producto que se muestra al cliente de la API.
    /// </summary>
    public string NameProduct { get; set; }

    /// <summary>
    /// Descripción del producto.
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// Precio original del producto.
    /// </summary>
    public decimal Price { get; set; }

    /// <summary>
    /// Precio actual del producto.
    /// </summary>
    public decimal CurrentPrice { get; set; }

    /// <summary>
    /// Cantidad de unidades disponibles en stock.
    /// </summary>
    public int StockQuantity { get; set; }

    /// <summary>
    /// Estado del producto.
    /// </summary>
    public ProductStatus ProductStatus { get; set; } = ProductStatus.Draft;

    /// <summary>
    /// Fecha de creación.
    /// </summary>
    public DateTime CreatedAt { get; set; } = DateTime.Now;

    /// <summary>
    /// Fecha de actualización.
    /// </summary>
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
}