using System;

namespace OCMS.Data.Access.Dto
{
    public class CancellationRequestDto
    {
        public int OrderId { get; set; }

        public string Descipriton { get; set; }

        public int CreatorUserId { get; set; }
        public DateTime CreationTime { get; set; }

        public DateTime LastModificationTime { get; set; }

        public int LastModifierUserId { get; set; }
    }
}
