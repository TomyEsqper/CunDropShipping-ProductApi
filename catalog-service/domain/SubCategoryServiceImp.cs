using Catalog.application.Service;
using Catalog.domain.Entity;
using Catalog.infrastructure.DbContext;

namespace Catalog.domain;

public class SubCategoryServiceImp : ISubCategoryService
{
    public readonly SubCategoryRepository _subCategoryRepository;

    public SubCategoryServiceImp(SubCategoryRepository subCategoryRepository)
    {
        _subCategoryRepository = subCategoryRepository;
    }
    
    public List<DomainSubCategoryEntity> GetAllSubCategory()
    {
        return _subCategoryRepository.GetAllSubCategory();
    }

    public DomainSubCategoryEntity GetSubCategoryById(int id)
    {
        return _subCategoryRepository.GetSubCategoryById(id);
    }

    public DomainSubCategoryEntity SaveSubCategory(DomainSubCategoryEntity subCategory)
    {
        return _subCategoryRepository.SaveSubCategory(subCategory);
    }

    public DomainSubCategoryEntity UpdateSubCategory(int id, DomainSubCategoryEntity subCategory)
    {
        return _subCategoryRepository.UpdateSubCategory(id, subCategory);
    }

    public DomainSubCategoryEntity DeleteSubCategory(int id)
    {
        return _subCategoryRepository.DeleteSubCategory(id);
    }
}