using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Catalog.infrastructure.Entity;

[Table("Products")]
/// <summary>
/// Representa la entidad de infraestructura que mapea la tabla de base de datos "Products".
/// Contiene las propiedades que corresponden a las columnas de la tabla.
/// </summary>
public class ProductEntity
{
    /// <summary>
    /// Identificador primario de la entidad en la base de datos.
    /// </summary>
    [Key]
    [Column("productId")]
    public int IdProduct { get; set; }

    /// <summary>
    /// Identificador del vendedor (GUID).
    /// </summary>
    [Required]
    [Column("sellerId")]
    public Guid SellerId { get; set; }

    /// <summary>
    /// Identificador de la subcategoría.
    /// </summary>
    [Required]
    [Column("subCategoryId")]
    public int SubCategoryId { get; set; }

    /// <summary>
    /// Código SKU único del producto.
    /// </summary>
    [Required]
    [StringLength(50)]
    [Column("SKU")]
    public string Sku { get; set; }

    /// <summary>
    /// Nombre del producto.
    /// </summary>
    [Required]
    [StringLength(200)]
    [Column("name")]
    public string NameProduct { get; set; }

    /// <summary>
    /// Descripción del producto.
    /// </summary>
    [Required]
    [Column("description")]
    public string Description { get; set; }

    /// <summary>
    /// Cantidad disponible en stock.
    /// </summary>
    [Required]
    [Column("stockQuantity")]
    public int StockQuantity { get; set; }

    /// <summary>
    /// Precio original del producto.
    /// </summary>
    [Required]
    [Column("price", TypeName = "decimal(10,2)")]
    public decimal Price { get; set; }

    /// <summary>
    /// Precio actual del producto.
    /// </summary>
    [Required]
    [Column("currentPrice", TypeName = "decimal(10,2)")]
    public decimal CurrentPrice { get; set; }

    /// <summary>
    /// Estado del producto.
    /// </summary>
    [Required]
    [Column("productStatus")]
    public string ProductStatus { get; set; } = "DRAFT";

    /// <summary>
    /// Fecha de creación.
    /// </summary>
    [Column("createdAt")]
    public DateTime CreatedAt { get; set; } = DateTime.Now;

    /// <summary>
    /// Fecha de actualización.
    /// </summary>
    [Column("updatedAt")]
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
}