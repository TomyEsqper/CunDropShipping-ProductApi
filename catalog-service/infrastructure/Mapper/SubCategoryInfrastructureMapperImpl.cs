using Catalog.domain.Entity;
using Catalog.infrastructure.Entity;

namespace Catalog.infrastructure.Mapper;

public class SubCategoryInfrastructureMapperImpl : ISubCategoryInfrastructureMapper
{
    public SubCategoryEntity ToInfrastructureSubCategoryEntity(DomainSubCategoryEntity domainSubCategory)
    {
        return new SubCategoryEntity
        {
            SubCategoryId = domainSubCategory.SubCategoryId,
            NameSubCategory = domainSubCategory.NameSubCategory,
            CategoryId = domainSubCategory.CategoryId
        };
    }

    public List<SubCategoryEntity> ToInfrastructureSubCategoryEntityList(List<DomainSubCategoryEntity> domainSubCategoryList)
    {
        return domainSubCategoryList.Count == 0 ? new List<SubCategoryEntity>() : domainSubCategoryList.Select(ToInfrastructureSubCategoryEntity).ToList();
    }

    public DomainSubCategoryEntity ToDomainSubCategoryEntity(SubCategoryEntity infrastructureEntity)
    {
        return new DomainSubCategoryEntity
        {
            SubCategoryId = infrastructureEntity.SubCategoryId,
            NameSubCategory = infrastructureEntity.NameSubCategory,
            CategoryId = infrastructureEntity.CategoryId
        };
    }

    public List<DomainSubCategoryEntity> ToDomainSubCategoryEntityList(List<SubCategoryEntity> infrastructureEntityList)
    {
        return infrastructureEntityList.Count == 0 ? new List<DomainSubCategoryEntity>() : infrastructureEntityList.Select(ToDomainSubCategoryEntity).ToList();

    }
}