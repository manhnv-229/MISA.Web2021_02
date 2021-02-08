using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace MISA.CukCuk.MF734.PVTHANG.DataLayer.Interfaces
{
    public interface IDatabaseConnector
    {
        TEntity GetFirst<TEntity>(String procName, Object input, CommandType type = CommandType.StoredProcedure);
        IEnumerable<TEntity> GetList<TEntity>(String procName, Object input, CommandType type = CommandType.StoredProcedure);
        int Change(String procName, Object input, CommandType type = CommandType.StoredProcedure);
    }
}
