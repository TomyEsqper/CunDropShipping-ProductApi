using Catalog.application.Service;
using Catalog.domain.Entity;
using Catalog.infrastructure.DbContext;

namespace Catalog.domain;

public class CategoryServiceImp : ICategoryService
{
    public readonly CategoryRepository _categoryRepository;

    public CategoryServiceImp(CategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }
    
    public async Task<List<DomainCategoryEntity>> GetAllCategoryAsync()
    {
        return await _categoryRepository.GetAllCategoryAsync();
    }

    public async Task<DomainCategoryEntity?> GetCategoryByIdAsync(int id)
    {
        return await _categoryRepository.GetCategoryByIdAsync(id);
    }

    public async Task<DomainCategoryEntity> SaveCategoryAsync(DomainCategoryEntity category)
    {
        return await _categoryRepository.SaveCategoryAsync(category);
    }

    public async Task<DomainCategoryEntity?> UpdateCategoryAsync(int id, DomainCategoryEntity category)
    {
        return await _categoryRepository.UpdateCategoryAsync(id, category);
    }

    public async Task<DomainCategoryEntity?> DeleteCategoryAsync(int id)
    {
        return await _categoryRepository.DeleteCategoryAsync(id);
    }
}