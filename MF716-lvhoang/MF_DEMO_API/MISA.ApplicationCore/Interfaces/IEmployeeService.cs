using System;
using System.Collections.Generic;
using System.Text;
using MISA.Common.Models;

namespace MISA.Service.Interfaces
{
    public interface IEmployeeService: IBaseService<Employee>
    {
        public IEnumerable<Employee> GetByEmployeeCode(string EmployeeCode);
    }
}
