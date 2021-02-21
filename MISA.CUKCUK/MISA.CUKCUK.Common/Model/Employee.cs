using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Common.Model
{
    class Employee
    {
        /// <summary>
        /// ID nhẫn viên
        /// </summary>
        public Guid EmployeeID { get; set; }
        /// <summary>
        /// Mã nhân viên
        /// </summary>
        public string EmployeeCode { get; set; }
        /// <summary>
        /// Họ và tên
        /// </summary>
        public string FullName { get; set; }
        /// <summary>
        /// Ngày sinh
        /// </summary>
        public string DateOfBirth { get; set; }
        /// <summary>
        /// Giới tính
        /// </summary>
        public int? Gender { get; set; }
        /// <summary>
        /// Số CMT/CCCD
        /// </summary>
        public string IdentityCode { get; set; }
        /// <summary>
        /// Ngày cấp CMT/CCCD
        /// </summary>
        public DateTime? IdentityIssuedDate { get; set; }
        /// <summary>
        /// Nơi cấp CMT
        /// </summary>
        public string IdentityIssuedPlace { get; set; }
        /// <summary>
        /// Email
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// Số điện thoại
        /// </summary>
        public string PhoneNumber { get; set; }
        /// <summary>
        /// Vị trí
        /// </summary>
        public int Position { get; set; }
        /// <summary>
        /// Phòng ban
        /// </summary>
        public int Department { get; set; }
        /// <summary>
        /// Mã số thuế
        /// </summary>
        public string TaxCode { get; set; }
        /// <summary>
        /// Ngày tham gia
        /// </summary>
        public DateTime? JoinDate { get; set; }
        /// <summary>
        /// Lương cơ bản
        /// </summary>
        public int Salary { get; set; }
        /// <summary>
        /// Trạng thái làm việc
        /// </summary>
        public int StatusJob { get; set; }
        /// <summary>
        /// Ngày tạo
        /// </summary>
        public DateTime? CreatedDate { get; set; }
        /// <summary>
        /// Người tạo
        /// </summary>
        public string CreatedBy { get; set; }
        /// <summary>
        /// Người chỉnh sửa
        /// </summary>
        public string ModifiedBy { get; set; }
    }
}
