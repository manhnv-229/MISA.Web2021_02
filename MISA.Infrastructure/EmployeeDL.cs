using MISA.Common;
using MISA.Common.Model;
using MISA.Infrastructure.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MISA.Infrastructure
{
    public class EmployeeDL:BaseDL<Employee>, IEmployeeDL
    {
        #region DECLARE
        DbConnector dbConnector = new DbConnector();
        #endregion

        #region Methods
        //lấy dữ liệu bằng id
        public IEnumerable<T> GetEmployeeById<T>(string id)
        {
            var tableName = typeof(T).Name;
            var sqlCommand = $"SELECT * FROM {tableName} WHERE {tableName}Id = @{tableName}Id";
            return dbConnector.GetData<T>(sqlCommand, new { EmployeeId = id });
        }
        public IEnumerable<T> GetDatapage<T>(int offset,int size)
        {
            var tableName = typeof(T).Name;
            var storeName = $"pro_Get{tableName}OfPage";
            var param = new
            {
                offset = offset,
                size = size
            };
            return dbConnector.GetData<T>(storeName, param, System.Data.CommandType.StoredProcedure);
        }
        public long GetCountdata<T>()
        {
            return dbConnector.GetCountData<T>();
        }

        public int DeleteEmployee(Employee employee)
        {
            return dbConnector.delete<Employee>(employee);
        }
        public bool CheckDuplicateEmployeeId(string id)
        {
            var sqlCommand = $"SELECT * FROM Employee WHERE EmployeeId = @EmployeeId";
            List<Employee> employees = dbConnector.GetData<Employee>(sqlCommand, new { EmployeeId = id }) as List<Employee>;

            if (employees.Count() > 0)
                return true;

            return false;

        }
        public bool CheckDuplicateEmployeeCode(Employee employee)
        {
            var sqlCommand = $"SELECT * FROM Employee WHERE EmployeeCode = @EmployeeCode";
            var param = new { EmployeeCode = employee.EmployeeCode };
            List<Employee> employees = dbConnector.GetData<Employee>(sqlCommand,param) as List<Employee>;

            if(employees.Count() > 0)
            {
                return true;
            }
            return false;
        }

        //kiểm tra trùng indentify và phone khi insert
        public bool CheckDuplicatePhone(Employee employee)
        {
            var sqlCommand = $"SELECT * FROM Employee WHERE PhoneNumber = @PhoneNumber";
            var param = new { PhoneNumber = employee.PhoneNumber };
            List<Employee> employees = dbConnector.GetData<Employee>(sqlCommand, param) as List<Employee>;
            if (employees.Count() > 0)
                return true;
            return false;
        }
        public bool CheckDuplicateIndentify(Employee employee)
        {
            var sqlCommand = $"SELECT * FROM Employee WHERE IndentifyNumber = @IndentifyNumber";
            var param = new { IndentifyNumber = employee.IndentifyNumber };
            List<Employee> employees = dbConnector.GetData<Employee>(sqlCommand, param) as List<Employee>;
            if (employees.Count() > 0)
                return true;
            return false;
        }
        //kiểm tra trường để trống
        public int CheckEmpty(Employee employee)
        {
            if(employee.FullName.Trim() == string.Empty)
            {
                return -3;
            }
            if(employee.IndentifyNumber.Trim() == string.Empty)
            {
                return -4;
            }
            if(employee.Email.Trim()  == string.Empty)
            {
                return -5;
            }
            if(employee.PhoneNumber.Trim() == string.Empty)
            {
                return -6;
            }
            return 0;
        }

        //kiểm tra trùng khi update
        public bool CheckDuplicateIndentifyandId(Employee employee)
        {
            var sqlCommand = $"SELECT * FROM Employee WHERE IndentifyNumber = @IndentifyNumber && EmployeeId != @EmployeeId";
            var param = new { 
                IndentifyNumber = employee.IndentifyNumber,
                EmployeeId = employee.EmployeeId.ToString()
            };
            List<Employee> employees = dbConnector.GetData<Employee>(sqlCommand, param) as List<Employee>;
            if (employees.Count() > 0)
                return true;
            return false;
        }
        public bool CheckDuplicatePhoneandId(Employee employee)
        {
            var sqlCommand = $"SELECT * FROM Employee WHERE PhoneNumber = @PhoneNumber && EmployeeId != @EmployeeId";
            var param = new
            {
                PhoneNumber = employee.PhoneNumber,
                EmployeeId = employee.EmployeeId.ToString()
            };
            List<Employee> employees = dbConnector.GetData<Employee>(sqlCommand, param) as List<Employee>;
            if (employees.Count() > 0)
                return true;
            return false;
        }

        public IEnumerable<T> GetEmployeeCodeM<T>()
        {
            var tableName = typeof(T).Name;
            return dbConnector.GetData<T>($"SELECT MAX(EmployeeCode) as EmployeeCode FROM {tableName}");
        }

        #endregion
    }
}
