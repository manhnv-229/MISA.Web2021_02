using System;
using System.Collections.Generic;
using System.Text;

namespace Misa.CukCuk.Common
{
    public class Employee
    {
        /// <summary>
        /// Mã id nhân viên
        /// </summary>
        public Guid EmployeeId { get; set; }
        /// <summary>
        /// Mã code nhân viên
        /// </summary>
        public string EmployeeCode { get; set; }
        /// <summary>
        /// tên đầy đủ nhân viên
        /// </summary>
        public string FullName { get; set; }
        /// <summary>
        /// ngày tháng năm sinh của nhân viên
        /// </summary>
        public DateTime? DateOfBirth { get; set; }
        /// <summary>
        /// giới tính nhân viên
        /// </summary>
        public int? Gender { get; set; }

        /// <summary>
        /// số chứng minh nhân dân
        /// </summary>
        public string IdentityCard { get; set; }
        /// <summary>
        /// ngày cấp chứng minh nhân dân
        /// </summary>
        public DateTime? IdentityDate { get; set; }
        /// <summary>
        /// nơi cấp chứng minh nhân dân
        /// </summary>
        public string IdentityLocation { get; set; }
        /// <summary>
        /// email liên hệ
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// số điện thoại liên hệ
        /// </summary>
        public string PhoneNumber { get; set; }
        /// <summary>
        /// mã vị trí của nhân viên
        /// </summary>
        public Guid PositionGroupId { get; set; }
        /// <summary>
        /// mã phòng ban của nhân viên
        /// </summary>
        public Guid DepartmentId { get; set; }
        /// <summary>
        /// mã thuế cá nhân
        /// </summary>
        public string PersonalTaxCode { get; set; }
        /// <summary>
        /// mức lương cơ bản
        /// </summary>
        public string BasicSalary { get; set; }
        /// <summary>
        /// ngày tham gia công ty
        /// </summary>
        public DateTime? JoiningDate { get; set; }
        /// <summary>
        /// trạng thái làm việc
        /// </summary>
        public int? Status { get; set; }
        /// <summary>
        /// ngày tạo bản ghi
        /// </summary>
        public DateTime? CreatedDate { get; set; }
        /// <summary>
        /// người tạo bản ghi
        /// </summary>
        public string CreatedBy { get; set; }
        /// <summary>
        /// ngày chỉnh sửa gần nhất
        /// </summary>
        public DateTime? ModifiedDate { get; set; }
        /// <summary>
        /// người chỉnh sửa bản gần nhất
        /// </summary>
        public string ModifiedBy { get; set; }
        /// <summary>
        /// Tên vị trí nhân viên đang làm việc
        /// </summary>
        public string PositionName { get; set; }
        /// <summary>
        /// Tên phòng ban nhân viên đang làm việc
        /// </summary>
        public string DepartmentName { get; set; }

    }
}
