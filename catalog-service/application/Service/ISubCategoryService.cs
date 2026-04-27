using Catalog.domain.Entity;

namespace Catalog.application.Service;

public interface ISubCategoryService
{
    Task<List<DomainSubCategoryEntity>> GetAllSubCategoryAsync();
    
    Task<DomainSubCategoryEntity?> GetSubCategoryByIdAsync(int id);

    Task<DomainSubCategoryEntity> SaveSubCategoryAsync(DomainSubCategoryEntity subCategory);
    
    Task<DomainSubCategoryEntity?> UpdateSubCategoryAsync(int id, DomainSubCategoryEntity subCategory);
    
    Task<DomainSubCategoryEntity?> DeleteSubCategoryAsync(int id);
}
