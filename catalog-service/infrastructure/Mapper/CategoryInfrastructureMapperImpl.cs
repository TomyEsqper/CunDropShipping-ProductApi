using Catalog.domain.Entity;
using Catalog.infrastructure.Entity;

namespace Catalog.infrastructure.Mapper;

public class CategoryInfrastructureMapperImpl : ICategoryInfrastructureMapper
{
    public static string StatusToDb(CategoryStatus status) => status switch
    {
        CategoryStatus.Active => "ACTIVE",
        CategoryStatus.Inactive => "INACTIVE",
        CategoryStatus.Deleted => "DELETED",
        _ => "ACTIVE"
    };

    private static CategoryStatus DbToStatus(string status) => status?.ToUpper() switch
    {
        "ACTIVE" => CategoryStatus.Active,
        "INACTIVE" => CategoryStatus.Inactive,
        "DELETED" => CategoryStatus.Deleted,
        _ => CategoryStatus.Active
    };

    public CategoryEntity ToInfrastructureCategoryEntity(DomainCategoryEntity domainCategory)
    {
        return new CategoryEntity
        {
            CategoryId = domainCategory.CategoryId,
            NameCategory = domainCategory.NameCategory,
            ProtectionDays = domainCategory.ProtectionDays,
            CategoryStatus = StatusToDb(domainCategory.CategoryStatus)
        };
    }

    public List<CategoryEntity> ToInfrastructureCategoryEntityList(List<DomainCategoryEntity> domainCategoryList)
    {
        return domainCategoryList.Count == 0 ? new List<CategoryEntity>() : domainCategoryList.Select(ToInfrastructureCategoryEntity).ToList();
    }

    public DomainCategoryEntity ToDomainCategoryEntity(CategoryEntity infrastructureEntity)
    {
        return new DomainCategoryEntity
        {
            CategoryId = infrastructureEntity.CategoryId,
            NameCategory = infrastructureEntity.NameCategory,
            ProtectionDays = infrastructureEntity.ProtectionDays,
            CategoryStatus = DbToStatus(infrastructureEntity.CategoryStatus)
        };
    }

    public List<DomainCategoryEntity> ToDomainCategoryEntityList(List<CategoryEntity> infrastructureEntityList)
    {
        return infrastructureEntityList.Count == 0 ? new List<DomainCategoryEntity>() : infrastructureEntityList.Select(ToDomainCategoryEntity).ToList();
    }
}