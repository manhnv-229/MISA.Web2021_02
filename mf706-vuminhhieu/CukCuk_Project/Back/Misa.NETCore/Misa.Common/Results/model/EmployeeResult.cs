using System;
using System.Collections.Generic;
using System.Text;

namespace Misa.Common.Results.model
{
    public class EmployeeResult
    {
        /// <summary>
        /// Mã nhân viên
        /// </summary>
        public EmployeeResult()
        {
            
        }
        /// <summary>
        /// ID nhân viên
        /// </summary>
        public Guid EmployeeId { get; set; }
        /// <summary>
        /// Mã nhân viên
        /// </summary>       
        public string EmployeeCode { get; set; }

        /// <summary>
        /// Tên đầy đủ
        /// </summary>        
        public string FullName { get; set; }

        /// <summary>
        /// Ngày sinh
        /// </summary>
        public DateTime? DateOfBirth { get; set; }

        /// <summary>
        /// Giới tính
        /// </summary>
        public int? Gender { get; set; }

        /// <summary>
        /// tên giới tính
        /// </summary>
        public string GenderName { get; set; }

        /// <summary>
        /// Số chứng minh thư
        /// </summary>       
        public string IdentityCardNumber { get; set; }

        /// <summary>
        /// Ngày cấp chứng minh thư
        /// </summary>
        public DateTime? IdentityDate { get; set; }

        /// <summary>
        /// Địa chỉ cấp chứng minh thư
        /// </summary>        
        public string IdentityPlace { get; set; }

        /// <summary>
        /// Email
        /// </summary>      
        public string Email { get; set; }

        /// <summary>
        /// Số điện thoại
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Id chức vụ
        /// </summary>
        public Guid PositionId { get; set; }
        //public string PositionName { get; set; }

        /// <summary>
        /// Tên vị trí
        /// </summary>
        public string PositionName { get; set; }

        /// <summary>
        /// Id phòng ban
        /// </summary>
        public Guid DepartmentId { get; set; }

        /// <summary>
        /// Tên phòng ban
        /// </summary>
        public string DepartmentName { get; set; }

        /// <summary>
        /// Mã số thuế
        /// </summary>
        public string TaxCode { get; set; }

        /// <summary>
        /// Mức lương cơ bản
        /// </summary>
        public decimal? Salary { get; set; }

        /// <summary>
        /// Ngày tham gia
        /// </summary>
        public DateTime? DateJoin { get; set; }

        /// <summary>
        /// Mã tình trạng công việc
        /// </summary>
        public int? WorkStatus { get; set; }

        /// <summary>
        /// Tình trạng công việc
        /// </summary>
        public string WorkStatusName { get; set; }
    }
}
