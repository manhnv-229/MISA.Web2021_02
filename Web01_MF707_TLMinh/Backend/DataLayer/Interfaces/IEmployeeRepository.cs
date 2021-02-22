using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.DataLayer.Interfaces
{
    public interface IEmployeeRepository<TEntity>:IDbContext<TEntity>
    {

    }
}
