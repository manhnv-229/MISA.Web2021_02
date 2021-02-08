using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CukCuk.Common.Models
{
    /// <summary>
    /// Nhóm khách hàng
    /// </summary>
    /// CreatedBy: DMThanh (06/02/2021)
    public class CustomerGroup
    {
        #region Properties
        /// <summary>
        /// Khoá chính
        /// </summary>
        public Guid CustomerGroupId { get; set; }
        /// <summary>
        /// Tên nhóm khách hàng
        /// </summary>
        public string CustomerGroupName { get; set; }
        /// <summary>
        /// Thông tin
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Ngày tạo
        /// </summary>
        public DateTime? CreatedDate { get; set; }
        /// <summary>
        /// Tạo bởi
        /// </summary>
        public string CreatedBy { get; set; }
        /// <summary>
        /// Ngày sửa
        /// </summary>
        public DateTime? ModifiedDate { get; set; }
        /// <summary>
        /// Người sửa s
        /// </summary>
        public string ModifiedBy { get; set; }
        #endregion
    }
}
