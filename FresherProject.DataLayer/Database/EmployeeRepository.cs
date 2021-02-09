using FresherProject.Common;
using FresherProject.DataLayer.Database;
using FresherProject.DataLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace FresherProject.DataLayer.Database
{
    public class EmployeeRepository : DBConnector<Employee>, IEmployeeRepository
    {
        /// <summary>
        /// Lấy 100 nhân viên đầu tiên
        /// </summary>x
        /// <returns></returns>
        public IEnumerable<Employee> GetEmployeeTop100()
        {
            return GetAllData("SELECT * FROM Employee LIMIT 100");
        }
    }
}
