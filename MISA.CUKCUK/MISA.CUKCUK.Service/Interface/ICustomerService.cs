using MISA.Common.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Service.Interface
{
    /// <summary>
    /// Interface CustomerService 
    /// </summary>
    /// CreatedBy Vtthien( 08/02/21)
    public interface ICustomerService: IBaseService<Customer>
    {
        ServiceResult InsertCustomer(Customer customer);

        ServiceResult UpdateCustomer(Guid id, Customer customer);
    }
}
