using MISA.Common.Interfaces;
using MISA.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.BLL
{
    public class CustomerGroupService : BaseService<CustomerGroup>, ICustomerGroupService
    {
        public CustomerGroupService(IDbContext<CustomerGroup> dbContext) : base(dbContext)
        {

        }
    }
}
