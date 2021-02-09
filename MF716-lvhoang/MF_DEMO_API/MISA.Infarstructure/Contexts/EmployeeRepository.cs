using System;
using System.Collections.Generic;
using System.Text;
using MISA.DataLayer.Interfaces;
using MISA.Common.Models;
using Dapper;
using System.Linq;

namespace MISA.DataLayer.Contexts
{
    public class EmployeeRepository: DbContext<Employee>, IEmployeeRepository
    {
        /// <summary>
        /// Lọc tìm kiếm Employee theo EmployeeCode
        /// </summary>
        /// <param name="employeeCode">EmployeeCode muốn lọc</param>
        /// <returns>Danh sách các Employee đã được lọc</returns>
        /// CreatedBy: LVHOANG
        public IEnumerable<Employee>  GetByEmployeeCode(string employeeCode)
        {
            var sql = $"SELECT * FROM Employee WHERE EmployeeCode like concat('%','{employeeCode}','%') ";
            return _dbConnection.Query<Employee>(sql);
        }
    }
}
