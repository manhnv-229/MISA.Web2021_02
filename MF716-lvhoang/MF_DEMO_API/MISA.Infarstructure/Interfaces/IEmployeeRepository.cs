using System;
using System.Collections.Generic;
using System.Text;
using MISA.Common.Models;

namespace MISA.DataLayer.Interfaces
{
    public interface IEmployeeRepository: IDbContext<Employee>
    {
        /// <summary>
        /// Lọc tìm kiếm Employee theo EmployeeCode
        /// </summary>
        /// <param name="employeeCode">EmployeeCode muốn lọc</param>
        /// <returns>Danh sách các Employee đã được lọc</returns>
        /// CreatedBy: LVHOANG
        public IEnumerable<Employee> GetByEmployeeCode(string EmployeeCode);
    }
}
