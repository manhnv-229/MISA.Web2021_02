using System;
using System.Collections.Generic;
using System.Text;
using Dapper;
using MISA.Common.Models;
using MISA.DataLayer.Interfaces;

namespace MISA.DataLayer.Contexts
{
    public class EmployeeRepositoryV2 : DbContextV2<Employee>, IEmployeeRepository
    {
        /// <summary>
        /// Lọc tìm kiếm Employee theo EmployeeCode
        /// </summary>
        /// <param name="employeeCode">EmployeeCode muốn lọc</param>
        /// <returns>Danh sách các Employee đã được lọc</returns>
        /// CreatedBy: LVHOANG
        public IEnumerable<Employee> GetByEmployeeCode(string employeeCode)
        {
            var sql = $"SELECT * FROM Employee WHERE EmployeeCode like concat('%','{employeeCode}','%') ";
            return _dbConnection.Query<Employee>(sql);
        }
    }
}
