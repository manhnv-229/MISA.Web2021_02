using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Common.Model
{
    /// <summary>
    /// Class Nhóm khách hàng
    /// </summary>
    /// CreatedBy : NMDAT (02/02/2021)
    public class CustomerGroup
    {
        #region Contructor
        #endregion

        #region Property
        /// <summary>
        /// Khóa chính của nhóm khách hàng (Có thể null)
        /// </summary>
        public Guid? CustomerGroupId { get; set; }
        /// <summary>
        /// Tên nhóm khách hàng
        /// </summary>
        public string CustomerGroupName { get; set; }
        /// <summary>
        /// Mô tả nhóm khách hàng
        /// </summary>
        public string Description { get; set; }
        #endregion

        #region Method
        #endregion

        #region Other
        /// <summary>
        /// Ngày tạo
        /// </summary>
        public DateTime? CreatedDate { get; set; }
        /// <summary>
        /// Người tạo
        /// </summary>
        public string CreatedBy { get; set; }
        /// <summary>
        /// Ngày sửa
        /// </summary>
        public DateTime? ModifiedDate { get; set; }
        /// <summary>
        /// Người sửa
        /// </summary>
        public string ModifiedBy { get; set; }
        #endregion
    }
}
