using Catalog.domain.Entity;
using Catalog.infrastructure.Mapper;

namespace Catalog.infrastructure.DbContext;

public class CategoryRepository
{
    private readonly AppDbContext _context;
    private readonly ICategoryInfrastructureMapper _mapper;
    
    public CategoryRepository(AppDbContext context, ICategoryInfrastructureMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<DomainCategoryEntity>> GetAllCategoryAsync()
    {
        return null;
    }
    
    public async Task<DomainCategoryEntity?> GetCategoryByIdAsync(int id)
    {
        return null;
    }

    public async Task<DomainCategoryEntity> SaveCategoryAsync(DomainCategoryEntity category)
    {
        return null;
    }

    public async Task<DomainCategoryEntity> UpdateCategoryAsync(int id, DomainCategoryEntity category)
    {
        return null;
    }

    public async Task<DomainCategoryEntity> DeleteCategoryAsync(int id)
    {
        return null;
    }
}