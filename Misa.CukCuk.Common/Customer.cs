using System;
using System.Collections.Generic;
using System.Text;

namespace Misa.CukCuk.Common
{
    public class Customer
    {
        /// <summary>
        /// ID khách hàng
        /// </summary>
        public Guid CustomerId { get; set; }
        /// <summary>
        /// Mã khách hàng
        /// </summary>
        public string CustomerCode { get; set; }
        /// <summary>
        /// Tên đầy đủ
        /// </summary>
        public string FullName { get; set; }
        /// <summary>
        /// Giới tính
        /// </summary>
        public int? Gender { get; set; }
        /// <summary>
        /// Mã thẻ thành viên
        /// </summary>
        public string MemberCardCode { get; set; }
        /// <summary>
        /// Mã id nhóm khách hàng
        /// </summary>
        public Guid CustomerGroupId { get; set; }
        /// <summary>
        /// Địa chỉ
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// Ngày tháng năm sinh
        /// </summary>
        public DateTime? DateOfBirth { get; set; }
        /// <summary>
        /// Email liên lạc
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// số điện thoại liên lạc
        /// </summary>
        public string PhoneNumber { get; set; }
        /// <summary>
        /// tên công ty
        /// </summary>
        public string CompanyName { get; set; }
        /// <summary>
        /// mã thuế công ty
        /// </summary>
        public string CompanyTaxCode { get; set; }
        /// <summary>
        /// Ngày tạo
        /// </summary>
        public DateTime? CreatedDate { get; set; }
        /// <summary>
        /// Người tạo bản ghi
        /// </summary>
        public string CreatedBy { get; set; }
        /// <summary>
        /// ngày chỉnh sửa gần nhất
        /// </summary>
        public DateTime? ModifiedDate { get; set; }
        /// <summary>
        /// người chỉnh sửa cuối cùng
        /// </summary>
        public string ModifiedBy { get; set; }


       
    }
}
