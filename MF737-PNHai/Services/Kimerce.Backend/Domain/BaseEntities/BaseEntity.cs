using System;


namespace Kimerce.Backend.Domain.BaseEntities
{
    /// <summary>
    /// Thực thể chung
    /// </summary>
    public class BaseEntity
    {
        /// <summary>
        /// Ngày tạo
        /// </summary>
        public DateTimeOffset? CreatedTime { get; set; }

        /// <summary>
        /// Ngày cập nhật
        /// </summary>
        public DateTimeOffset? UpdatedTime { get; set; }

        ///// <summary>
        ///// Thực thể đã bị xóa hay chưa?
        ///// </summary>
        //public bool IsDeleted { get; set; }
        public bool IsDeleted { get; set; }
    }
}
