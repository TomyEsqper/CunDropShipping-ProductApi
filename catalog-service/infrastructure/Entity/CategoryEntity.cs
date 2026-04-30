using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Catalog.infrastructure.Entity;

[Table("Categories")]
public class CategoryEntity
{
    
    [Key]
    [Column("categoryId")]
    public int CategoryId { get; set; }
    
    [Required]
    [StringLength(100)]
    [Column("name")]
    public string NameCategory { get; set; }
    
    [Column("protectionDays")]
    public int ProtectionDays { get; set; }
    
    [Column("categoryStatus")]
    public string CategoryStatus { get; set; } = "ACTIVE";
}