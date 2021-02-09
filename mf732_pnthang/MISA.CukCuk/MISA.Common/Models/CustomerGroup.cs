using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Common.Models
{
    /// <summary>
    /// Nhóm khách hàng
    /// CreatedBy: PNTHANG (06/02/2021)
    /// </summary>
    public class CustomerGroup
    {
        #region Constructor
        #endregion

        #region Method
        #endregion

        #region Property
        /// <summary>
        /// Khóa chính - Id nhóm khách hàng
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
        #endregion
        #region Other
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
        /// Sửa bởi:
        /// </summary>
        public string ModifiedBy { get; set; }
        #endregion
    }
}
