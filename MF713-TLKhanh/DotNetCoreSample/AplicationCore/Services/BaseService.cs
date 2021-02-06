using AplicationCore.Entities;
using AplicationCore.Interfaces;
using Dapper;
using System.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AplicationCore.Services
{
    public class BaseService<T> : IBaseService<T>
    {
        #region Declare
        /// <summary>
        /// Base Repository: Chứa các phương thức thao tác với dữ liệu
        /// </summary>
        IBaseRepository<T> _baseRepository;
        /// <summary>
        /// ServiceResult: Chứa trạng thái và dữ liệu nhận được...
        /// </summary>
        ServiceResult _serviceResult;
        /// <summary>
        /// ErrorMsg: Chứa các câu thông báo lỗi, mã lỗi...
        /// </summary>
        ErrorMsg _errorMsg;
        /// <summary>
        /// Tên của bảng trong csdl
        /// </summary>
        string className;
        #endregion

        #region Constructor
        public BaseService(IBaseRepository<T> baseRepository)
        {
            _baseRepository = baseRepository;
            _serviceResult = new ServiceResult();
            _errorMsg = new ErrorMsg();
            className = typeof(T).Name;
        }

        #endregion

        #region Method

        public ServiceResult GetEntities()
        {
            var entities = _baseRepository.Get() as List<T>;
            if(entities.Count > 0)
            {
                _serviceResult.Success = true;
                _serviceResult.Data = entities;
            }
            return _serviceResult;
        }

        public ServiceResult GetEntity(string id)
        {
            var res = _baseRepository.GetById(id);
            if(res == null)
                return _serviceResult;
            _serviceResult.Data = res;
            _serviceResult.Success = true;
            return _serviceResult;

        }

        public ServiceResult InsertEntity(T entity)
        {
            bool isValid = Validate(entity, _errorMsg);
            if(isValid == true)
            {
                var res = _baseRepository.Insert(entity);
                _serviceResult.Success = true;
                _serviceResult.Data = res;
                return _serviceResult;
            }
            _serviceResult.Data = _errorMsg;
            return _serviceResult;
            
        }

        public ServiceResult UpdateEntity(string id, T entity)
        {
            bool isValid = Validate(entity, _errorMsg, id);
            if (isValid == true)
            {
                var res = _baseRepository.Update(id, entity);
                if(res == 0)
                {
                    _errorMsg.UserMsg.Add("Khách hàng không tồn tại trong hệ thống, vui lòng kiểm tra lại");
                    _serviceResult.Data = _errorMsg;
                    return _serviceResult;
                }
                _serviceResult.Success = true;
                _serviceResult.Data = res;
                return _serviceResult;
            }
            _serviceResult.Data = _errorMsg;
            return _serviceResult;
        }

        public ServiceResult DeleteEntity(string id)
        {
            var res = _baseRepository.Delete(id);
            if(res == 1)
            {
                _serviceResult.Success = true;
                _serviceResult.Data = res;
                return _serviceResult;
            }
            _errorMsg.UserMsg.Add("Khách hàng không tồn tại trong hệ thống, vui lòng kiểm tra lại");
            _serviceResult.Data = _errorMsg;
            return _serviceResult;
        }
        public virtual bool Validate(T entity, ErrorMsg errorMsg = null, string id = null)
        {
            return true;
        }
        #endregion

    }
}
