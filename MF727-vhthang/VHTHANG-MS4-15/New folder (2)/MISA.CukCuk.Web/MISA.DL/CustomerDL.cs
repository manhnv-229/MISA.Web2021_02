using Dapper;
using MISA.Common;
using System;
using System.Collections.Generic;
using System.Text;
using MISA.DL.Interfaces;
using System.Linq;

namespace MISA.DL
{
    public class CustomerDL:DbConnector, ICustomerDL
    {
        
       public int InsertCustomer(Customer customer)
        {
            DbConnector dbConnector = new DbConnector();
            var affectRows = dbConnector.Insert<Customer>(customer);
            return affectRows;
        }
        public bool CheckDuplicateCustomerCode(string Code) {
            var customer = dbConnection.Query<Customer>($"SELECT * FROM Customer WHERE CustomerCode = '{Code}'").FirstOrDefault();
            if(customer != null)
            {
                return true;
            }
            return false;
        }

        public IEnumerable<Customer> GetCustomers()
        {
            throw new NotImplementedException();
        }

        public int Insert(Customer customer)
        {
            DbConnector dbConnector = new DbConnector();
            var affectRows = dbConnector.Insert<Customer>(customer);
            return affectRows;
        }
    }
}
