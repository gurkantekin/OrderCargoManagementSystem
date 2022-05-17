using System;

namespace OCMS.Data.Access.Dto
{
    public class UpdateOrderDto
    {
        public int Id { get; set; }
        public string Descipriton { get; set; }

        public int CreatorUserId { get; set; }
    }
}
