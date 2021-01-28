using MISA.Common;
using MISA.Common.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.BL.Interfaces
{
    public interface IEmployeeBL
    {
        public IEnumerable<Employee> GetEmployees();
        public IEnumerable<Employee> GetEmployeeByCode(string code);
        public string GetEmployeeCodeMax();
        public ServiceResult InsertEmployee(Employee employee);
        public ServiceResult UpdateEmployee(Employee employee);
        public ServiceResult DeleteEmployee(string id);
        public IEnumerable<Employee> GetEmployeeByNumAndType(int num, int type);

    }
}
