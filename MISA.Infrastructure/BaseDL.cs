using MISA.Infrastructure.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Infrastructure
{
    /// <summary>
    /// Tầng dl dùng chung
    /// </summary>
    /// CreatedBy: PNVĐ(08/02/2021)
    public class BaseDL<T>:DbConnector, IBaseDL<T>
    {
        #region DECLARE
        DbConnector dbConnector = new DbConnector();
        #endregion

        #region Methods
        public IEnumerable<T> GetData()
        {
            return dbConnector.GetData<T>();
        }

        public int InsertData(T entity)
        {
            return dbConnector.Insert<T>(entity);
        }

        public int UpdateData(T entity)
        {
            return dbConnector.Update<T>(entity);
        }
        #endregion
    }
}
