using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.Common.Model
{
    /// <summary>
    /// Nhân viên
    /// CreatedBy: NTANH (07/02/2021)
    /// </summary>
    public class Employee
    {
        #region Contructor
        #endregion

        #region Method
        #endregion

        #region Property
        /// <summary>
        /// Khóa chính
        /// </summary>
        public Guid EmployeeId { get; set; }

        /// <summary>
        /// Khóa chính được chuyển sang kiểu String
        /// </summary>
        //public string Id
        //{
        //    get
        //    {
        //        return EmployeeId.ToString();
        //    }
        //}

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
        public DateTime? DateOfBirth { get; set; }
        
        /// <summary>
        /// Giới tính (1 - Nam; 0 - Nữ; 2 - Khác)
        /// </summary>
        public int? Gender { get; set; }
        
        /// <summary>
        /// Số CMT, căn cước
        /// </summary>
        public string PeopleID { get; set; }
        
        /// <summary>
        /// Ngày cấp CMT, căn cước
        /// </summary>
        public DateTime? DateCreatedPeopleID { get; set; }
        
        /// <summary>
        /// Nơi cấp CMT, căn cước
        /// </summary>
        public string PlaceCreatedPeopleID { get; set; }
        
        /// <summary>
        /// Email
        /// </summary>
        public string Email { get; set; }
        
        /// <summary>
        /// Số điện thoại
        /// </summary>
        public string PhoneNumber { get; set; }
        
        /// <summary>
        /// Khóa ngoại bảng vị trí (JobPosition)
        /// </summary>
        public Guid JobPositionId { get; set; }
        
        /// <summary>
        /// Khóa ngoại bảng vị trí kiểu String
        /// </summary>
        //public string PosId
        //{
        //    get
        //    {
        //        return JobPositionId.ToString();
        //    }
        //}

        /// <summary>
        /// Khóa ngoại bảng Phòng ban (Department)
        /// </summary>
        public Guid DepartmentId { get; set; }
        
        /// <summary>
        /// Khóa ngoại bảng Phòng ban kiểu String
        /// </summary>
        //public string DepartId
        //{
        //    get
        //    {
        //        return DepartmentId.ToString();
        //    }
        //}

        /// <summary>
        /// Tên vị trí công việc
        /// </summary>
        //public string JobPositionName { get; set; }

        /// <summary>
        /// Tên phòng ban
        /// </summary>
        //public string DepartmentName { get; set; }
        /// <summary>
        /// Mã số thuế cá nhân
        /// </summary>
        public string TaxCode { get; set; }
        
        /// <summary>
        /// Mức lương cơ bản
        /// </summary>
        public string Salary { get; set; }
        
        /// <summary>
        /// Ngày gia nhập công ty
        /// </summary>
        public DateTime? DateStartJob { get; set; }
        
        /// <summary>
        /// Tình trạng làm việc
        /// </summary>
        public string JobProperty { get; set; }
        #endregion

        #region Other
        /// <summary>
        /// Ngày tạo bản ghi
        /// </summary>
        public DateTime? CreatedDate { get; set; }
        
        /// <summary>
        /// Người tạo bản ghi
        /// </summary>
        public string CreatedBy { get; set; }
        
        /// <summary>
        /// Ngày chỉnh sửa gần nhất
        /// </summary>
        public DateTime? ModifiedDate { get; set; }
        
        /// <summary>
        /// Người thực hiện chỉnh sửa gần nhất
        /// </summary>
        public string ModifiedBy { get; set; }
        
        #endregion
    }
}
