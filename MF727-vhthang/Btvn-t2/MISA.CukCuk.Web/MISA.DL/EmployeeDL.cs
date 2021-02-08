using Dapper;
using MISA.Common;
using System;
using System.Collections.Generic;
using System.Text;
using MISA.DL.Interfaces;
using System.Linq;

namespace MISA.DL
{
    public class EmployeeDL : IEmployeeDL
    {
        IDbContext<Employee> _dbContext;
        public EmployeeDL(IDbContext<Employee> dbContext)
        {
            _dbContext = dbContext;
        }
        public IEnumerable<Employee> CheckDuplicate(string name, string value)
        {

            var employee = _dbContext.GetData($"SELECT * FROM Employee AS E WHERE E.{name} = '{value}'");
            return employee;
        }








































        ////Lấy toàn bộ nhân viên
        //public IEnumerable<Employee> GetEmployees()
        //{
        //    DbConnector dbConnector = new DbConnector();
        //    var employees = dbConnector.GetAllData<Employee>();
        //    return employees;
        //}
        ////Lấy theo số trang và cách sắp xếp
        //public IEnumerable<Employee> GetEmployeeByNumAndType(int num,int type)
        //{
        //    DbConnector dbConnector = new DbConnector();
        //    var _type = "EmployeeCode";
        //    if(type == 1) { _type = "EmployeeCode"; }
        //    else if(type == 2) { _type = "EmployeeName"; }
        //    else if (type == 3) { _type = "EmployeeBirth"; }
        //    else if (type == 4) { _type = "EmployeeSalaryGrade"; }
        //    else if (type == 5) { _type = "EmployeeName"; }
        //    else _type = "EmployeeCode";
        //    int _num = num - 1;
        //    var employees = dbConnector.GetDataByNumAndType<Employee>(_num,_type);
        //    return employees;
        //}

        ////Lấy dữ liệu 1 nhân viên qua Mã khách hàng
        //public IEnumerable<Employee> GetEmployeeByCode(string code)
        //{
        //    DbConnector dbConnector = new DbConnector();
        //    var employee = dbConnector.GetByCode<Employee>(code);
        //    return employee;
        //}

        //public IEnumerable<Employee> GetEmployeeByEmail(string email)
        //{
        //    DbConnector dbConnector = new DbConnector();
        //    var employee = dbConnector.GetByEmail<Employee>(email);
        //    return employee;
        //}

        //public IEnumerable<Employee> GetEmployeeByIdentifyNumber(string identifyNumber)
        //{
        //    DbConnector dbConnector = new DbConnector();
        //    var employee = dbConnector.GetByIdentifyNumber<Employee>(identifyNumber);
        //    return employee;
        //}
        //public IEnumerable<Employee> GetEmployeeByPhone(string phone)
        //{
        //    DbConnector dbConnector = new DbConnector();
        //    var employee = dbConnector.GetByIdentifyNumber<Employee>(phone);
        //    return employee;
        //}

        ////Lấy mã code cao nhất
        //public List<string> GetEmployeeCodeMax()
        //{
        //    DbConnector dbConnector = new DbConnector();
        //    var codeMax = dbConnector.GetCodeMax<Employee>();
        //    return codeMax;
        //}
        ////Thêm mới dữ liệu (1 nhân viên)
        //public int InsertEmployee(Employee employee)
        //{
        //    DbConnector dbConnector = new DbConnector();
        //    var rowResults = dbConnector.Insert<Employee>(employee);
        //    return rowResults;
        //}
        ////Sửa thông tin nhân viên
        //public int UpdateEmployee(Employee employee)
        //{
        //    DbConnector dbConnector = new DbConnector();
        //    var rowResults = dbConnector.Update<Employee>(employee);
        //    return rowResults;
        //}

        ////Xóa nhân viên
        //public int DeleteEmployee(string id)
        //{
        //    DbConnector dbConnector = new DbConnector();
        //    var rowEffects = dbConnector.Delete<Employee>(id);
        //    return rowEffects;
        //}

    }
}
