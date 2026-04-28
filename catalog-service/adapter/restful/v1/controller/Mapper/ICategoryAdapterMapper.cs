using Catalog.adapter.restful.v1.controller.Entity;
using Catalog.domain.Entity;

namespace Catalog.adapter.restful.v1.controller.Mapper;

public interface ICategoryAdapterMapper
{
    AdapterCategoryEntity ToAdapterCategory(DomainCategoryEntity domainCategory);
    
    List<AdapterCategoryEntity> ToAdapterCategoryList(List<DomainCategoryEntity> domainCategoryList);
    
    DomainCategoryEntity ToDomainCategory(AdapterCategoryEntity adapterCategory);
    
    List<DomainCategoryEntity> ToDomainCategoryList(List<AdapterCategoryEntity> adapterCategoryList);
}