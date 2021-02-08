using System;
using System.Collections.Generic;
using System.Text;
using Dapper;
using MISA.BTL.Business.Interfaces;
using MISA.BTL.Common;
using MISA.BTL.Database;
using MISA.BTL.Database.Interfaces;

namespace MISA.BTL.Business
{
    public class BaseBusiness<T>:IBaseBusiness<T>
    {
        IDbConnector<T> _dbConnector;
        public BaseBusiness(IDbConnector<T> dbConnector)
        {
            _dbConnector = dbConnector;
        }
        public virtual ServiceResult GetData()
        {
            var serviceResult = new ServiceResult();

            serviceResult.Data = _dbConnector.GetData();
            serviceResult.Success = true;

            return serviceResult;
        }

        public virtual ServiceResult Insert(T entity)
        {
            var serviceResult = new ServiceResult();
            var errorMsg = new ErrorMsg();

            var isValid = ValidateData(entity, errorMsg);

            if (isValid == true)
            {
                serviceResult.Success = true;
                serviceResult.Data = _dbConnector.Insert(entity);
                return serviceResult;
            }
            else
            {
                serviceResult.Success = false;
                serviceResult.Data = errorMsg;
                return serviceResult;
            }
        }

        public virtual ServiceResult Update(T entity)
        {
            var serviceResult = new ServiceResult();
            var errorMsg = new ErrorMsg();

            var isValid = ValidateData(entity, errorMsg);

            if (isValid == true)
            {
                serviceResult.Success = true;
                serviceResult.Data = _dbConnector.Update(entity);
                return serviceResult;
            }
            else
            {
                serviceResult.Success = false;
                serviceResult.Data = errorMsg;
                return serviceResult;
            }
        }

        public virtual ServiceResult Delete(string id)
        {
            var serviceResult = new ServiceResult();
            serviceResult.Data = _dbConnector.Delete(id);
            serviceResult.Success = true;
            return serviceResult;
        }

        protected virtual bool ValidateData(T entity, ErrorMsg errorMsg = null)
        {
            return true;
        }
    }
}
