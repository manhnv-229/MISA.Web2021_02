using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.Common.Models
{
    public class Department
    {
        public Guid DepartmentId { get; set; }
        public String DepartmentId_
        {

            get
            {
                return DepartmentId.ToString();
            }
        }
        public string DepartmentName { get; set; }
    }
}
