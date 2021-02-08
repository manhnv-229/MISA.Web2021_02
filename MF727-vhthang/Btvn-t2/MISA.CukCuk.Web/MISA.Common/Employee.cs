using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Common
{
    public class Employee
    {
        public Guid? EmployeeId { get; set; }
        public string EmployeeCode { get; set; }
        public string EmployeeName { get; set; }
        public DateTime? EmployeeBirth { get; set; }
        public int? EmployeeGender { get; set; }
        public string EmployeeIdentifyNumber { get; set; }   
        public DateTime? EmployeeDateRegistration { get; set; }
        public string EmployeePlaceRegistration { get; set; }
        public string EmployeeEmail { get; set; }
        public string EmployeePhone { get; set; }
        public string EmployeePosition { get; set; }
        public string EmployeeDepartment { get; set; }
        public string EmployeeTaxNumber { get; set; }
        public string EmployeeSalaryGrade { get; set; }
        public DateTime? EmployeeJoinDate { get; set; }
        public string EmployeeStatus { get; set; }

    }
}
