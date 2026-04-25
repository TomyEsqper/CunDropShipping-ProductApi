using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Catalog.infrastructure.Entity;

[Table("Subcategories")]
public class SubCategoryEntity
{
    [Key]
    [Column("subCategoryId")]
    public int SubCategoryId { get; set; }
    
    [Required]
    [StringLength(50)]
    [Column("nameSubCategory")]
    public string NameSubCategory { get; set; }
    
    [Required]
    [Column("categoryId")]
    public int CategoryId { get; set; }
    
}