using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.Common.Models
{
    public class Customer
    {
        #region
        /// <summary>
        /// Khóa chính
        /// </summary>
        public Guid CustomerId { get; set; }

        /// <summary>
        /// Mã khách hàng
        /// </summary>
        [Required("Mã khách hàng", "Bạn phải nhập mã KH")]
        [CheckDuplicate("Mã khách hàng", "Mã khách hàng đã tồn tại!")]
        [MaxLength("Mã khách hàng", 20)]
        public string CustomerCode { get; set; }

        /// <summary>
        /// Họ tên khách hàng
        /// </summary>
        [Required("Họ Tên khách hàng", "Bạn phải nhập tên KH")]
        public string FullName { get; set; }

        /// <summary>
        /// Mã thẻ thành viên
        /// </summary>
        public string MemberCard { get; set; }

        /// <summary>
        /// Mã nhóm khách hàng
        /// </summary>
        public Guid CustomerGroupID { get; set; }
        
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
        /// Số điện thoại khách hàng
        /// </summary>
        [Required("Số điện thoại khách hàng", "Bạn phải nhập sđt KH")]
        [CheckDuplicate("Số điện thoại khách hàng", "Số điện thoại đã tồn tại!")]
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

        /// <summary>
        /// Ngày tạo
        /// </summary>
        public DateTime? CreateDate { get; set; }

        /// <summary>
        /// Người tạo
        /// </summary>
        public string CreateBy { get; set; }

        /// <summary>
        /// Ngày chỉnh sửa
        /// </summary>
        public DateTime? ModifyDate { get; set; }

        /// <summary>
        /// Người chỉnh sửa
        /// </summary>
        public string ModifyBy { get; set; }

        #endregion
    }
}
