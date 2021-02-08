using MISA.Common.Models;
using MISA.DataLayer.Interface;
using MISA.Service.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Service.Service
{
    public class EmployeeServiceV2:BaseService<Employee>, IEmployeeService

    {
        public EmployeeServiceV2(IDbContext<Employee> _dbContext) : base(_dbContext)
        {

        }
        protected override bool ValidateData(Employee entity, ErrorMsg errorMsg = null)
        {
            return true;
        }

    }
}
