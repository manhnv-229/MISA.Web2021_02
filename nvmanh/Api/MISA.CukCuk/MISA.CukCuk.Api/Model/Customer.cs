using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.CukCuk.Api.Model
{
    /// <summary>
    /// Khách hàng
    /// CreatedBy: NVMANH (01/02/2021)
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
        public string CustomerCode { get; set; }

        /// <summary>
        /// Họ và tên
        /// </summary>
        public string FullName { get; set; }
        public string MemberCardCode { get; set; }
        public Guid? CustomerGroupId { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public int? Gender { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string CompanyName { get; set; }
        public string CompanyTaxCode { get; set; }
        public string Address { get; set; }
        #endregion

        #region Other
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        #endregion
    }
}
