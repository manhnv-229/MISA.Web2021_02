using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.Common.Model
{
    /// <summary>
    /// Khách hàng
    /// CreatedBy: NhHung (04/02/2020)
    /// </summary>
    public class Customer
    {
        #region Constructor
        #endregion

        #region Method
        #endregion

        #region Property
        /// <summary>
        /// Khóa chính
        /// </summary>
        public Guid CustomerId { get; set; }
        /// <summary>
        /// Mã khách hàng
        /// </summary>
        public string CustomerCode { get; set; }
        /// <summary>
        /// Tên khách hàng
        /// </summary>
        public string FullName { get; set; }
        /// <summary>
        /// Mã thẻ khách hàng
        /// </summary>
        public string MemberCardCode { get; set; }
        /// <summary>
        /// Mã nhóm khách hàng
        /// </summary>
        public Guid? CustomerGroupId { get; set; }
        /// <summary>
        /// Ngày sinh khách hàng
        /// </summary>
        public DateTime? DateOfBirth { get; set; }
        /// <summary>
        /// Giới tính: 0 là "nữ", 1 là "nam"
        /// </summary>
        public int? Gender { get; set; }
        public string Email { get; set; }
        /// <summary>
        /// Điện thoại khách hàng
        /// </summary>
        public string PhoneNumber { get; set; }
        /// <summary>
        /// Tên công ty
        /// </summary>
        public string CompanyName { get; set; }
        /// <summary>
        /// Mã số thuế công ty
        /// </summary>
        public string CompanyTaxCode { get; set; }
        /// <summary>
        /// Địa chỉ khách hàng
        /// </summary>
        public string Address { get; set; }
        #endregion
        #region others
        /// <summary>
        /// Ngày tạo khách hàng
        /// </summary>
        public DateTime CreatedDate { get; set; }
        /// <summary>
        /// Người tạo
        /// </summary>
        public string CreatedBy { get; set; }
        /// <summary>
        /// Ngày sửa thông tin khách hàng
        /// </summary>
        public DateTime? ModifiedDate { get; set; }
        /// <summary>
        /// Người sửa thông tin khách hàng
        /// </summary>
        public string ModifiedBy { get; set; }
        #endregion
    }
}
