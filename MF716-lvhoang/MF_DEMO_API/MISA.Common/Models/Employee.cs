using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace MISA.Common.Models
{
    public class Employee
    {
        public Employee() {

             EmployeeId = Guid.NewGuid();

            }
        public Guid EmployeeId { get; set; }
        public String EmployeeId_
        {

            get
            {
                return EmployeeId.ToString();
            }
        }
        

        [Required("Mã nhân viên")]
        [CheckDuplicate("Mã nhân viên")]
        [MaxLength("Mã nhân viên", 20)]
        public string EmployeeCode { get; set; }

        [Required("Họ và tên")]
        public string FullName { get; set; }
        public int? Gender { get; set; }
        public string GenderName
        {

            get
            {
                switch (Gender)
                {
                    case 1: return "Nam";
                    case 2: return "Nữ";
                    case 0: return "Không xác định";
                    default: return "";
                }

            }
        }
        public DateTime? DateOfBirth { get; set; }
        public DateTime? IdentityDate { get; set; }

        [Required("CMND/Căn cước")]
        [CheckDuplicate("CMND/Căn cước")]
        public string IdentityNumber { get; set; }
        public string IdentityPlace { get; set; }

        [Required("Số điện thoại")]
        [CheckDuplicate("Số điện thoại")]
        public string PhoneNumber { get; set; }

        [Required("Email")]
        [CheckDuplicate("Email")]
        public string Email { get; set; }

        public int? Salary { get; set; }
        public Guid? PositionId { get; set; }
        public String PositionId_ { 
            get 
            {
                return PositionId.ToString();
            }  
        }
        public string PositionName { get; }
        public int? WorkStatus { get; set; }
        public string WorkStatusName
        {

            get
            {
                switch (WorkStatus)
                {
                    case 1: return "Đang làm việc";
                    case 2: return "Đang thử việc";
                    case 3: return "Đã về hưu";
                    case 0: return "Đã nghỉ việc";
                    default: return "";
                }

            }
        }
        public DateTime? JoinDate { get; set; }
        public int? PersonalTaxCode{ get; set; }
        public Guid? DepartmentId { get; set; }
        public String DepartmentId_
        {
            get
            {
                return DepartmentId.ToString();
            }
        }
        public string DepartmentName { get; }

    }

}
