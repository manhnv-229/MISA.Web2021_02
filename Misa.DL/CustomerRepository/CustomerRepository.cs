using Dapper;
using Microsoft.Extensions.Configuration;
using System.Linq;
using System.Data;
using Misa.BL.Entity;
using Misa.BL.Interface.IRepository;
using System.Collections.Generic;
using Misa.BL.Interface.IDBContext;

namespace Misa.DL.CustomerRepository
{
    public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
    {
        IDBConnector _iDbConnector;
        public CustomerRepository(IDBConnector iDbConnector) : base(iDbConnector)
        {
            _iDbConnector = iDbConnector;
        }


    }
}
