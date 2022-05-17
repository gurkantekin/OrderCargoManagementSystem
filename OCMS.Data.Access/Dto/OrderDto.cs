using System;

namespace OCMS.Data.Access.Dto
{
    public class OrderDto
    {
        public string ProductCode { get; set; }
        public int ShippingProviderId { get; set; }
        public int StatusId { get; set; }
        public double ProductPrice { get; set; }
        public double Quantity { get; set; }
        public double DiscountAmount { get; set; }
        public double SubTotalWithDiscount { get; set; }
        public double ShippingFeeAmount { get; set; }
        public double TaxAmount { get; set; }
        public double OrderTotal { get; set; }
        public double SubTotal { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
