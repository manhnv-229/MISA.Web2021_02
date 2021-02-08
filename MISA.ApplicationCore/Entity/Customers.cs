using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.ApplicationCore.Entity
{
    /// <summary>
    /// Khách hàng
    /// CreatedBy: BDHieu (07/02/2021)
    /// </summary>
    public class Customers
    {
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
        /// Mã thẻ thành viên
        /// </summary>
        public string MemberCardCode { get; set; }
        /// <summary>
        /// Khóa ngoại với bảng nhóm khách hàng
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
        /// <summary>
        /// Mã số thuế công ty
        /// </summary>
        public string CompanyTaxCode { get; set; }
        /// <summary>
        /// Địa chỉ
        /// </summary>
        public string Address { get; set; }
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
        #endregion
    }
}
