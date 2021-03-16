using MISA.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.DataLayer.Interfaces
{
    public interface IEmployeeeRepository<TEntity> : IDbContext<TEntity>
    {

    }
}
