using Catalog.domain.Entity;
using Catalog.infrastructure.Mapper;
using Microsoft.EntityFrameworkCore;

namespace Catalog.infrastructure.DbContext;

public class ProductRepository
{
    private readonly AppDbContext _context;
    private readonly IProductInfrastructureMapper _mapper;
    
    public ProductRepository(AppDbContext context, IProductInfrastructureMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<DomainProductEntity>> GetAllProductsAsync()
    {
        var productEntities = await _context.Products
            .AsNoTracking()
            .Include(p => p.SubCategory)
            .ToListAsync(); 
        return _mapper.ToDomainProductEntityList(productEntities);
    }

    public async Task<DomainProductEntity?> GetProductByIdAsync(int id)
    {
        var product = await _context.Products
            .Include(p => p.SubCategory)
            .FirstOrDefaultAsync(p => p.IdProduct == id);
        return _mapper.ToDomainProductEntity(product);
    }

    public async Task<DomainProductEntity> SaveProductAsync(DomainProductEntity domainProduct)
    {
        var infraProduct = _mapper.ToInfrastructureEntity(domainProduct);
        await _context.Products.AddAsync(infraProduct);
        await _context.SaveChangesAsync();
        domainProduct.IdProduct = infraProduct.IdProduct;
        return domainProduct;
    }

    public async Task<DomainProductEntity?> UpdateProductAsync(int id, DomainProductEntity domainProduct)
    {
        var existingEntity = await _context.Products.FindAsync(id);
        if (existingEntity == null) return null;

        existingEntity.NameProduct = domainProduct.NameProduct;
        existingEntity.Description = domainProduct.Description;
        existingEntity.Price = domainProduct.Price;
        existingEntity.StockQuantity = domainProduct.StockQuantity;
        existingEntity.SubCategoryId = domainProduct.SubCategoryId;

        await _context.SaveChangesAsync();
        return domainProduct;
    }

    public async Task<bool> DeleteProductAsync(int idProduct)
    {
        var product = await _context.Products.FindAsync(idProduct);
        if (product == null) return false;
        _context.Products.Remove(product);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<List<DomainProductEntity>> SearchProductsByNameAsync(string searchTerm) =>
        _mapper.ToDomainProductEntityList(await _context.Products
            .AsNoTracking()
            .Include(p => p.SubCategory)
            .Where(p => p.NameProduct.Contains(searchTerm))
            .ToListAsync());

    public async Task<List<DomainProductEntity>> FilterProductsByPriceRangeAsync(decimal min, decimal max) =>
        _mapper.ToDomainProductEntityList(await _context.Products
            .AsNoTracking()
            .Include(p => p.SubCategory)
            .Where(p => p.Price >= min && p.Price <= max)
            .ToListAsync());

    public async Task<List<DomainProductEntity>> GetProductsWithLowStockAsync(int threshold) =>
        _mapper.ToDomainProductEntityList(await _context.Products
            .AsNoTracking()
            .Include(p => p.SubCategory)
            .Where(p => p.StockQuantity <= threshold)
            .ToListAsync());
}
