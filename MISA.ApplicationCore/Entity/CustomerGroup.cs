using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.ApplicationCore.Entity
{
    /// <summary>
    /// Nhóm khách hàng
    /// CreatedBy: BDHieu (07/02/2021)
    /// </summary>
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
        /// Mô tả
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Ngày tạo khách hàng
        /// </summary>
        public DateTime CreatedDate { get; set; }
        /// <summary>
        /// Người tạo khách hàng
        /// </summary>
        public string CreatedBy { get; set; }
        /// <summary>
        /// Ngày cập nhật gần nhất
        /// </summary>
        public DateTime ModifiedDate { get; set; }
        /// <summary>
        /// Người sửa đổi gần nhất
        /// </summary>
        public string ModifiedBy { get; set; }
    }
}
