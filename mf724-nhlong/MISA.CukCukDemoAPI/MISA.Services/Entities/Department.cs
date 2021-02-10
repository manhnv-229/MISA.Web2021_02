using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.Service.Entities
{
    public class Department
    {
        public Guid DepartmentID { get; set; }
        public int DepartmentCode { get; set; }
        public string DepartmentName { get; set; }
        public string Description { get; set; }
    }
}