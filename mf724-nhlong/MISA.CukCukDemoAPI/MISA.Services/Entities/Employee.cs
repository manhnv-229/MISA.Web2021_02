using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.Service.Entities
{
    public class Employee
    {
        public Guid EmployeeID { get; set; }
        public Guid DepartmentID { get; set; }
        public string DepartmentName { get; set; }
        public string EmployeeCode { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string FullName { get; set; }
        public string IdentityCardCode { get; set; }
        public string EmployeeTaxCode { get; set; }
        public string JobPosition { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public DateTime? DateOfIdentityCardAssigned { get; set; }
        public DateTime? DateOfJoiningCompany { get; set; }
        public int Gender { get; set; }
        public int JobStatus { get; set; }
        public int BaseSalary { get; set; }
        public string PlaceProvideIdentityCard { get; set; }
    }
}
