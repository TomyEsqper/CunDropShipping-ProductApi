using Catalog.domain.Entity;

namespace Catalog.application.Service;

public interface ICategoryService
{
    Task<List<DomainCategoryEntity>> GetAllCategoryAsync();
    
    Task<DomainCategoryEntity?> GetCategoryByIdAsync(int id);
    
    Task<DomainCategoryEntity> SaveCategoryAsync(DomainCategoryEntity category);
    
    Task<DomainCategoryEntity?> UpdateCategoryAsync(int id, DomainCategoryEntity category);
    
    Task<DomainCategoryEntity?> DeleteCategoryAsync(int id);
}