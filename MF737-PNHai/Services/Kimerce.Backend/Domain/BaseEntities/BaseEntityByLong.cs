using System.ComponentModel.DataAnnotations;

namespace Kimerce.Backend.Domain.BaseEntities
{
    public class BaseEntityByLong : BaseEntityLong
    {
        public int? CreatedBy { get; set; }

        [MaxLength(155)]
        public string CreatedByUserName { get; set; }

        public int? UpdatedBy { get; set; }

        [MaxLength(155)]
        public string UpdatedByUserName { get; set; }
    }
}
