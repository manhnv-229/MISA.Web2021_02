using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.ApplicationCore.Entity
{
    /// <summary>
    /// Nhân viên
    /// CreatedBy: BDHieu (01/02/2021)
    /// </summary>
    public class Employee
    {
        #region Property
        /// <summary>
        /// Khóa chính
        /// </summary>
        public Guid EmployeeId { get; set; }
        /// <summary>
        /// Mã nhân viên
        /// </summary>
        public string EmployeeCode { get; set; }
        /// <summary>
        /// Tên nhân viên
        /// </summary>
        public string FullName { get; set; }
        /// <summary>
        /// Ngày sinh nhân viên
        /// </summary>
        public DateTime DateOfBirth { get; set; }
        /// <summary>
        /// Giới tính nhân viên
        /// </summary>
        public int Gender { get; set; }
        /// <summary>
        /// Số CMTND/ Căn cước
        /// </summary>
        public string IdentifyNumber { get; set; }
        /// <summary>
        /// Ngày cấp CMTND/ Căn cước
        /// </summary>
        public DateTime ReleaseDay { get; set; }
        /// <summary>
        /// Nơi cấp CMTND/ Căn cước
        /// </summary>
        public string ReleaseLocation { get; set; }
        /// <summary>
        /// Email nhân viên
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// Số điện thoại nhân viên
        /// </summary>
        public string PhoneNumber { get; set; }
        /// <summary>
        /// Khóa ngoài với bảng vị trí
        /// </summary>
        public int PositionId { get; set; }
        /// <summary>
        /// Khóa ngoài với bảng phòng ban
        /// </summary>
        public int DepartmentId { get; set; }
        /// <summary>
        /// Mã số thuế
        /// </summary>
        public string TaxNumber { get; set; }
        /// <summary>
        /// Mức lương cơ bản
        /// </summary>
        public string Salary { get; set; }
        /// <summary>
        /// Ngày gia nhập công ty
        /// </summary>
        public DateTime JoinDate { get; set; }
        /// <summary>
        /// Tình trạng công việc
        /// </summary>
        public int StatusJob { get; set; }
        #endregion
    }
}
