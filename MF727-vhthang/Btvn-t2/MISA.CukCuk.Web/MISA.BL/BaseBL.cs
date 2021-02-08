using MISA.BL.Interfaces;
using MISA.Common;
using MISA.Common.Entities;
using MISA.Common.Properties;
using MISA.DL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.BL
{
    public class BaseBL<TEntity>:IBaseBL<TEntity>
    {

        IDbContext<TEntity> _dbContext;
        public BaseBL(IDbContext<TEntity> dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// Lấy toàn bộ dữ liệu
        /// </summary>
        /// <returns>Toàn bộ dữ liệu</returns>
        public IEnumerable<TEntity> GetAll()
        {
            var entity = _dbContext.GetAll();
            return entity;
        }

        /// <summary>
        /// Thêm một bản ghi
        /// </summary>
        /// <param name="entity">Object truyền vào</param>
        /// <returns>ServiceResult</returns>
        public ServiceResult Insert(TEntity entity)
        {
            var serviceResult = new ServiceResult();
            var isValid = Validate(entity);
            if(isValid.MISACode != MISACode.IsValid)
            {
                return isValid;
            }
            var query = _dbContext.Insert(entity);
            if(query > 0)
            {
                serviceResult.MISACode = MISACode.Success;
                serviceResult.Messenger = Resources.SuccessService_InsertSuccess;
                serviceResult.Data = query;
            }
            else
            {
                serviceResult.MISACode = MISACode.Success;
                serviceResult.Messenger = Resources.SuccessService_InsertNotSuccess;
                serviceResult.Data = query;
            }
            return serviceResult;
        }

        /// <summary>
        /// Kiểm tra dữ liệu
        /// </summary>
        /// <param name="entity">Dữ liệu truyền vào</param>
        /// <returns>ServiceResult</returns>
        protected virtual ServiceResult Validate(TEntity entity)
        {
            var serviceResult = new ServiceResult();
            serviceResult.MISACode = MISACode.IsValid;
            serviceResult.Messenger = Resources.SuccessService_IsVaid;
            serviceResult.Data = 1;
            return serviceResult;
        }

        /// <summary>
        /// Update dữ liệu theo Id
        /// </summary>
        /// <param name="entity">Object truyền vào</param>
        /// <returns>ServiceResult</returns>
        public ServiceResult Update(TEntity entity)
        {
            var serviceResult = new ServiceResult();
            //var isValid = Validate(entity);
            //if (isValid.MISACode != MISACode.IsValid)
            //{
            //    return isValid;
            //}
            var query = _dbContext.Update(entity);
            if (query > 0)
            {
                serviceResult.MISACode = MISACode.Success;
                serviceResult.Messenger = Resources.SuccessService_UpdateSuccess;
                serviceResult.Data = query;
            }
            else
            {
                serviceResult.MISACode = MISACode.Success;
                serviceResult.Messenger = Resources.SuccessService_UpdateNotSuccess;
                serviceResult.Data = query;
            }
            return serviceResult;
        }

        public ServiceResult Delete(TEntity entity)
        {
            var serviceResult = new ServiceResult();
            var query = _dbContext.Delete(entity);
            if (query > 0)
            {
                serviceResult.MISACode = MISACode.Success;
                serviceResult.Messenger = Resources.SuccessService_DeleteSuccess;
                serviceResult.Data = query;
            }
            else
            {
                serviceResult.MISACode = MISACode.Success;
                serviceResult.Messenger = Resources.SuccessService_DeleteNotSuccess;
                serviceResult.Data = query;
            }
            return serviceResult;
        }

    }
}
