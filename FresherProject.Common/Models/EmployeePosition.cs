using System;
using System.Collections.Generic;
using System.Text;

namespace FresherProject.Common
{
    public class EmployeePosition
    {
        public Guid EmployeePositionId { get; set; }
        public string EmployeePositionName { get; set; }
        public string Description { get; set; }
        //public virtual IEnumerable<Employee> Employees { get; set; }
        public ICollection<Employee> Employees { get; set; }
    }
}
