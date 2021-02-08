using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.BTL.Common
{
    public class Customer
    {
        //Id khách hàng
        public Guid CustomerId { get; set; }
        public string Id
        {
            get
            {
                return CustomerId.ToString();
            }
        }

        //Mã nhân viên
        public string CustomerCode { get; set; }

        //Họ và tên
        public string FullName { get; set; }

        //Mã thẻ thành viên
        public string MemberCardCode { get; set; }

        //Id nhóm khách hàng
        public Guid CustomerGroupId { get; set; }
        public string IdCustomerGroup
        {
            get
            {
                return CustomerGroupId.ToString();
            }
        }

        //Ngày sinh
        public DateTime? DateOfBirth { get; set; }

        //Giới tính
        public int Gender { get; set; }

        //Email
        public string Email { get; set; }

        //Số điện thoại
        public string PhoneNumber { get; set; }

        //Tên công ty
        public string CompanyName { get; set; }

        //Địa chỉ
        public string Address { get; set; }

        //Mã số thuế
        public string CompanyTaxCode { get; set; }
    }
}
