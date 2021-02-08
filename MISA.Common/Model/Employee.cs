using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Common.Model
{
    /// <summary>
    /// Nhân viên
    /// </summary>
    /// CreatedBy: PNVĐ (02/02/2021)
    public class Employee
    {
        #region Contructor

        #endregion

        #region Methods

        #endregion

        #region Properties
        /// <summary>
        /// Khóa chính
        /// </summary>
        public Guid EmployeeId { get; set; }
        /// <summary>
        /// Mã nhân viên
        /// </summary>
        public string EmployeeCode { get; set; }
        /// <summary>
        /// Giới tính
        /// </summary>
        public int? Gender { get; set; }
        /// <summary>
        /// Họ và tên
        /// </summary>
        public string FullName { get; set; }
        /// <summary>
        /// Ngày sinh
        /// </summary>
        public DateTime? DateOfBirth { get; set; }
        /// <summary>
        /// Chứng minh thư
        /// </summary>
        public string IndentifyNumber { get; set; }
        /// <summary>
        /// Nơi cấp CMT
        /// </summary>
        public string ReleaseLocation { get; set; }
        /// <summary>
        /// Ngày cấp CMT
        /// </summary>
        public DateTime? ReleaseDay { get; set; }
        public string Email { get; set; }
        /// <summary>
        /// Số điện thoại
        /// </summary>
        public string PhoneNumber { get; set; }
        /// <summary>
        /// Mức lương cơ bản
        /// </summary>
        public string Salary { get; set; }
        /// <summary>
        /// Ngày gia nhập công ty
        /// </summary>
        public DateTime? JoinDate { get; set; }
        /// <summary>
        /// Tình trạng công việc
        /// </summary>
        public int? StatusJob { get; set; }
        /// <summary>
        /// Mã vị trí của nhân viên
        /// </summary>
        public Guid? EmployeePositionId { get; set; }
        /// <summary>
        /// Mã phòng của ban nhân viên
        /// </summary>
        public Guid? EmployeeDepartmentId { get; set; }
        /// <summary>
        /// Mã số thuế nhân viên
        /// </summary>
        public string EmployeeTaxCode { get; set; }
        #endregion

        #region Others

        #endregion

    }
}
