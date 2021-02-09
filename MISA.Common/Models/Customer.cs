
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Common.Models
{
    public class Customer
    {
        #region Properties
        /// <summary>
        /// Id 
        /// </summary>
        public Guid CustomerId { get; set; }
        /// <summary>
        /// Họ và tên
        /// </summary>
        public string FullName { get; set; }
        // Id
        public string Id
        {
            get
            {
                return CustomerId.ToString();
            }
        }
        /// <summary>
        /// Mã khách hàng
        /// </summary>
        [Required("Mã khách hàng", "Bạn phải nhập thông tin mã khách hàng")]
        [CheckDuplicate("Mã khách hàng","Mã khách hàng không được phép trùng")]
        public String CustomerCode { get; set; }
        public string Email { get; set; }
        /// <summary>
        /// Giới tính
        /// </summary>
        public int? Genner { get; set; }
        /// <summary>
        /// Ngày sinh
        /// </summary>
        public DateTime? DateOfBirth { get; set; }
        /// <summary>
        /// Số điện thoại
        /// </summary>
        [Required("Số điện thoại", "Bạn phải nhập số điện thoại")]
        [MaxLength("Số điện thoại",10,"Số điện thoại không được phép vượt quá 10 ký tự")]
        public string PhoneNumber { get; set; }
        #endregion
    }
}
