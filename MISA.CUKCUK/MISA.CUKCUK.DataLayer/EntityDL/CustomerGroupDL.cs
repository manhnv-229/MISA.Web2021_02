using MISA.Common.Model;
using MISA.DataLayer.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace MISA.DataLayer.EntityDL
{
    /// <summary>
    /// Khai báo entity CustomerGroupDL kế thừa interface ICustomerGroupDL
    /// </summary>
    public class CustomerGroupDL: BaseDL<CustomerGroup>, ICustomerGroupDL
    {
        private readonly IDbContext<CustomerGroup> _dbContext;

        //
        public CustomerGroupDL(IDbContext<CustomerGroup> dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
