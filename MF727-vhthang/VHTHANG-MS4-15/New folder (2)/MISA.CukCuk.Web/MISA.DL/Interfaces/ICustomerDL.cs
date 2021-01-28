using MISA.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.DL.Interfaces
{
    public interface ICustomerDL
    {
        IEnumerable<Customer> GetCustomers();
        int Insert(Customer customer);
        bool CheckDuplicateCustomerCode(string Code);
    }
}
