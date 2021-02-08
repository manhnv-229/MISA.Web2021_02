using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
using Dapper;
using System.Linq;
using MISA.Service.Interfaces;
using MISA.Service.Entities;
using Microsoft.Extensions.Configuration;

namespace MISA.DataLayer
{
    public class EmployeeReposity :BaseReposity<Employee>, IEmployeeReposity
    {
        #region Declare Field
        #endregion
        #region Constructor
        public EmployeeReposity(IConfiguration configuration):base(configuration)
        {
        }
        #endregion

        #region Methods

        public override IEnumerable<Employee> GetEntities()
        {
            var res = _dbConnection.Query<Employee>($"Proc_GetEmployee", new { offset = 0 }, commandType: CommandType.StoredProcedure);
            return res;
        }
        public override int UpdateEntity(Employee employee)
        {
            // Thiet lap cau lenh SQL de thuc hien update, voi cac ten thuoc tinh (propertyName)
            // va gia tri tuong ung (propertyValue)

            var properties = typeof(Employee).GetProperties();
            var parameters = new DynamicParameters();
            var sqlPropertyBuilder = string.Empty;
            var sqlPropertyParamBuilder = string.Empty;

            foreach (var property in properties)
            {
                var propertyName = property.Name;
                var propertyValue = property.GetValue(employee);
                if (propertyName != "DepartmentName" && propertyName != "DepartmentID" && propertyName != "EmployeeID"  && propertyName != "EmployeeCode")
                {
                    parameters.Add($"@{propertyName}", propertyValue);
                    sqlPropertyBuilder += $"{propertyName} = @{propertyName},";
                }
                else if (propertyName == "DepartmentName")
                {
                    var _departmentGUID = _dbConnection.Query<Department>($"Proc_GetDepartmentIDByName", new { DepartmentName = property.GetValue(employee) },
                            commandType: CommandType.StoredProcedure).FirstOrDefault();
                    parameters.Add($"@DepartmentID", _departmentGUID.DepartmentID);
                    sqlPropertyBuilder += "DepartmentID = @DepartmentID,";
                }
            }
            var id = GetEntityByCode(employee.EmployeeCode);
            var sql = $"Update {_className} SET {sqlPropertyBuilder.Remove(sqlPropertyBuilder.Length-1,1)} WHERE {_className}.{_className}ID = '{id.EmployeeID.ToString()}'";
            var effectRows = _dbConnection.Execute(sql, parameters);
            return effectRows;
        }

        public override Employee GetEntityByCode(string employeecode){
            // Lay nhan vien dua vao ma nhan vien
            // var sqlSelectEmployeeCode = $"SELECT * FROM Employee AS E Where E.EmployeeCode = '{employeecode}'";
            var employee =  _dbConnection.Query<Employee>($"Proc_GetEmployeeByCode",new{EmployeeCode = employeecode},commandType: CommandType.StoredProcedure).FirstOrDefault();
            // var employee = _dbConnection.Query<Employee>(sqlSelectEmployeeCode,commandType : CommandType.Text).FirstOrDefault();
            // var sql = $"Select * FROM Department Where Department.DepartmentID = '{employee.DepartmentID}'";
            // var emploeeDepartment = _dbConnection.Query<Department>(sql,commandType: CommandType.Text).FirstOrDefault();
            // employee.DepartmentName = emploeeDepartment.DepartmentName;           
            
            return employee;
        }

       public Employee GetLastestEmployeeCode() {
            var employees = new Employee();
            employees = _dbConnection.Query<Employee>($"Proc_GetLastestEmployeeCode",
                            commandType: CommandType.StoredProcedure).FirstOrDefault();
            return employees;
        }

        #endregion
    }

}
