using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.Common.Models
{
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
        [Required("Mã nhân viên", "Bạn phải nhập mã Nhân viên")]
        [CheckDuplicate("Mã nhân viên", "Mã nhân viên đã tồn tại!")]
        [MaxLength("Mã nhân viên", 20)]
        public string EmployeeCode { get; set; }

        /// <summary>
        /// Họ tên nhân viên
        /// </summary>
        [Required("Họ Tên Nhân viên", "Bạn phải nhập tên NV")]

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
        /// MÃ thẻ căn cước
        /// </summary>
        [Required("Mã thẻ căn cước", "Bạn phải nhập mã thẻ căn cước")]
        [CheckDuplicate("Mã thẻ căn cước", "Mã thẻ căn cước đã tồn tại!")]
        [MaxLength("Mã thẻ căn cước", 20)]
        public string IdentifyNumber { get; set; }

        /// <summary>
        /// Ngày cấp
        /// </summary>
        public DateTime? DateOfIn { get; set; }

        /// <summary>
        /// Nới cấp
        /// </summary>
        public string PlaceOfIn { get; set; }

        /// <summary>
        /// Email
        /// </summary>
        [Required("Địa chỉ email", "Bạn phải email Nhân viên")]
        public string Email { get; set; }

        /// <summary>
        /// Số điện thoại
        /// </summary>
        [Required("Số điện thoại nhân viên", "Bạn phải nhập sđt NV")]
        [CheckDuplicate("Số điện thoại nhân viên", "Số điện thoại đã tồn tại!")]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Mã vị trí
        /// </summary>
        public Guid PositionId { get; set; }

        /// <summary>
        /// Mã phòng ban
        /// </summary>
        public Guid DepartmentId { get; set; }

        /// <summary>
        /// Mã số thuế
        /// </summary>
        public string TaxCode { get; set; }

        /// <summary>
        /// Lương
        /// </summary>
        public string Salary { get; set; }

        /// <summary>
        /// Ngày gia nhập công ty
        /// </summary>
        public DateTime? DateOfBeginWork { get; set; }

        /// <summary>
        /// Tình trạng làm việc
        /// </summary>
        public int? Status { get; set; }
        #endregion
    }
}
