using Catalog.domain.Entity;
using Catalog.infrastructure.Entity;

namespace Catalog.infrastructure.Mapper;

public interface ISubCategoryInfrastructureMapper
{
    SubCategoryEntity ToInfrastructureSubCategoryEntity(DomainSubCategoryEntity domainSubCategory);
    
    List<SubCategoryEntity> ToInfrastructureSubCategoryEntityList(List<DomainSubCategoryEntity> domainSubCategoryList);
    
    DomainSubCategoryEntity ToDomainSubCategoryEntity(SubCategoryEntity infrastructureEntity);
    
    List<DomainSubCategoryEntity> ToDomainSubCategoryEntityList(List<SubCategoryEntity> infrastructureEntityList);
    
}