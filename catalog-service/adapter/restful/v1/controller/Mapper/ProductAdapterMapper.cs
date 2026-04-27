using Catalog.adapter.restful.v1.controller.Entity;
using Catalog.domain.Entity;

namespace Catalog.adapter.restful.v1.controller.Mapper;

/// <summary>
/// Mapper que convierte entre las entidades del dominio (<see cref="DomainProductEntity"/>)
/// y las entidades expuestas por el adaptador/API (<see cref="AdapterProductEntity"/>).
/// </summary>
public class ProductAdapterMapper : IProductAdapterMapper
{
    /// <summary>
    /// Convierte una entidad de dominio a su representación para la API.
    /// </summary>
    /// <param name="domainProduct">Entidad de dominio a convertir.</param>
    /// <returns>Instancia de <see cref="AdapterProductEntity"/> con los campos mapeados.</returns>
    public AdapterProductEntity? ToAdapterProduct(DomainProductEntity? domainProduct)
    {
        if (domainProduct == null)
        {
            return null;
        }

        return new AdapterProductEntity
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
            ProductStatus = domainProduct.ProductStatus,
            CreatedAt = domainProduct.CreatedAt,
            UpdatedAt = domainProduct.UpdatedAt,
            SubCategory = domainProduct.SubCategory == null
                ? null
                : new AdapterSubCategoryEntity
                {
                    SubCategoryId = domainProduct.SubCategory.SubCategoryId,
                    NameSubCategory = domainProduct.SubCategory.NameSubCategory,
                    CategoryId = domainProduct.SubCategory.CategoryId
                }
        };
    }

        /// <summary>
    /// Convierte una lista de entidades de dominio a una lista lista para la API.
    /// </summary>
    /// <param name="domainProducts">Lista de entidades del dominio.</param>
    /// <returns>Lista de <see cref="AdapterProductEntity"/> resultante.</returns>
    public List<AdapterProductEntity> ToAdapterProductList(List<DomainProductEntity> domainProducts)
    {
        return domainProducts.Count == 0
            ? new List<AdapterProductEntity>()
            : domainProducts.Select(domainProduct => ToAdapterProduct(domainProduct)!).ToList();
    }

    /// <summary>
    /// Convierte una entidad del adaptador/API a su representación en el dominio.
    /// </summary>
    /// <param name="adapterProduct">Entidad del adaptador a convertir.</param>
    /// <returns>Instancia de <see cref="DomainProductEntity"/> con los campos mapeados.</returns>
    public DomainProductEntity? ToDomainProduct(AdapterProductEntity? adapterProduct)
    {
        if (adapterProduct == null)
        {
            return null;
        }

        return new DomainProductEntity
        {
            IdProduct = adapterProduct.IdProduct,
            SellerId = adapterProduct.SellerId,
            SubCategoryId = adapterProduct.SubCategoryId,
            Sku = adapterProduct.Sku,
            NameProduct = adapterProduct.NameProduct,
            Description = adapterProduct.Description,
            Price = adapterProduct.Price,
            CurrentPrice = adapterProduct.CurrentPrice,
            StockQuantity = adapterProduct.StockQuantity,
            ProductStatus = adapterProduct.ProductStatus,
            CreatedAt = adapterProduct.CreatedAt,
            UpdatedAt = adapterProduct.UpdatedAt,
            SubCategory = adapterProduct.SubCategory == null
                ? null
                : new DomainSubCategoryEntity
                {
                    SubCategoryId = adapterProduct.SubCategory.SubCategoryId,
                    NameSubCategory = adapterProduct.SubCategory.NameSubCategory,
                    CategoryId = adapterProduct.SubCategory.CategoryId
                }
        };
    }

    /// <summary>
    /// Convierte una lista de entidades del adaptador a una lista de entidades del dominio.
    /// </summary>
    /// <param name="adapterProducts">Lista de entidades del adaptador.</param>
    /// <returns>Lista de <see cref="DomainProductEntity"/> resultante.</returns>
    public List<DomainProductEntity> ToDomainProducts(List<AdapterProductEntity> adapterProducts)
    {
        return adapterProducts.Count == 0
            ? new List<DomainProductEntity>()
            : adapterProducts.Select(adapterProduct => ToDomainProduct(adapterProduct)!).ToList();
    }
}
