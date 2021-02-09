using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Common
{
    public class Employee
    {
        /// <summary>
        /// Id Nhân viên
        /// </summary>
        public Guid EmployeeId { get; set; }
        /// <summary>
        /// Mã nhân viên
        /// </summary>
        public string EmployeeCode { get; set; }
        /// <summary>
        /// Họ và tên
        /// </summary>
        public string FullName { get; set; }
        /// <summary>
        /// Giới tính: 0=> Nữ; 1 => Nam
        /// </summary>
        public int? Gender { get; set; }
        /// <summary>
        /// Ngày sinh
        /// </summary>
        public DateTime? DateOfBirth { get; set; }
        /// <summary>
        /// Số điện thoại
        /// </summary>
        public string PhoneNumber { get; set; }
        /// <summary>
        /// email
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// Phòng Ban Id
        /// </summary>
        public Guid? OfficeId { get; set; }
        /// <summary>
        /// Vị trí Id
        /// </summary>
        public Guid? PositionId { get; set; }
        /// <summary>
        /// Tiền lương
        /// </summary>
        public int? Salary { get; set; }
        /// <summary>
        /// Trạng thái công việc: 0 => đã nghỉ việc; 1 => đang thử việc; 2 => đang làm việc
        /// </summary>
        public int? StatusWork { get; set; }
        /// <summary>
        /// chứng minh thư nhân dân
        /// </summary>
        public string CMTND { get; set; }
        /// <summary>
        /// Ngày cấp chứng minh thư nhân dân
        /// </summary>
        public DateTime? CMTNDDate { get; set; }
        /// <summary>
        /// Nơi cấp chứng minh thư nhân dân
        /// </summary>
        public string CMTNDPlace { get; set; }
        /// <summary>
        /// Mã số thuế cá nhân
        /// </summary>
        public string PersonalTaxCode { get; set; }
        /// <summary>
        /// Ngày bắt đầu làm việc
        /// </summary>
        public DateTime? DateStartWork { get; set; }
    }
}
