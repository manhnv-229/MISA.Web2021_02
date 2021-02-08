using System;
using System.Collections.Generic;
using System.Text;

namespace MisaCukCuk_Entity.Models
{
    public class Customer
    {
        /// <summary>
        /// Id khách hàng
        /// CreateBy: MinhHq(08/02/2021)
        /// </summary>
        public Guid CustomerId { get; set; }
        public string Id
        {
            get
            {
                return CustomerId.ToString();
            }
        }
        /// <summary>
        /// Mã khách hàng
        /// CreateBy: MinhHq(08/02/2021)
        /// </summary>
        public string CustomerCode { get; set; }
        /// <summary>
        /// Tên khách hàng
        /// CreateBy: MinhHq(08/02/2021)
        /// </summary>
        public string FullName { get; set; }
        /// <summary>
        /// Mã thẻ thành viên
        /// CreateBy: MinhHq(08/02/2021)
        /// </summary>
        public string MemberCartCode { get; set; }
        /// <summary>
        /// Nhóm khách hàng
        /// CreateBy: MinhHq(08/02/2021)
        /// </summary>
        public Guid? CustomerGroupId { get; set; }
        /// <summary>
        /// Ngày sinh
        /// CreateBy: MinhHq(08/02/2021)
        /// </summary>
        public DateTime? DateOfBirth { get; set; }
        /// <summary>
        /// Email khách hàng
        /// CreateBy: MinhHq(08/02/2021)
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// Số điện thoại khách hàng
        /// CreateBy: MinhHq(08/02/2021)
        /// </summary>
        public string PhoneNumber { get; set; }
        /// <summary>
        /// Giới tính
        /// CreateBy: MinhHq(08/02/2021)
        /// </summary>
        public int Gender { get; set; }
        /// <summary>
        /// Tên công ty
        /// CreateBy: MinhHq(08/02/2021)
        /// </summary>
        public string CompanyName { get; set; }
        /// <summary>
        /// Mã số thuế công ty
        /// CreateBy: MinhHq(08/02/2021)
        /// </summary>
        public string CompanyTextCode { get; set; }
        /// <summary>
        /// Địa chỉ
        /// CreateBy: MinhHq(08/02/2021)
        /// </summary>
        public string Address { get; set; }
    }
}
