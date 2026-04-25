using Catalog.domain.Entity;
using Catalog.infrastructure.Entity;

namespace Catalog.infrastructure.Mapper;

/// <summary>
/// Implementación del <see cref="IProductInfrastructureMapper"/> que convierte entre
/// las entidades de infraestructura (ProductEntity) y las entidades de dominio (DomainProductEntity).
/// </summary>
public class ProductInfrastructureMapperImpl : IProductInfrastructureMapper
{
    private static string StatusToDb(ProductStatus v) => v switch
    {
        ProductStatus.Draft      => "DRAFT",
        ProductStatus.Active     => "ACTIVE",
        ProductStatus.Inactive   => "INACTIVE",
        ProductStatus.OutOfStock => "OUT_OF_STOCK",
        ProductStatus.Banned     => "BANNED",
        ProductStatus.Deleted    => "DELETED",
        _                        => "DRAFT"
    };

    private static ProductStatus DbToStatus(string v) => v?.ToUpper() switch
    {
        "DRAFT"        => ProductStatus.Draft,
        "ACTIVE"       => ProductStatus.Active,
        "INACTIVE"     => ProductStatus.Inactive,
        "OUT_OF_STOCK" => ProductStatus.OutOfStock,
        "BANNED"       => ProductStatus.Banned,
        "DELETED"      => ProductStatus.Deleted,
        _              => ProductStatus.Draft
    };
    /// <summary>
    /// Convierte una entidad de dominio a su representación de infraestructura.
    /// </summary>
    /// <param name="domainProduct">Entidad de dominio a convertir.</param>
    /// <returns>Instancia de <see cref="ProductEntity"/> con los campos mapeados.</returns>
    public ProductEntity ToInfrastructureEntity(DomainProductEntity domainProduct)
    {
        return new ProductEntity
        {
            IdProduct = domainProduct.IdProduct,
            SellerId = domainProduct.SellerId,
            SubCategoryId = domainProduct.SubCategoryId,
            Sku = domainProduct.Sku,
            NameProduct = domainProduct.NameProduct,
            Description = domainProduct.Description,
            Price = domainProduct.Price,
            CurrentPrice = domainProduct.CurrentPrice,
            StockQuantity = domainProduct.StockQuantity,
            ProductStatus = StatusToDb(domainProduct.ProductStatus),
            CreatedAt = domainProduct.CreatedAt,
            UpdatedAt = domainProduct.UpdatedAt
        };
    }

    /// <summary>
    /// Convierte una lista de entidades de dominio a una lista de entidades de infraestructura.
    /// </summary>
    /// <param name="domainProductList">Lista de entidades de dominio.</param>
    /// <returns>Lista de <see cref="ProductEntity"/> resultante de la conversión.</returns>
    public List<ProductEntity> ToInfrastructureEntityList(List<DomainProductEntity> domainProductList)
    {
        if (domainProductList.Count() == 0)
        {
            return new List<ProductEntity>();
        }
        else
        {
            return domainProductList.Select(ToInfrastructureEntity).ToList();
        }    }

    /// <summary>
    /// Convierte una entidad de infraestructura a su representación de dominio.
    /// </summary>
    /// <param name="domainProduct">Entidad de infraestructura a convertir.</param>
    /// <returns>Instancia de <see cref="DomainProductEntity"/> con los campos mapeados.</returns>
    public DomainProductEntity ToDomainProductEntity(ProductEntity domainProduct)
    {
        return new DomainProductEntity
        {
            IdProduct = domainProduct.IdProduct,
            SellerId = domainProduct.SellerId,
            SubCategoryId = domainProduct.SubCategoryId,
            Sku = domainProduct.Sku,
            NameProduct = domainProduct.NameProduct,
            Description = domainProduct.Description,
            Price = domainProduct.Price,
            CurrentPrice = domainProduct.CurrentPrice,
            StockQuantity = domainProduct.StockQuantity,
            ProductStatus = DbToStatus(domainProduct.ProductStatus),
            CreatedAt = domainProduct.CreatedAt,
            UpdatedAt = domainProduct.UpdatedAt
        };
    }

    /// <summary>
    /// Convierte una lista de entidades de infraestructura a una lista de entidades de dominio.
    /// </summary>
    /// <param name="productEntities">Lista de entidades de infraestructura.</param>
    /// <returns>Lista de <see cref="DomainProductEntity"/> resultante de la conversión.</returns>
    public List<DomainProductEntity> ToDomainProductEntityList(List<ProductEntity> productEntities)
    {
        
        // Verifica si la lista de entrada es nula para evitar errores.
        if (productEntities.Count() == 0)
        {
            return new List<DomainProductEntity>();
        }
        // Convierte cada ProductEntity a DomainProductEntity y devolvemos la nueva lista.
        return productEntities.Select(p => ToDomainProductEntity(p)).ToList();
    }
}