using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.Common.Models
{
    public class Employee
    {
        public Guid employeeId { get; set; }

        /// <summary>
        /// Mã khách hàng
        /// </summary>
        public string employeeCode { get; set; }

        /// <summary>
        /// Tên khách hàng
        /// </summary>
        public string fullName { get; set; }
        
        /// <summary>
        /// Vị trí chức vụ
        /// </summary>
        public string? positionName { get; set; }

        /// <summary>
        /// PHòng ban
        /// </summary>
          public string? departmentName { get; set; }

        /// <summary>
        /// Ngày sinh
        /// </summary>
        public DateTime? dateOfBirth { get; set; }

        /// <summary>
        /// Giới tinh
        /// </summary>
        public int? gender { get; set; }

        /// <summary>
        /// số chứng minh thư 
        /// </summary>
        public string identifyNumber { get; set; }

        /// <summary>
        /// Ngày cấp
        /// </summary>
        public DateTime? dateOfIN { get; set; }

        /// <summary>
        /// Nơi cấp
        /// </summary>
        public string? placeOfIN { get; set; }

        /// <summary>
        /// email
        /// </summary>
        public string email { get; set; }

        /// <summary>
        /// số điện thoại
        /// </summary>
        public string phoneNumber { get; set; }

        /// <summary>
        /// Mã số thuế
        /// </summary>

        public string? taxCode { get; set; }

        /// <summary>
        /// Lương cứng
        /// </summary>
        public string? salary { get; set; }

        /// <summary>
        /// Ngày bắt đầu làm việc
        /// </summary>
        public DateTime? dateOfBeginWork { get; set; }

        /// <summary>
        /// Tình trạng
        /// </summary>
        public int? status { get; set; }

        /// <summary>
        /// Id của vị trí/chức vụ
        /// </summary>
        public Guid? positionId { get; set; }

        /// <summary>
        /// PHòng ban
        /// </summary>
        public Guid? departmentId { get; set; }

        /// <summary>
        /// Tổng số nhân viên 
        /// </summary>
        public int? totalEmployees { get; set; }
        

    }
}
