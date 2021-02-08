using System;
using System.Collections.Generic;
using System.Text;
using MISA.Common.Models;
using MISA.DataLayer;

namespace MISA.Service
{
    public class BaseService<TEntity>
    {
        //DBConnector<TEntity> _dBConnector;
        //ActionServiceResult _actionServiceResult;
        //string className = typeof(TEntity).Name;

        /// <summary>
        /// Lấy toàn bộ dữ liệu
        /// </summary>
        /// <returns>ServiceResult</returns>
        /// Created By: TXTrinh (08/02/2021)
        public ActionServiceResult GetData()
        {
            var _dBConnector = new DBConnector<TEntity>();
            var _actionServiceResult = new ActionServiceResult();
            _actionServiceResult.Data = _dBConnector.GetAll();
            return _actionServiceResult;
        }
    }
}
