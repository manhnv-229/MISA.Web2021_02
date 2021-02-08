using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.Common.Models
{
    /// <summary>
    /// Model về phòng ban
    /// </summary>
    public class Department
    {
        /// <summary>
        /// Khóa chính của phòng ban
        /// </summary>
        public Guid departmentId { get; set; }

        /// <summary>
        /// Tên phòng ban
        /// </summary>
        public string departmentName { get; set; }

        /// <summary>
        /// Mô tả
        /// </summary>
        public string description { get; set; }

        /// <summary>
        /// Ngày tạo
        /// </summary>
        public DateTime? createdDate { get; set; }

        /// <summary>
        /// Tạo bởi ai
        /// </summary>
        public string creatyBy { get; set; }

        /// <summary>
        /// Ngày sửa gần nhất
        /// </summary>
        public DateTime? modifiedDate { get; set; }

        /// <summary>
        /// Sửa bởi ai
        /// </summary>
        public string modifiedBy { get; set; }
    }
}
