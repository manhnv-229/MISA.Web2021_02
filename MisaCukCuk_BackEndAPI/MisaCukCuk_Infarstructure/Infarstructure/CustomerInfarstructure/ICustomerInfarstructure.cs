using MisaCukCuk_Entity.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MisaCukCuk_Infarstructure.Infarstructure.CustomerInfarstructure
{
    public interface ICustomerInfarstructure : IMisaCukCukContext<Customer>
    {
        Task<IEnumerable<Customer>> getById(Guid code);
        Task<IEnumerable<Customer>> getAllDataOfCustomer();
        Task<int> InsertCustomer(Customer customer);
        Task<int> editCustomerById(Customer customer);
        Task<int> deleteCustomerByCustomerCode(string code);
        Task<bool> checkExistIdOfCustomer(string code);
        Task<IEnumerable<Customer>> getCustomersByCustomerCodeAndPhongNumber(string customerCode, string phoneNumber);
    }
}
