using System;
using System.Collections.Generic;
using System.Text;
using MISA.Common.Models;
using MISA.DataLayer;
using MISA.DataLayer.Interfaces;
using MISA.Service.Interfaces;

namespace MISA.Service.Services
{
    public class EmployeeService : BaseService<Employee>, IEmployeeService
    {
        IEmployeeRepository _dbContext;
        public EmployeeService(IEmployeeRepository dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
        public IEnumerable<Employee> GetByEmployeeCode(string EmployeeCode)
        {
            return _dbContext.GetByEmployeeCode(EmployeeCode);
        }
    }
}
