using Misa.BL.Interface.IDBContext;
using System;
using System.Collections.Generic;
using System.Text;

namespace Misa.DL.DbConnector
{
    class DbConnectorReplay : IDBConnector
    {
        public long Count<T>(List<string> fieldNames = null, List<string> values = null)
        {
            throw new NotImplementedException();
        }

        public int Delete<T>(string id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetData<T>(long page, long limmit, List<string> fieldNames = null, List<string> values = null)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetData<T>(string sql)
        {
            throw new NotImplementedException();
        }

        public int Insert<T>(T entity)
        {
            throw new NotImplementedException();
        }

        public int Update<T>(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
