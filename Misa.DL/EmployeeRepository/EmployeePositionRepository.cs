using Microsoft.Extensions.Configuration;
using Misa.BL.Interface.IRepository;
using Misa.BL.Entity;
using Misa.BL.Interface.IDBContext;

namespace Misa.DL.EmployeeRepository
{
    public class EmployeePositionRepository : BaseRepository<EmployeePosition>, IEmployeePositionRepository
    {
        IDBConnector _iDbConnector;
        public EmployeePositionRepository(IDBConnector iDbConnector) : base(iDbConnector)
        {
            _iDbConnector = iDbConnector;
        }
    }
}
