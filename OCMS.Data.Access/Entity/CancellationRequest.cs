using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OCMS.Data.Access.Entity
{
    [Table("CancellationRequest", Schema = "dbo")]
    public class CancellationRequest
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("Order")]
        [Required]
        [Display(Name = "CategoryId")]
        public int OrderId { get; set; }

        public string Descipriton { get; set; }

        [Required]
        public DateTime CreationTime { get; set; }

        public int CreatorUserId { get; set; }

        public DateTime LastModificationTime { get; set; }

        public int LastModifierUserId { get; set; }
    }
}
