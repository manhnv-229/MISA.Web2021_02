using MISA.Common.Entities;
using MISA.Common.Enumrations;
using MISA.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Common.Models
{
    public class Customer
    {
        #region Property
        /// <summary>
        /// Khoá chính
        /// </summary>
        public Guid CustomerId { get; set; }

        /// <summary>
        /// Mã khách hàng
        /// </summary>
        [Required("Mã khách hàng", "Mã khách hàng không được phép để trống!")]
        [Duplicated("Mã khách hàng", "Mã khách hàng đã tồn tại trên hệ thống!")]
        public string CustomerCode { get; set; }

        /// <summary>
        /// Họ và tên
        /// </summary>
        [Required("Họ và tên", "Họ và tên không được phép để trống!")]
        public string FullName { get; set; }

        /// <summary>
        /// Ngày sinh
        /// </summary>
        public DateTime DateOfBirth { get; set; }

        /// <summary>
        /// Giới tính
        /// </summary>
        public int Gender { get; set; }

        /// <summary>
        /// Tên gới tính
        /// </summary>
        public string GenderName
        {
            get
            {
                switch (Gender)
                {
                    case (int)MISAGender.Male:
                        return MISA.Common.Properties.Resources.VIE_Gender_Name_Male;
                    case (int)MISAGender.FeMale:
                        return MISA.Common.Properties.Resources.VIE_Gender_Name_Female;
                    default:
                        return MISA.Common.Properties.Resources.VIE_Gender_Name_Other;
                }
            }
        }

        /// <summary>
        /// Số điện thoại
        /// </summary>
        [Required("Số điện thoại", "Số điện thoại không được phép để trống!")]
        [Duplicated("Số điện thoại", "Số điện thoại đã tồn tại trên hệ thống!")]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Địa chỉ email
        /// </summary>
        [Required("Địa chỉ Email", "Địa chỉ Email không được phép để trống!")]
        [Duplicated("Địa chỉ Email", "Địa chỉ Email đã tồn tại trên hệ thống!")]
        public string Email { get; set; }

        /// <summary>
        /// Khóa ngoại
        /// </summary>
        public Guid? CustomerGroupId { get; set; }

        /// <summary>
        /// Tên nhóm khách hàng
        /// </summary>
        public string CustomerGroupName { get; set; }

        /// <summary>
        /// Mã số thẻ thành viên
        /// </summary>
        public string MembercardCode { get; set; }

        /// <summary>
        /// Tên công ty
        /// </summary>
        public string CompanyName { get; set; }

        /// <summary>
        /// Mã số thuế công ty
        /// </summary>
        public string CompanyTaxCode { get; set; }

        /// <summary>
        /// Địa chỉ thường trú
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Ngày tạo
        /// </summary>
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// Người tạo
        /// </summary>
        public string CreatedBy { get; set; }

        /// <summary>
        /// Ngày chỉnh sửa
        /// </summary>
        public DateTime ModifiedDate { get; set; }

        /// <summary>
        /// Người chỉnh sửa
        /// </summary>
        public string ModifiedBy { get; set; }
        #endregion
    }
}
