using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.DataLayer.Interfaces
{
    public interface IOfficeRepository<TEntity>:IDbContext<TEntity>
    {

    }
}
