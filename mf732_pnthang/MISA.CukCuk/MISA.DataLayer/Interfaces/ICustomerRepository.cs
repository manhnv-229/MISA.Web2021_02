using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.DataLayer.Interfaces
{
    interface ICustomerRepository:IDbContext<CustomerRepository>
    {
    }
}
