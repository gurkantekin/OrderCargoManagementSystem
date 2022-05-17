using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OCMS.Data.Access.Entity
{
    [Table("Product", Schema = "dbo")]
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string ProductCode { get; set; }

        [Display(Name = "Name")]
        public string Name { get; set; }

        [ForeignKey("ProductCategory")]
        [Required]
        [Display(Name = "CategoryId")]
        public string CategoryId { get; set; }
    }
}
