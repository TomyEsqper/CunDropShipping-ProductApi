using Catalog.domain.Entity;

namespace Catalog.application.Service;

public interface ISubCategoryService
{
    List<DomainSubCategoryEntity> GetAllSubCategory();
    
    DomainSubCategoryEntity GetSubCategoryById(int id);

    DomainSubCategoryEntity SaveSubCategory(DomainSubCategoryEntity subCategory);
    
    DomainSubCategoryEntity UpdateSubCategory(int id, DomainSubCategoryEntity subCategory);
    
    DomainSubCategoryEntity DeleteSubCategory(int id);
}