using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.CukCuk.MF734.PVTHANG.Common.Models
{
    public class Customer
    {
        public Guid CustomerId { get; set; }
        public String CustomerId_ { get { return CustomerId.ToString(); } }

        [Required("Mã khách hàng")]
        [CheckDuplicate("Mã khách hàng")]
        public String CustomerCode { get; set; }

        [Required("Họ và tên")]
        public String FullName { get; set; }
        public int? Gender { get; set; }
        public String GenderName
        {
            get
            {
                switch (Gender)
                {
                    case 0: return "Nam";
                    case 1: return "Nữ";
                    case 2: return "Khác";
                    default: return "Không xác định";
                }
            }
        }
        public DateTime? DateOfBirth { get; set; }
        public String Email { get; set; }

        [Required("Số điện thoại")]
        public String PhoneNumber { get; set; }
        public Guid CustomerGroupId { get; set; }
        public String CustomerGroupId_ { get { return CustomerGroupId.ToString(); } }
        public String CompanyName { get; set; }
        public String CompanyTaxCode { get; set; }
        public String CustomerGroupName { get; set; }
        public String Address { get; set; }
        public String MemberCardCode { get; set; }
    }
}
