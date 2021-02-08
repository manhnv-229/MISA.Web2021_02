using CukCuk.BusinessLayer.Interfaces;
using CukCuk.Common.Models;
using CukCuk.DataLayer;
using CukCuk.DataLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CukCuk.BusinessLayer
{
    /// <summary>
    /// Base BusinessLayer
    /// </summary>
    /// <typeparam name="T">Object</typeparam>
    /// CreatedBy: DMThanh (06/02/2021)
    public class BaseBL<T>:IBaseBL<T>
    {
        #region Declare
        IDbConnector<T> _baseDL;
        protected ServiceResult _serviceResult;
        #endregion

        #region Constructor
        public BaseBL(IDbConnector<T> baseDL)
        {
            _serviceResult = new ServiceResult();
            _baseDL = baseDL;
        }
        #endregion

        #region Method
        /// <summary>
        /// Xóa bản ghi
        /// </summary>
        /// <param name="id">Id bản ghi</param>
        /// <returns></returns>
        /// CreatedBy: DMThanh (06/02/2021)
        public virtual ServiceResult Delete(string id)
        {
            
            _serviceResult.Data = _baseDL.Delete(id);
            
            if((int)_serviceResult.Data > 0)
                _serviceResult.Success = true;
            else
                _serviceResult.Success = false;

            return _serviceResult;
        }

        /// <summary>
        /// Lấy dữ liệu
        /// </summary>
        /// <returns></returns>
        /// CreatedBy: DMThanh (06/02/2021)
        public virtual ServiceResult GetData()
        {
            _serviceResult.Success = true;
            _serviceResult.Data = _baseDL.GetData();

            return _serviceResult;
        }

        /// <summary>
        /// Thêm mới bản ghi
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        /// CreatedBy: DMThanh (06/02/2021)
        public virtual ServiceResult Insert(T entity)
        {
            
            var errMsg = new ErrorMsg();

            var isValidated = ValidateInsertData(entity, errMsg);            
            if(isValidated)
            {
                _serviceResult.Success = true;
                _serviceResult.Data = _baseDL.Insert(entity);
            } else
            {
                _serviceResult.Success = false;
                _serviceResult.Data = errMsg;
            }
        
            return _serviceResult;
        }

        /// <summary>
        /// Cập nhật bản ghi
        /// </summary>
        /// <param name="entity">Object</param>
        /// <returns></returns>
        /// CreatedBy: DMThanh (06/02/2021)
        public ServiceResult Update(T entity)
        {
            
            var errMsg = new ErrorMsg();
           
            var isValid = ValidateUpdateData(entity, errMsg);
            // Kiểm tra và gửi lên tầng DataLayer 
            if (isValid)
            {
                _serviceResult.Success = true;
                _serviceResult.Data = _baseDL.Update(entity);
            }
            else
            {
                _serviceResult.Success = false;
                _serviceResult.Data = errMsg;
            }

            return _serviceResult;
        }

        /// <summary>
        /// Thực hiện validate dữ liệu khi thêm mới
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        /// CreatedBy
        protected virtual bool ValidateInsertData(T entity, ErrorMsg errMsg)
        {
            return true;
        }

        /// <summary>
        /// Thực hiện validate dữ liệu khi cập nhật
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>s</returns>
        /// CreatedBy
        protected virtual bool ValidateUpdateData(T entity, ErrorMsg errMsg)
        {
            return true;
        }
        #endregion
    }
}
