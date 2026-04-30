using Catalog.adapter.restful.v1.controller.Entity;
using Catalog.domain.Entity;

namespace Catalog.adapter.restful.v1.controller.Mapper;

public interface ISubCategoryAdapterMapper
{
    AdapterSubCategoryEntity ToAdapterSubCategory(DomainSubCategoryEntity domainSubCategory);
    
    List<AdapterSubCategoryEntity> ToAdapterSubCategoryList(List<DomainSubCategoryEntity> domainSubCategoryList);
    
    DomainSubCategoryEntity ToDomainSubCategory(AdapterSubCategoryEntity adapterSubCategory);
    
    List<DomainSubCategoryEntity> ToDomainSubCategoryList(List<AdapterSubCategoryEntity> adapterSubCategoryList);
}