using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.Common.Model
{
    /// <summary>
    /// Khách hàng
    /// </summary>
    public class Customer
    {
        #region Constuctor

        #endregion
        #region Method

        #endregion
        #region Properties
        /// <summary>
        /// Khóa chính
        /// </summary>
        public Guid CustomerId { get; set; }
        /// <summary>
        /// Mã khách hàng
        /// </summary>
        public string CustomerCode { get; set; }
        /// <summary>
        /// Họ và tên
        /// </summary>
        public string FullName { get; set; }
        /// <summary>
        /// Mã thẻ thành viên
        /// </summary>
        public string MemberCardCode { get; set; }
        /// <summary>
        /// Mã nhóm khách hàng
        /// </summary>
        public Guid? CustomerGroupId { get; set; }
        /// <summary>
        /// Ngày sinh
        /// </summary>
        public DateTime? DateOfBirth { get; set; }
        /// <summary>
        /// Giới tính
        /// </summary>
        public int? Gender { get; set; }
        /// <summary>
        /// Email khách hàng
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// Số điện thoại
        /// </summary>
        public string PhoneNumber { get; set; }
        /// <summary>
        /// Tên công ty
        /// </summary>
        public string CompanyName { get; set; }

        public string CompanyTaxCode { get; set; }
        public string Address { get; set; }
        #endregion

        #region Other
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        #endregion
    }
}
