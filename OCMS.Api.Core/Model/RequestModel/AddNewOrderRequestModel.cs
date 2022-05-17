using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OCMS.Api.Core.Model.RequestModel
{
    public class AddNewOrderRequestModel
    {
        [Required]
        public string ProductCode { get; set; }
        [Required]
        public double ProductPrice { get; set; }
        public int Quantity { get; set; }
        [Required]
        public double DiscountAmount { get; set; }
        [Required]
        public double ShippingFeeAmount { get; set; }
        [Required]
        public double TaxAmount { get; set; }
    }
}
