namespace Catalog.domain.Entity;

public class DomainCategoryEntity
{
    public int CategoryId { get; set; }
    
    public string NameCategory { get; set; }
    
    public int ProtectionDays { get; set; }
    
    public string CategoryStatus { get; set; }
}