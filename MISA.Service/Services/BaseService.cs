using System;
using System.Collections.Generic;
using System.Text;
using MISA.Common.Models;
using MISA.DataLayer;
using MISA.Service.Interface;

namespace MISA.Service
{
    public class BaseService<TEntity> : IBaseService<TEntity>
    {
        #region DECLARE
        protected IDBConnector<TEntity> _dBConnector;
        #endregion

        #region Constructor
        public BaseService(IDBConnector<TEntity> dbconnection)
        {
            this._dBConnector = dbconnection;
        }
        #endregion

        #region Method
        /// <summary>
        /// Lấy toàn bộ dữ liệu
        /// </summary>
        /// <returns>ServiceResult</returns>
        /// Created By: TXTrinh (08/02/2021)
        public virtual ActionServiceResult GetData()
        {
            //var _dBConnector = new DBConnector<TEntity>();
            var _actionServiceResult = new ActionServiceResult();
            _actionServiceResult.Data = _dBConnector.GetAll();
            return _actionServiceResult;
        }
        #endregion
    }
}
