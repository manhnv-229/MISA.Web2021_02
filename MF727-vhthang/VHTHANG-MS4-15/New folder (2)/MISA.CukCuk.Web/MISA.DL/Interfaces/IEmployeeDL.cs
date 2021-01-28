using MISA.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.DL.Interfaces
{
    public interface IEmployeeDL
    {
        public IEnumerable<Employee> GetEmployees();
        public IEnumerable<Employee> GetEmployeeByCode(string code);
        public List<string> GetEmployeeCodeMax();
        public int InsertEmployee(Employee employee);
        public int UpdateEmployee(Employee employee);
        public Employee GetEmployeeByCode1(string code);
        public int DeleteEmployee(string id);
        public IEnumerable<Employee> GetEmployeeByNumAndType(int num, int type);
    }
}
