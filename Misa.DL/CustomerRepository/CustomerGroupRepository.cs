using Microsoft.Extensions.Configuration;
using Misa.BL.Interface.IRepository;
using Misa.BL.Entity;
using Misa.BL.Interface.IDBContext;

namespace Misa.DL.CustomerRepository
{
    public class CustomerGroupRepository : BaseRepository<CustomerGroup>, ICustomerGroupRepository
    {
        IDBConnector _iDbConnector;
        public CustomerGroupRepository(IDBConnector iDbConnector) : base(iDbConnector)
        {
            _iDbConnector = iDbConnector;
        }
    }
}
