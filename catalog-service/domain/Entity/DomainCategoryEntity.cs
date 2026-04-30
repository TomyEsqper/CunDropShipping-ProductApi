namespace Catalog.domain.Entity;

public class DomainCategoryEntity
{
    public int CategoryId { get; set; }
    
    public string NameCategory { get; set; }
    
    public int ProtectionDays { get; set; }
    
    public CategoryStatus CategoryStatus { get; set; } = CategoryStatus.Active;
}

public enum CategoryStatus
{
    Active,
    Inactive,
    Deleted
}
