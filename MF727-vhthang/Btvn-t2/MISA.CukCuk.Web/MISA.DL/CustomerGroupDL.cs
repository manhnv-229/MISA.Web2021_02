using MISA.CukCuk.Web.Models;
using MISA.DL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.DL
{
    public class CustomerGroupDL: ICustomerGroupDL
    {
        IDbContext<CustomerGroup> _dbContext;
        public CustomerGroupDL(IDbContext<CustomerGroup> dbContext)
        {
            _dbContext = dbContext;
        }
        public IEnumerable<CustomerGroup> CheckDuplicate(string name, string value)
        {

            var customerGroup = _dbContext.GetData($"SELECT * FROM CustomerGroup AS Cg WHERE Cg.{name} = '{value}'");
            return customerGroup;
        }
    }
}
