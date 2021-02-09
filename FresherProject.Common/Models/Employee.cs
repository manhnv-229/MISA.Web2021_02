using FresherProject.Common.AttributeBL;
using System;
using System.Collections.Generic;
using System.Text;

namespace FresherProject.Common
{
    public class Employee
    {
        public Guid EmployeeId { get; set; }
        [Required("Mã nhân viên", "Bạn phải nhập mã nhân viên")]
        [CheckDuplicate("Mã nhân viên", "Mã nhân viên đã tồn tại")]
        [MaxLength("Mã nhân viên", 20)]
        public string EmployeeCode { get; set; }
        public string FullName { get; set; }
        public Guid? EmployeeDepartmentId { get; set; }
        //public string EmployeeDepartmentName { get; set; }
        public EmployeeDepartment EmployeeDepartment { get; set; }
        //public virtual EmployeeDepartment EmployeeDepartment { get; set; }

        public Guid? EmployeePositionId { get; set; }
        //public string EmployeePositionName { get; set; }
        public EmployeePosition EmployeePosition { get; set; }
        //public virtual EmployeePosition EmployeePosition { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int Gender { get; set; }
        public string IdentityCardNumber { get; set; }
        public DateTime IssuedOn { get; set; }
        public string IssuedPlace { get; set; }
        public string Email { get; set; }
        [Required("Số điện thoại")]
        [CheckDuplicate("Số điện thoại", "Số điện thoại này đã tồn tại trên hệ thống")]
        public string PhoneNumber { get; set; }
        public string PersonalTaxCode { get; set; }
        public Decimal BasicSalary { get; set; }
        public DateTime JoinCompanyDate { get; set; }
        public string StatusJob { get; set; }
    }
}
