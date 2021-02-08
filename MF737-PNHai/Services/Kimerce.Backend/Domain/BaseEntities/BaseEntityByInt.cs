using System.ComponentModel.DataAnnotations;

namespace Kimerce.Backend.Domain.BaseEntities
{
    /// <summary>
    /// Thực thể chỉ được tạo bởi người dùng
    /// </summary>
    public class BaseEntityByInt : BaseEntityInt
    {
        public int? CreatedBy { get; set; }

        [MaxLength(150)]
        public string CreatedByUserName { get; set; }

        public int? UpdatedBy { get; set; }

        [MaxLength(150)]
        public string UpdatedByUserName { get; set; }
    }
}
