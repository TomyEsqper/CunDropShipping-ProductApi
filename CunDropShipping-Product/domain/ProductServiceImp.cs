using CunDropShipping.application.Service;
using CunDropShipping.domain.Entity;
using CunDropShipping.infrastructure.DbContext;
using CunDropShipping.infrastructure.Mapper;

namespace CunDropShipping.domain;


public class ProductServiceImp : IProductService
{

    private readonly Repository _repository;


    public ProductServiceImp(Repository repository)
    {
        _repository = repository;
    }


    public List<DomainProductEntity> GetAllProducts()
    {
        return _repository.GetAllProducts();
    }


    public DomainProductEntity GetProductById(int id)
    {
        return _repository.GetProductById(id);
    }


    public DomainProductEntity SaveProduct(DomainProductEntity product)
    {
        return _repository.SaveProduct(product);
    }

    
    public DomainProductEntity UpdateProduct(int id, DomainProductEntity product)
    {
        return _repository.UpdateProduct(id, product);
    }


    public DomainProductEntity DeleteProduct(int idProduct)
    {
        var product = _repository.GetProductById(idProduct);
        
        _repository.DeleteProduct(idProduct);

        return product;
    }


    public List<DomainProductEntity> SearchProductsByName(string searchTerm)
    {
        return _repository.SearchProductsByName(searchTerm);
    }


    public List<DomainProductEntity> FilterProductsByPriceRange(decimal minPrice, decimal maxPrice)
    {
        return _repository.FilterProductsByPriceRange(minPrice, maxPrice);
    }


    public List<DomainProductEntity> GetProductsWithLowStock(int stockThreshold)
    {
        return _repository.GetProductsWithLowStock(stockThreshold);
    }
}