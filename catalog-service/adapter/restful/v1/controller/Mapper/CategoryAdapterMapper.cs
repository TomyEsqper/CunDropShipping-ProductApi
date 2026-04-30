using Catalog.adapter.restful.v1.controller.Entity;
using Catalog.domain.Entity;

namespace Catalog.adapter.restful.v1.controller.Mapper;

public class CategoryAdapterMapper : ICategoryAdapterMapper
{
    public AdapterCategoryEntity ToAdapterCategory(DomainCategoryEntity domainCategory)
    {
        return new AdapterCategoryEntity
        {
            CategoryId = domainCategory.CategoryId,
            NameCategory = domainCategory.NameCategory,
            ProtectionDays = domainCategory.ProtectionDays,
            CategoryStatus = domainCategory.CategoryStatus
        };
        
    }

    public List<AdapterCategoryEntity> ToAdapterCategoryList(List<DomainCategoryEntity> domainCategoryList)
    {
        return domainCategoryList.Count == 0 ? new List<AdapterCategoryEntity>() : domainCategoryList.Select(ToAdapterCategory).ToList();
    }

    public DomainCategoryEntity ToDomainCategory(AdapterCategoryEntity adapterCategory)
    {
        return new DomainCategoryEntity
        {
            CategoryId = adapterCategory.CategoryId,
            NameCategory = adapterCategory.NameCategory,
            ProtectionDays = adapterCategory.ProtectionDays,
            CategoryStatus = adapterCategory.CategoryStatus
        };
    }

    public List<DomainCategoryEntity> ToDomainCategoryList(List<AdapterCategoryEntity> adapterCategoryList)
    {
        return adapterCategoryList.Count == 0 ? new List<DomainCategoryEntity>() : adapterCategoryList.Select(ToDomainCategory).ToList();
    }
}