using Common.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Interfaces
{
    interface ICustomerRepository: IDbContext<Customer>
    {
    }
}
