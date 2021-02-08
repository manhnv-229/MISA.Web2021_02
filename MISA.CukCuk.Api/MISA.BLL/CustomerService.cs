using Dapper;
using MISA.Common.Entities;
using MISA.Common.Enumrations;
using MISA.Common.Interfaces;
using MISA.Common.Models;
using System.Data;
using System.Data.Common;
using System.Linq;

namespace MISA.BLL
{
    public class CustomerService : BaseService<Customer>, ICustomerService
    {
        public CustomerService(IDbContext<Customer> dbContext) : base(dbContext)
        {

        }
    }
}
