namespace Catalog.domain.Entity;

public class DomainCategoryEntity
{
    public int CategoryId { get; set; }
    
    public string NameCategory { get; set; }
    
    public int protectionDays { get; set; }
    
    public string DescriptionCategory { get; set; }
}