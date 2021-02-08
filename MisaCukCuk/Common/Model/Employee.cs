using Common.Other;
using System;

namespace Common.Model
{
    public class Employee
    {
        #region Constructor
        #endregion
        #region Property
        /// <summary>
        /// Khóa chính
        /// </summary>
        public Guid EmployeeId { get; set; }
        /// <summary>
        /// Mã nhân viên
        /// </summary>
        [Required("Mã nhân viên")]
        [CheckExist("Mã nhân viên")]
        public string EmployeeCode { get; set; }
        /// <summary>
        /// Tên nhân viên
        /// </summary>
        [Required("Tên nhân viên")]
        public string FullName { get; set; }
        /// <summary>
        /// Địa chỉ thư điện tử nhân viên
        /// </summary>
        [Required("Thư điên tử/ Email")]
        [CheckEmailFormat("Thư điện tử/ Email")]
        [CheckExist("Thư điện tử/ Email")]

        public string Email { get; set; }
        /// <summary>
        /// Số điện thoại nhân viên
        /// </summary>
        [Required("Số điên thoại")]
        [CheckNumberFormat("Số điện thoại")]
        [CheckExist("Số điện thoại")]

        public string PhoneNumber { get; set; }
        /// <summary>
        /// Giới tính nhân viên
        /// </summary>
        public int? Gender { get; set; }
        /// <summary>
        /// Ngày sinh của nhân viên
        /// </summary>
        public DateTime? DateOfBirth { get; set; }
        /// <summary>
        /// Số chứng minh thư nhân dân/ Căn cước công dân
        /// </summary>
        [Required("Số chứng minh nhân dân/ Căn cước")]
        [CheckNumberFormat("Số chứng minh nhân dân/ Căn cước")]
        public string NationalIdentityCardNumber { get; set; }
        /// <summary>
        /// Ngày cấp chứng minh thư nhân dân / Căn cước công dân
        /// </summary>
        public DateTime? DateOfIssue { get; set; }
        /// <summary>
        /// Nơi cấp chứng minh thư nhân dân / Căn cước công dân
        /// </summary>
        public string PlaceOfIssue { get; set; }
        /// <summary>
        /// Chức vụ nhân viên
        /// </summary>
        public int? Position { get; set; }
        /// <summary>
        /// Bộ phận, phòng ban của nhân viên
        /// </summary>
        public int? Department { get; set; }
        /// <summary>
        /// Mã số thuế cá nhân
        /// </summary>
        [CheckNumberFormat("Mã số thuế cá nhân")]
        public string TaxCode { get; set; }
        /// <summary>
        /// Mức lương cơ bản của nhân viên
        /// </summary>
        public int? Salary { get; set; }
        /// <summary>
        /// Ngày gia nhập công ty
        /// </summary>
        public DateTime? JoinDate { get; set; }
        /// <summary>
        /// Trạng thái công việc của nhân viên
        /// </summary>
        public int? Status { get; set; }
        #endregion
        #region Other
        #endregion
    }
}
