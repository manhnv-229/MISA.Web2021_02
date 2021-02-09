using MISA.Common.Models;
using MISA.DataLayer;
using MISA.DataLayer.Interface;
using MISA.Service.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace MISA.Service
{
    public class DepartmentService : BaseService<Department>, IDepartmentService
    {

        public DepartmentService(IDbContext<Department> _dbContext) : base(_dbContext)
        {

        }
        #region Method
        #endregion
    }
}
