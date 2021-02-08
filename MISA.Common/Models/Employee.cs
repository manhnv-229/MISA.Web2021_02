using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.Common.Models
{
    public class Employee
    {
        #region constructor
        public Employee()
        {
            EmployeeId = new Guid();
        }
        #endregion

        #region properties
        public Guid EmployeeId { get; set; }
        public string Id
        {
            get
            {
                return EmployeeId.ToString();
            }
        }
        /// <summary>
        /// Mã nhân viên
        /// </summary>
        [Required("Mã khách hàng", "Bạn phải nhập thông tin mã khách hàng")]
        [CheckDuplicate("Mã khách hàng", "Mã khách hàng không được phép trùng")]
        public String EmployeeCode { get; set; }
        /// <summary>
        /// Họ và tên
        /// </summary>
        [Required("Họ và tên","Bạn phải nhập họ và tên")]
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
        /// Số chứng minh nhân dân
        /// </summary>

        [Required("Số Chứng minh nhân dân","Bạn phải nhập số chứng minh nhân dân")]
        [CheckDuplicate("Số Chứng minh nhân dân","Số Chứng minh nhân dân đã tồn tại")]
        public string IndentifyNumber { get; set; }
        /// <summary>
        /// Ngày tạo chứng minh nhân dân
        /// </summary>
        public DateTime? IndentifyDateCreated { get; set; }
        /// <summary>
        /// Nơi tạo chứng minh nhân dân
        /// </summary>
        public string IndentifyPlaceCreated { get; set; }
        public string Email { get; set; }
        [Required("Số điện thoại", "Bạn phải nhập số điện thoại")]
        [MaxLength("Số điện thoại", 20, "Số điện thoại không được phép vượt quá 10 ký tự")]
        [CheckDuplicate("Số điện thoại", "Số điện thoại đã tồn tại")]
        public string PhoneNumber { get; set; }
        /// <summary>
        /// Id vị trí/ chức vụ của nhân viên
        /// </summary>
        [Required("Chức vụ","Trường chức vụ này không thể để trống được")]
        public Guid EmployeePositionId { get; set; }

        /// <summary>
        /// Id phòng ban
        /// </summary>
        [Required("Phòng ban", "Bạn phải nhập vị trí phòng làm việc ???")]
        public Guid EmployeeDepartmentId { get; set; }
        /// <summary>
        /// Mã số thuế
        /// </summary>
        public string  TaxCode { get; set; }
        /// <summary>
        /// Tiền lương
        /// </summary>
        public string Salary { get; set; }
        public DateTime? DateBeginWork { get; set; }
        /// <summary>
        /// tình trạng công việc
        /// </summary>
        public int? Status { get; set; }
        /// <summary>
        /// Tổng số nhân viên
        /// </summary>
        public int? Total { get; set; }
        /// <summary>
        /// Tên vị trí/ chức vụ
        /// </summary>
        public string EmployeePositionName { get; set; }
        /// <summary>
        /// Tên phòng ban
        /// </summary>
        public string EmployeeDepartmentName { get; set; }

        #endregion

        #region other
        public DateTime? CreateDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        #endregion
    }
}
