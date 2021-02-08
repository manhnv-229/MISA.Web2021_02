using System;
using System.Collections.Generic;
using System.Text;

namespace CukCuk.Common.Models
{
    /// <summary>
    /// Các kiểu dữ liệu của khách Hàng
    /// CreatedBy: QDQuang (06/02/2021)
    /// </summary>
    public class Customer
    {
        public Guid CustomerId { get; set; }
        public string CustomerCode { get; set; }
        public string FullName { get; set; }
        public string MemberCardCode { get; set; }
        public Guid CustomerGroupId { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int Gender { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string CompanyName { get; set; }
        public string CompanyTaxCode { get; set; }
        public string Address { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
    }
}
