using Catalog.application.Service;
using Catalog.domain.Entity;
using Catalog.infrastructure.DbContext;
using Catalog.infrastructure.Mapper;

namespace Catalog.domain;


public class ProductServiceImp : IProductService
{

    private readonly ProductRepository _productRepository;


    public ProductServiceImp(ProductRepository productRepository)
    {
        _productRepository = productRepository;
    }


    public List<DomainProductEntity> GetAllProducts()
    {
        return _productRepository.GetAllProducts();
    }


    public DomainProductEntity GetProductById(int id)
    {
        return _productRepository.GetProductById(id);
    }


    public DomainProductEntity SaveProduct(DomainProductEntity product)
    {
        return _productRepository.SaveProduct(product);
    }

    
    public DomainProductEntity UpdateProduct(int id, DomainProductEntity product)
    {
        return _productRepository.UpdateProduct(id, product);
    }


    public DomainProductEntity DeleteProduct(int idProduct)
    {
        var product = _productRepository.GetProductById(idProduct);
        
        _productRepository.DeleteProduct(idProduct);

        return product;
    }


    public List<DomainProductEntity> SearchProductsByName(string searchTerm)
    {
        return _productRepository.SearchProductsByName(searchTerm);
    }


    public List<DomainProductEntity> FilterProductsByPriceRange(decimal minPrice, decimal maxPrice)
    {
        return _productRepository.FilterProductsByPriceRange(minPrice, maxPrice);
    }


    public List<DomainProductEntity> GetProductsWithLowStock(int stockThreshold)
    {
        return _productRepository.GetProductsWithLowStock(stockThreshold);
    }
}