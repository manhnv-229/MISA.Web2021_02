using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.Common.Models
{
    /// <summary>
    /// Model về vị trí/chức vụ
    /// </summary>
    public class Position
    {
        /// <summary>
        /// khóa chính
        /// </summary>
        public Guid positionId { get; set; }

        /// <summary>
        /// Tên vị trí/ chức vụ
        /// </summary>
        public string positionName { get; set; }

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
        /// Ngày chỉnh sửa gần nhất
        /// </summary>
        public DateTime? modifiedDate { get; set; }

        /// <summary>
        /// Chỉnh sửa bởi ai
        /// </summary>
        public string modifiedBy { get; set; }


    }
}
