using System;
using System.Collections.Generic;
using System.Text;

namespace CukCuk.Common.Models
{
    /// <summary>
    /// Khách hàng
    /// CreatedBy: DMThanh (06/02/2021)
    /// </summary>
    public class Customer
    {
       #region Properties
        /// <summary>
        /// Khoá chính
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
        /// Khoá ngoài
        /// </summary>
        public Guid CustomerGroupId { get; set; }
        /// <summary>
        /// Ngày sinh
        /// </summary>
        public DateTime DateOfBirth { get; set; }
        /// <summary>
        /// Giới tính
        /// </summary>
        public int Gender { get; set; }
        /// <summary>
        /// Email
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// Sô điện thoại
        /// </summary>
        public string PhoneNumber { get; set; }
        /// <summary>
        /// Tên công ty
        /// </summary>
        public string CompanyName { get; set; }
        /// <summary>
        /// Mã số thuế
        /// </summary>
        public string CompanyTaxCode { get; set; }
        /// <summary>
        /// Địa chỉ
        /// </summary>
        public string Address { get; set; }
      
        #endregion

        #region Other
        /// <summary>
        /// Ngày tạo
        /// </summary>
        public DateTime? CreatedDate { get; set; }
        /// <summary>
        /// Ngày sửa
        /// </summary>
        public DateTime? ModifiedDate { get; set; }
        /// <summary>
        /// Người tạo
        /// </summary>
        public string CreatedBy { get; set; }
        /// <summary>
        /// Người sửa
        /// </summary>
        public string ModifiedBy { get; set; }
        #endregion
    }
}
