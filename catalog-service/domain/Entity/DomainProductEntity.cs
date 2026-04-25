namespace Catalog.domain.Entity;

/// <summary>
/// Entidad del dominio que representa un producto dentro de la lógica de negocio.
/// Contiene sólo los campos necesarios para las operaciones de la capa de negocio.
/// </summary>
public class DomainProductEntity
{
    /// <summary>
    /// Identificador primario de la entidad en la base de datos.
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
    /// Nombre del producto.
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
    /// Cantidad disponible en stock.
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

/// <summary>
/// Enum para el estado del producto, mapeado al ENUM de la DB.
/// </summary>
public enum ProductStatus
{
    Draft,
    Active,
    Inactive,
    OutOfStock,
    Banned,
    Deleted
}
