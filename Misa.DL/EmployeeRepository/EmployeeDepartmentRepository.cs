using Microsoft.Extensions.Configuration;
using Misa.BL.Interface.IRepository;
using Misa.BL.Entity;
using Misa.BL.Interface.IDBContext;

namespace Misa.DL.EmployeeRepository
{
    public class EmployeeDepartmentRepository : BaseRepository<EmployeeDepartment>, IEmployeeDepartmentRepository
    {
        IDBConnector _iDbConnector;
        public EmployeeDepartmentRepository(IDBConnector iDbConnector) : base(iDbConnector)
        {
            _iDbConnector = iDbConnector;
        }
    }
}
