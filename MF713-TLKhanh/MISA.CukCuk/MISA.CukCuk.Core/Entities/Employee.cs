using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.CukCuk.Core.Entities
{
    public class Employee
    {
        #region Properties
        /// <summary>
        /// ID nhân viên - Khóa chính
        /// </summary>
        public Guid? EmployeeId { get; set; }
        /// <summary>
        /// Mã nhân viên
        /// </summary>
        public string EmployeeCode { get; set; }
        /// <summary>
        /// Địa chỉ Email
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// Số điện thoại
        /// </summary>
        public string PhoneNumber { get; set; }
        /// <summary>
        /// Họ tên nhân viên
        /// </summary>
        public string FullName { get; set; }
        /// <summary>
        /// Giới tính
        /// </summary>
        public int? Gender { get; set; }
        /// <summary>
        /// Ngày sinh
        /// </summary>
        public DateTime? DateOfBirth { get; set; }
        
        /// <summary>
        /// Số chứng minh thư / thẻ căn cước
        /// </summary>
        public string IdentityNumber { get; set; }
        /// <summary>
        /// Ngày cấp chứng minh thư / thẻ căn cước
        /// </summary>
        public DateTime? IdentityDate { get; set; }
        /// <summary>
        /// Nơi cấp chứng minh thư / thẻ căn cước
        /// </summary>
        public string IdentityPlace { get; set; }
        /// <summary>
        /// Khóa ngoài
        /// </summary>
        public Guid? RuleId { get; set; }
        /// <summary>
        /// Quyền nhân viên
        /// </summary>
        public string RuleName { get; set; }
        /// <summary>
        /// khóa ngoài
        /// </summary>
        public Guid? WorkStatusId { get; set; }
        /// <summary>
        /// Tình trạng công việc
        /// </summary>
        public string WorkStatusName { get; set; }

        /// <summary>
        /// Mức lương
        /// </summary>
        public Double? Salary { get; set; }
        #endregion

    }
}
