using System;
using System.Collections.Generic;
using System.Text;

namespace FresherProject.Common
{
    public class EmployeeDepartment
    {
        public Guid EmployeeDepartmentId { get; set; }
        public string EmployeeDepartmentName { get; set; }
        public string Description { get; set; }
        //public IEnumerable<Employee> Employees { get; set; }
        public ICollection<Employee> Employees { get; set; }
    }
}
