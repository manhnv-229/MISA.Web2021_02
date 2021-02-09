using Common.Other;
using System;

namespace Common.Model
{
    /// <summary>
    /// Khách hàng
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
        [Required("Mã khách hàng")]
        [CheckExist("Mã khách hàng")]
        public string CustomerCode { get; set; }
        /// <summary>
        /// Họ và tên khách hàng
        /// </summary>
        [Required("Tên khách hàng")]
        public string Fullname { get; set; }
        /// <summary>
        /// Số điện thoại khách hàng
        /// </summary>
        [Required("Số điên thoại")]
        [CheckNumberFormat("Số điên thoại")]
        [CheckExist("Số điện thoại")]
        public string PhoneNumber { get; set; }
        /// <summary>
        /// Mã thẻ thành viên
        /// </summary>
        public string MemberCardCode { get; set; }
        /// <summary>
        /// Id nhóm khách hàng
        /// </summary>
        public Guid? CustomerGroupId { get; set; }
        /// <summary>
        /// Ngày sinh
        /// </summary>
        public DateTime? DateOfBirth { get; set; }
        /// <summary>
        /// Giới tính khách hàng (0-Nữ, 1-Nam, 2-Khác)
        /// </summary>
        public int? Gender { get; set; }
        /// <summary>
        /// Địa chỉ thư điện tử
        /// </summary>
        [Required("Thư điên tử/ Email")]
        [CheckEmailFormat("Thư điên tử/ Email")]
        [CheckExist("Thư điện tử/ Email")]
        public string Email { get; set; }
        /// <summary>
        /// Tên công ty
        /// </summary>
        public string CompanyName { get; set; }
        /// <summary>
        /// Mã số thuế công ty
        /// </summary>
        [CheckNumberFormat("Mã số thuế cá nhân")]
        public string CompanyTaxCode { get; set; }
        /// <summary>
        /// Địa chỉ khách hàng
        /// </summary>
        public string Address { get; set; }
        #endregion
        #region Other
        /// <summary>
        /// Ngày tạo bản ghi
        /// </summary>
        public DateTime? CreatedDate { get; set; }
        /// <summary>
        /// Người tạo bản ghi
        /// </summary>
        public string CreatedBy { get; set; }
        /// <summary>
        /// Ngày sửa đổi bản ghi
        /// </summary>
        public DateTime? ModifiedDate { get; set; }
        /// <summary>
        /// Người sửa đổi bản ghi
        /// </summary>
        public string ModifiedBy { get; set; }
        #endregion
    }
}
