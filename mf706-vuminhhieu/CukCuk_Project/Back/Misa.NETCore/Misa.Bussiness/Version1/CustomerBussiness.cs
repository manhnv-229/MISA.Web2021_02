using Misa.Common.Entities;
using Misa.Data;
using Misa.Data.Version1;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Misa.Bussiness.Version1
{
    public class CustomerBussiness
    {
        private CustomerData customerData;
        public CustomerBussiness()
        {
            customerData = new CustomerData();
        }
        public async Task<IEnumerable<Customer>> GetAllData()
        {
            return await customerData.GetData();
        }
        public async Task<int> InsertCustomer(Customer customer)
        {
            // check thuộc tính
            return await customerData.Insert(customer);
        }

        public void UdpdateCustomer()
        {
            ;
        }
    }
}
