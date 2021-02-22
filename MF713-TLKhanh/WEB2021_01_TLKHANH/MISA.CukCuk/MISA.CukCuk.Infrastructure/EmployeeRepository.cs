using Dapper;
using Microsoft.Extensions.Configuration;
using MISA.CukCuk.Core.Entities;
using MISA.CukCuk.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MISA.CukCuk.Infrastructure
{
    public class EmployeeRepository : BaseRepository<Employee>, IEmployeeRepository
    {

        #region Constructor
        /// <summary>
        /// Hàm khởi tạo
        /// </summary>
        /// <param name="configuration">biến confidg</param>
        /// CreatedBy: TLKhanh (19/2/2021)
        public EmployeeRepository(IConfiguration configuration) : base(configuration)
        {

        }
        #endregion
        #region Method
        public IEnumerable<Employee> GetEmployees()
        {
            return _dbConnection.Query<Employee>("Proc_GetEmployees", commandType: System.Data.CommandType.StoredProcedure);
        }

        public Employee GetMaxCode()
        {
            return _dbConnection.Query<Employee>("SELECT MAX(EmployeeCode) as EmployeeCode FROM Employee e").FirstOrDefault();
        }
        #endregion
    }
}
