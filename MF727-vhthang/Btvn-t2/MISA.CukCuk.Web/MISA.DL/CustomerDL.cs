using Dapper;
using MISA.Common;
using System;
using System.Collections.Generic;
using System.Text;
using MISA.DL.Interfaces;
using System.Linq;

namespace MISA.DL
{
    public class CustomerDL:ICustomerDL
    {
        IDbContext<Customer> _dbContext;
        public CustomerDL(IDbContext<Customer> dbContext)
        {
            _dbContext = dbContext;
        }
        public IEnumerable<Customer> CheckDuplicate(string name, string value) {
            
            var customer = _dbContext.GetData($"SELECT * FROM Customer AS C WHERE C.{name} = '{value}'");
            return customer;
        }

    }
}
