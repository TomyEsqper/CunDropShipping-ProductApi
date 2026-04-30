using Catalog.domain.Entity;
using Catalog.infrastructure.Entity;

namespace Catalog.infrastructure.Mapper;

public interface ICategoryInfrastructureMapper
{
    CategoryEntity ToInfrastructureCategoryEntity(DomainCategoryEntity domainCategory);
    
    List<CategoryEntity> ToInfrastructureCategoryEntityList(List<DomainCategoryEntity> domainCategoryList);
    
    DomainCategoryEntity ToDomainCategoryEntity(CategoryEntity infrastructureEntity);
    
    List<DomainCategoryEntity> ToDomainCategoryEntityList(List<CategoryEntity> infrastructureEntityList);
}