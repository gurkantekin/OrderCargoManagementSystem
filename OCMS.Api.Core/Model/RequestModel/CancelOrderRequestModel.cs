using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OCMS.Api.Core.Model.RequestModel
{
    public class CancelOrderRequestModel
    {
        [Required]
        public int Id { get; set; }

        public string Descipriton { get; set; }
    }
}
