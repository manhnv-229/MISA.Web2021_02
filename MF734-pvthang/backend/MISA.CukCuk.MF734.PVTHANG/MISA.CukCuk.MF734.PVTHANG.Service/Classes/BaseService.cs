using MISA.CukCuk.MF734.PVTHANG.Common.Models;
using MISA.CukCuk.MF734.PVTHANG.DataLayer.Classes;
using MISA.CukCuk.MF734.PVTHANG.DataLayer.Interfaces;
using MISA.CukCuk.MF734.PVTHANG.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MISA.CukCuk.MF734.PVTHANG.Service.Classes
{
    public class BaseService<TEntity> : IBaseService<TEntity>
    {
        protected IDatabaseConnector _databaseConnector;
        protected ServiceResult _serviceResult;
        protected String _className;
        public BaseService(IDatabaseConnector databaseConnector)
        {
            _databaseConnector = databaseConnector;
            _serviceResult = new ServiceResult();
            _className = typeof(TEntity).Name;
        }

        /// <summary>
        /// Lấy tất cả dữ liệu
        /// </summary>
        /// <returns>Danh sách dữ liệu</returns>
        /// CREATED BY: PHẠM VIỆT THẮNG
        public ServiceResult GetAll()
        {
            //Get
            var res = _databaseConnector.GetList<TEntity>($"Proc_GetAll{_className}s", new { });
            _serviceResult.Data = res;
            _serviceResult.Message = Common.Properties.Resources.Success;
            if (res != null && res.Count() > 0)
                _serviceResult.Code = Common.Enum.ResultCode.Ok;
            else
            {
                _serviceResult.Message = Common.Properties.Resources.NoContent;
                _serviceResult.Code = Common.Enum.ResultCode.NoContent;
            }
            return _serviceResult;
        }

        /// <summary>
        /// Lấy dứ liệu theo id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// CREATED BY: PHẠM VIỆT THẮNG
        public virtual ServiceResult GetById(String id)
        {
            //Get
            var res = _databaseConnector.GetFirst<TEntity>($"Proc_Get{_className}ById", new { Id = id });
            _serviceResult.Data = res;
            _serviceResult.Message = Common.Properties.Resources.Success;
            if (res != null)
                _serviceResult.Code = Common.Enum.ResultCode.Ok;
            else
            {
                _serviceResult.Message = Common.Properties.Resources.NoContent;
                _serviceResult.Code = Common.Enum.ResultCode.NoContent;
            }
            return _serviceResult;
        }

        /// <summary>
        /// Thêm dữ liệu
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        /// CREATED BY: PHẠM VIỆT THẮNG
        public ServiceResult Insert(TEntity entity)
        {
            //validate
            if (ValidateData(entity) == false)
                return _serviceResult;
            //Insert
            var res = _databaseConnector.Change($"Proc_Insert{_className}", entity);
            _serviceResult.Data = res;
            _serviceResult.Message = Common.Properties.Resources.Success;
            if (res > 0)
                _serviceResult.Code = Common.Enum.ResultCode.Created;
            else
            {
                _serviceResult.Message = Common.Properties.Resources.Fail;
                _serviceResult.Code = Common.Enum.ResultCode.BadRequest;
            }
            return _serviceResult;
        }

        /// <summary>
        /// Sửa dữ liệu
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        /// CREATED BY: PHẠM VIỆT THẮNG
        public ServiceResult Update(TEntity entity)
        {
            //validate
            if (ValidateData(entity) == false)
                return _serviceResult;
            //Update
            var res = _databaseConnector.Change($"Proc_Update{_className}", entity);
            _serviceResult.Data = res;
            _serviceResult.Message = Common.Properties.Resources.Success;
            if (res > 0)
                _serviceResult.Code = Common.Enum.ResultCode.Ok;
            else
            {
                _serviceResult.Message = Common.Properties.Resources.Fail;
                _serviceResult.Code = Common.Enum.ResultCode.BadRequest;
            }
            return _serviceResult;
        }

        /// <summary>
        /// Xóa dữ liệu
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// CREATED BY: PHẠM VIỆT THẮNG
        public virtual ServiceResult Delete(String id)
        {
            //Delete
            var res = _databaseConnector.Change($"Proc_Delete{_className}", new { Id = id });
            _serviceResult.Data = res;
            _serviceResult.Message = Common.Properties.Resources.Success;
            if (res > 0)
                _serviceResult.Code = Common.Enum.ResultCode.Ok;
            else
            {
                _serviceResult.Message = Common.Properties.Resources.Fail;
                _serviceResult.Code = Common.Enum.ResultCode.BadRequest;
            }
            return _serviceResult;
        }

        /// <summary>
        /// Validate dữ liệu
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        /// CREATED BY: PHẠM VIỆT THẮNG
        protected virtual bool ValidateData(TEntity entity)
        {
            bool flag = true;
            var properties = typeof(TEntity).GetProperties();
            foreach (var property in properties)
            {
                var value = property.GetValue(entity);
                //validate required
                if (property.IsDefined(typeof(Required), true) && (value == null || value.ToString().Trim() == String.Empty))
                {
                    var propertyName = property.GetCustomAttributes(typeof(Required), true).FirstOrDefault();
                    if (propertyName != null)
                    {
                        var message = (propertyName as Required).propertyName + " " + Common.Properties.Resources.ErrorRequired + ". ";
                        if ((propertyName as Required).errorMessage != null) message = (propertyName as Required).errorMessage;
                        _serviceResult.Message = _serviceResult.Message == null ? message : (_serviceResult.Message + message);
                    }
                    _serviceResult.Code = Common.Enum.ResultCode.BadRequest;
                    flag = false;
                }
                //validate duplicate
                if (property.IsDefined(typeof(CheckDuplicate), true) && _databaseConnector.GetFirst<int>($"Proc_Check{property.Name}", entity) > 0)
                {
                    var propertyName = property.GetCustomAttributes(typeof(CheckDuplicate), true).FirstOrDefault();
                    if (propertyName != null)
                    {
                        var message = (propertyName as CheckDuplicate).propertyName + " " + Common.Properties.Resources.ErrorDuplicate + ". ";
                        if ((propertyName as CheckDuplicate).errorMessage != null) message = (propertyName as CheckDuplicate).errorMessage;
                        _serviceResult.Message = _serviceResult.Message == null ? message : (_serviceResult.Message + message);
                    }
                    _serviceResult.Code = Common.Enum.ResultCode.BadRequest;
                    flag = false;
                }
            }
            if (flag == false) _serviceResult.Message = _serviceResult.Message.Trim();
            return flag;
        }
    }
}
