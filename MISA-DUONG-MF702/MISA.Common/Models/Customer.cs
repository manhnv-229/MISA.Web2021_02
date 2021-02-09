using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.Common.Models
{
    public class Customer :BaseModel
    {
        [Required("Mã khách hàng")]
        [CheckDuplidate("Mã khách hàng")]
        [MaxLength("Mã khách hàng", 20, "Khách hàng không được dài quá 20cm nhé baby!")]
        public string CustomerCode { get; set; }

        [Required("Họ và tên")]
        public string FullName { get; set; }
        public int? Gender { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string MemberCardCode { get; set; }
        public string Email { get; set; }

        [Required("Số điện thoại")]
        public string PhoneNumber { get; set; }
        public string CompanyName { get; set; }
        public string CompanyTaxCode { get; set; }
        public string Address { get; set; }
    }
}
