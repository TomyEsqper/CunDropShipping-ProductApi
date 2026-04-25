using Catalog.adapter.restful.v1.controller.Entity;
using Catalog.domain.Entity;

namespace Catalog.adapter.restful.v1.controller.Mapper;

public class SubCategoryAdapterMapper : ISubCategoryAdapterMapper
{
    public AdapterSubCategoryEntity ToAdapterSubCategory(DomainSubCategoryEntity domainSubCategory)
    {
        return new AdapterSubCategoryEntity
        {
            SubCategoryId = domainSubCategory.SubCategoryId,
            NameSubCategory = domainSubCategory.NameSubCategory,
            CategoryId = domainSubCategory.CategoryId
        };
    }

    public List<AdapterSubCategoryEntity> ToAdapterSubCategoryList(List<DomainSubCategoryEntity> domainSubCategoryList)
    {
        return domainSubCategoryList.Count == 0 ? new List<AdapterSubCategoryEntity>() : domainSubCategoryList.Select(ToAdapterSubCategory).ToList();
    }

    public DomainSubCategoryEntity ToDomainSubCategory(AdapterSubCategoryEntity adapterSubCategory)
    {
        return new DomainSubCategoryEntity
        {
            SubCategoryId = adapterSubCategory.SubCategoryId,
            NameSubCategory = adapterSubCategory.NameSubCategory,
            CategoryId = adapterSubCategory.CategoryId
        };
    }

    public List<DomainSubCategoryEntity> ToDomainSubCategoryList(List<AdapterSubCategoryEntity> adapterSubCategoryList)
    {
        throw new NotImplementedException();
    }
}