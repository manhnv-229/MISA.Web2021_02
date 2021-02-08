using System;
using System.Collections.Generic;
using System.Text;

namespace MisaCukCuk_Entity.Models
{
    public class Employee
    {
        /// <summary>
        /// Id nhân viên
        /// CreateBy: MinhHq(08/02/2021)
        /// </summary>
        public Guid EmployeeId { get; set; }
        public string Id { get { return EmployeeId.ToString(); } set { } }
        /// <summary>
        /// Mã nhân viên
        /// CreateBy: MinhHq(08/02/2021)
        /// </summary>
        public string EmployeeCode { get; set; }
        /// <summary>
        /// Tên nhân viên
        /// CreateBy: MinhHq(08/02/2021)
        /// </summary>
        public string FullName { get; set; }
        /// <summary>
        /// Giới tính
        /// CreateBy: MinhHq(08/02/2021)
        /// </summary>
        public int Gender { get; set; }
        public string GenderName
        {
            get
            {
                switch (Gender)
                {
                    case 0: return "Nam";
                    case 1: return "Nữ";
                    case 2: return "Khác";
                    default: return "Không xác định";
                }
            }
        }
        /// <summary>
        /// Ngày sinh
        /// CreateBy: MinhHq(08/02/2021)
        /// </summary>
        public DateTime? DateOfBirth { get; set; }
        /// <summary>
        /// Số điện thoại
        /// CreateBy: MinhHq(08/02/2021)
        /// </summary>
        public string PhoneNumber { get; set; }
        /// <summary>
        /// Email nhân viên
        /// CreateBy: MinhHq(08/02/2021)
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// Mã phòng ban nhân viên
        /// CreateBy: MinhHq(08/02/2021)
        /// </summary>
        public Guid? DepartmentId { get; set; }
        public string DepartmentIdString { get { return DepartmentId.ToString(); } set { } }
        /// <summary>
        /// Mã chức vụ nhân viên
        /// CreateBy: MinhHq(08/02/2021)
        /// </summary>
        public Guid? PositionId { get; set; }
        public string PositionIdString { get { return PositionId.ToString(); } set { } }
        /// <summary>
        /// Lương nhân viên
        /// CreateBy: MinhHq(08/02/2021)
        /// </summary>
        public int? Salary { get; set; }
        /// <summary>
        /// Tình trạng công việc
        /// CreateBy: MinhHq(08/02/2021)
        /// </summary>
        public int StatusWork { get; set; }
        public string JobStatusName
        {
            get
            {
                switch (StatusWork)
                {
                    case 0: return "Đang làm việc";
                    case 1: return "Đã nghỉ việc";
                    case 2: return "Đang thử việc";
                    default: return "Không xác định";
                }
            }
        }
        /// <summary>
        /// Số chứng minh nhân dân
        /// CreateBy: MinhHq(08/02/2021)
        /// </summary>
        public string CMTND { get; set; }
        /// <summary>
        /// Ngày cấp chứng minh nhân dân
        /// CreateBy: MinhHq(08/02/2021)
        /// </summary>
        public DateTime? CMTNDDate { get; set; }
        /// <summary>
        /// Nơi cấp chứng minh nhân dân
        /// CreateBy: MinhHq(08/02/2021)
        /// </summary>
        public string CMTNDPlace { get; set; }
        /// <summary>
        /// Mã số thuế cá nhân
        /// CreateBy: MinhHq(08/02/2021)
        /// </summary>
        public string PersonalTaxCode { get; set; }
        /// <summary>
        /// Ngày bắt đầu làm việc
        /// CreateBy: MinhHq(08/02/2021)
        /// </summary>
        public DateTime? DateStartWork { get; set; }
    }
}
