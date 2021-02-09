using System;

namespace Misa.Common.Entities
{
    public class Employee
    {
        /// <summary>
        /// Mã nhân viên
        /// </summary>
        public Employee()
        {
            EmployeeId = Guid.NewGuid();
        }
        /// <summary>
        /// ID nhân viên
        /// </summary>
        public Guid EmployeeId { get; set; }
        /// <summary>
        /// Mã nhân viên
        /// </summary>
        [Required(errorMessenger: "Mã Nnân viên không được bỏ trống")]
        public string EmployeeCode { get; set; }

        /// <summary>
        /// Tên đầy đủ
        /// </summary>
        [MaxLength(250 ,errorMessenger: "Tên đầy đủ không quá 250 từ")]
        public string FullName { get; set; }

        /// <summary>
        /// Ngày sinh
        /// </summary>
        public DateTime? DateOfBirth { get; set; }

        /// <summary>
        /// Giưới tính
        /// </summary>
        public int? Gender { get; set; }

        /// <summary>
        /// Số chứng minh thư
        /// </summary>
        [Required(errorMessenger: "Chứng minh thư không được bỏ trống")]
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
        [Required("Email không được bỏ trống")]
        public string Email { get; set; }

        /// <summary>
        /// Số điện thoại
        /// </summary>
        [Required(errorMessenger: "Số điện thoại không được bỏ trống")]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Id chức vụ
        /// </summary>
        public Guid PositionId { get; set; }
        //public string PositionName { get; set; }

        /// <summary>
        /// Id phòng ban
        /// </summary>
        public Guid DepartmentId { get; set; }
        //public string DepartmentName { get; set; }

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
    }
}
