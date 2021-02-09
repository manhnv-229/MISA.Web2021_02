using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace MISA.DataLayer
{
    public interface IDBConnector<TEntity>
    {
        IEnumerable<TEntity> GetAll();
    }
}
