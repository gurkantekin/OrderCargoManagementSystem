using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OCMS.Data.Access.Entity
{
    [Table("Order", Schema = "dbo")]
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("Product")]
        [Required]
        [Display(Name = "ProductCode")]
        public string ProductCode { get; set; }

        [Display(Name = "ProductPrice")]
        [Required]
        public double ProductPrice { get; set; }

        [Display(Name = "Quantity")]
        [Required]
        public double Quantity { get; set; }

        [Required]
        [Display(Name = "DiscountAmount")]
        public double DiscountAmount { get; set; }

        [Display(Name = "SubTotalWithDiscount")]
        public double SubTotalWithDiscount { get; set; }

        [Display(Name = "ShippingFeeAmount")]
        public double ShippingFeeAmount { get; set; }

        [Display(Name = "TaxAmount")]
        public double TaxAmount { get; set; }

        [Required]
        [Display(Name = "OrderTotal")]
        public double OrderTotal { get; set; }

        [Required]
        [Display(Name = "SubTotal")]
        public double SubTotal { get; set; }

        [ForeignKey("ShippingProvider")]
        [Required]
        [Display(Name = "ShippingProviderId")]
        public int ShippingProviderId { get; set; }

        [ForeignKey("OrderStatus")]
        [Display(Name = "StatusId")]
        [Required]
        public int StatusId { get; set; }

        [Display(Name = "CreationDate")]
        public DateTime CreationDate { get; set; }
    }
}
