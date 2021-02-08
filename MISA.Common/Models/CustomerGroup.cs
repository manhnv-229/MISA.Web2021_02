using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.Common.Models
{
    public class CustomerGroup
    {
        /// <summary>
        /// Khóa chính
        /// </summary>
        public Guid CustomerGroupId { get; set; }

        /// <summary>
        /// Tên nhóm khách hàng
        /// </summary>
        public string CustomerGroupName { get; set; }

        /// <summary>
        /// Miêu tả ngắn về nhóm
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Ngày tạo bản ghi
        /// </summary>
        public DateTime? CreateDate { get; set; }

        /// <summary>
        /// Người tạo bản ghi
        /// </summary>
        public string CreateBy { get; set; }

        /// <summary>
        /// Ngày chỉnh sửa bản ghi
        /// </summary>
        public DateTime? ModifyDate { get; set; }

        /// <summary>
        /// Người chỉnh sửa bản ghi
        /// </summary>
        public string ModifyBy { get; set; }
    }
}
