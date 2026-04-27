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
    
    public async Task<List<DomainSubCategoryEntity>> GetAllSubCategoryAsync()
    {
        return await _subCategoryRepository.GetAllSubCategoryAsync();
    }

    public async Task<DomainSubCategoryEntity?> GetSubCategoryByIdAsync(int id)
    {
        return await _subCategoryRepository.GetSubCategoryByIdAsync(id);
    }

    public async Task<DomainSubCategoryEntity> SaveSubCategoryAsync(DomainSubCategoryEntity subCategory)
    {
        return await _subCategoryRepository.SaveSubCategoryAsync(subCategory);
    }

    public async Task<DomainSubCategoryEntity?> UpdateSubCategoryAsync(int id, DomainSubCategoryEntity subCategory)
    {
        return await _subCategoryRepository.UpdateSubCategoryAsync(id, subCategory);
    }

    public async Task<DomainSubCategoryEntity?> DeleteSubCategoryAsync(int id)
    {
        return await _subCategoryRepository.DeleteSubCategoryAsync(id);
    }
}
