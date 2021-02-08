using MisaCukCuk_Entity.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MisaCukCuk_Infarstructure.Infarstructure.CustomerInfarstructure
{
    public class CustomerInfarstructure : MisaCukCukContext<Customer>, ICustomerInfarstructure
    {
        MisaCukCukContext<Customer> _db = new MisaCukCukContext<Customer>();

        public Task<bool> checkExistIdOfCustomer(string code)
        {
            throw new NotImplementedException();
        }

        public Task<int> deleteCustomerByCustomerCode(string code)
        {
            throw new NotImplementedException();
        }

        public Task<int> editCustomerById(Customer customer)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Customer>> getAllDataOfCustomer()
        {
            return await _db.GetAllData();
        }

        public async Task<IEnumerable<Customer>> getById(Guid code)
        {
            return await _db.GetByID(code);
        }

        public Task<IEnumerable<Customer>> getCustomersByCustomerCodeAndPhongNumber(string customerCode, string phoneNumber)
        {
            throw new NotImplementedException();
        }

        public Task<int> InsertCustomer(Customer customer)
        {
            throw new NotImplementedException();
        }
    }
}
