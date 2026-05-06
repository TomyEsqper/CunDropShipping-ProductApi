using Catalog.domain.Entity;

namespace Catalog.adapter.restful.v1.controller.Entity;

public class AdapterCategoryEntity
{
    public int CategoryId { get; set; }
    
    public string NameCategory { get; set; }
    
    public int ProtectionDays { get; set; }
    
    public CategoryStatus CategoryStatus { get; set; } = CategoryStatus.Active;
}