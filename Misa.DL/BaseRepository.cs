using Microsoft.Extensions.Configuration;
using Misa.BL.Interface.IDBContext;
using Misa.BL.Interface.IRepository;
using Misa.CukCuk_3.DL.DbConnector;
using System;
using System.Collections.Generic;
using System.Text;

namespace Misa.DL
{
    public class BaseRepository<T> : IBaseRepository<T>
    {
        IDBConnector _iDbConnector;
        public BaseRepository(IDBConnector iDBConnector)
        {
            _iDbConnector = iDBConnector;
        }

        public IEnumerable<T> GEtDataBySQL(string sql)
        {
            return _iDbConnector.GetData<T>(sql);
        }

        public IEnumerable<T> GetData(long page, long limmit, List<string> fieldNames = null, List<string> values = null)
        {
            return _iDbConnector.GetData<T>(page, limmit, fieldNames, values);
        }
        
        public int InsertEntity(T entity)
        {
            return _iDbConnector.Insert<T>(entity);
        }

        public int UpdateEntity(T entity)
        {
            return _iDbConnector.Update<T>(entity);
        }

        public long CountEntity(List<string> fieldNames = null, List<string> values = null)
        {
            return _iDbConnector.Count<T>(fieldNames, values);
        }

        public int DeleteEntity(string id)
        {
            return _iDbConnector.Delete<T>(id);
        }

    }
}
