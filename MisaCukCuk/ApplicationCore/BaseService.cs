using ApplicationCore.Interfaces;
using Common.Model;
using Common.Other;
using Infrastructure;
using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace ApplicationCore
{
    /// <summary>
    /// Lớp cơ sở cho tầng nghiệp vụ
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public class BaseService<TEntity> : IBaseService<TEntity>
    {
        #region Declare
        private IDbContext<TEntity> _dbContext;
        private ServiceResult _serviceResult;
        private ErrMsg _errMsg;
        #endregion
        #region Constructor
        public BaseService(IDbContext<TEntity> dbContext)
        {
            _dbContext = dbContext;
            _serviceResult = new ServiceResult();
            _errMsg = new ErrMsg();
        }
        #endregion

        #region Method
        public ServiceResult Delete(Guid id)
        {
            int deleted = _dbContext.Delete(id);
            if(deleted > 0)
            {
                _errMsg.DevMsg = Common.Properties.Resources.DeleteSuccessed;
                _errMsg.UserMsg.Add(Common.Properties.Resources.DeletedNotification);
                _errMsg.ErrorCode = Common.Properties.Resources.DeletedCode;
            }
            else
            {
                _errMsg.DevMsg = Common.Properties.Resources.DeleteFailed;
                _errMsg.UserMsg.Add(Common.Properties.Resources.DeleteFailedNotification);
                _errMsg.ErrorCode = Common.Properties.Resources.DeleteFailedCode;
            }
            _serviceResult.Data = _errMsg;
            return _serviceResult;
        }

        public ServiceResult GetData() {
            var serviceResult = new ServiceResult();
            var dbContext = new IDBContext<TEntity>();
            serviceResult.Data = dbContext.GetAll();
            return serviceResult;
        }

        public ServiceResult Insert(TEntity entity)
        {
            ValidateData(entity);
            int inserted = _serviceResult.Success ? _dbContext.Insert(entity) : 0 ;
            if (inserted > 0)
            {
                _errMsg.DevMsg = Common.Properties.Resources.InsertSuccessed;
                _errMsg.UserMsg.Add(Common.Properties.Resources.InsertedNotification);
                _errMsg.ErrorCode = Common.Properties.Resources.InsertedCode;
            }
            else
            {
                _errMsg.DevMsg = Common.Properties.Resources.InsertFailed;
                _errMsg.UserMsg.Add(Common.Properties.Resources.InsertFailedNotification);
                _errMsg.ErrorCode = Common.Properties.Resources.InsertFailedCode;
            }
            _serviceResult.Data = _errMsg;
            return _serviceResult;
        }

        public ServiceResult Update(TEntity entity)
        {
            ValidateData(entity);
            int updated = _serviceResult.Success ? _dbContext.Update(entity) : 0;
            if (updated > 0)
            {
                _errMsg.DevMsg = Common.Properties.Resources.UpdateSuccessed;
                _errMsg.UserMsg.Add(Common.Properties.Resources.UpdatedNotification);
                _errMsg.ErrorCode = Common.Properties.Resources.UpdatedCode;
            }
            else
            {
                _errMsg.DevMsg = Common.Properties.Resources.UpdateFailed;
                _errMsg.UserMsg.Add(Common.Properties.Resources.UpdateFailedNotification);
                _errMsg.ErrorCode = Common.Properties.Resources.UpdateFailedCode;
            }
            _serviceResult.Data = _errMsg;
            return _serviceResult;
        }

        public void ValidateData(TEntity entity)
        {
            CheckExist(entity);
            CheckEmpty(entity);
            CheckNumberFormat(entity);
            CheckEmailFormat(entity);
        }
        /// <summary>
        /// Kiểm tra dữ liệu sự tồn tại của đối tượng trong Cơ sở dữ liệu
        /// </summary>
        /// <param name="entity">Đối tượng cần kiểm tra</param>
        private void CheckExist(TEntity entity)
        {
            var properties = typeof(TEntity).GetProperties();

            foreach (var property in properties)
            {
                var propValue = property.GetValue(entity);
                var propName = property.Name;
                if (property.IsDefined(typeof(CheckExist), true))
                {

                    var requiredAttribute = property.GetCustomAttributes(typeof(CheckExist), true).FirstOrDefault();
                    if (requiredAttribute != null)
                    {
                        var propertyText = (requiredAttribute as CheckExist).PropertyName;
                        var errorMsg = (requiredAttribute as CheckExist).ErrorMessenger;

                        if (_dbContext.CheckExist(propName, (string)propValue) == true)
                        {
                            if (errorMsg != null) {
                                _errMsg.UserMsg.Add(errorMsg);
                            }
                            else
                            {
                                _errMsg.UserMsg.Add($"{propertyText} đã tồn tại trên hệ thống.");
                            }
                            _serviceResult.Data = _errMsg;
                            _serviceResult.Success = false;
                            _serviceResult.StatusCode = Common.Properties.Resources.ValidateFailedCode;
                        }


                    }


                }
            }
        }
        /// <summary>
        /// Kiểm tra dữ liệu bắt buộc nhập
        /// </summary>
        /// <param name="entity"></param>
        private void CheckEmpty(TEntity entity)
        {
            var properties = typeof(TEntity).GetProperties();

            foreach (var property in properties)
            {
                var propValue = property.GetValue(entity);
                // Nếu có attribute là [Required] thì thực hiện kiểm tra bắt buộc nhập
                if (property.IsDefined(typeof(Required), true) && (propValue == null || propValue.ToString() == string.Empty))
                {
                    var requiredAttribute = property.GetCustomAttributes(typeof(Required), true).FirstOrDefault();
                    if (requiredAttribute != null)
                    {
                        var propertyText = (requiredAttribute as Required).PropertyName;
                        var errorMsg = (requiredAttribute as Required).ErrorMessenger;
                        if (errorMsg != null)
                        {
                            _errMsg.UserMsg.Add(errorMsg);
                        }
                        else
                        {
                            _errMsg.UserMsg.Add($"{propertyText} không được phép để trống.");
                        }
                    }
                    _serviceResult.Data = _errMsg;
                    _serviceResult.Success = false;
                    _serviceResult.StatusCode = Common.Properties.Resources.ValidateFailedCode;

                }
            }
        }
        /// <summary>
        /// Kiểm tra định dạng số của dữ liệu
        /// </summary>
        /// <param name="entity"></param>
        private void CheckNumberFormat(TEntity entity)
        {
            var properties = typeof(TEntity).GetProperties();

            foreach (var property in properties)
            {
                Regex regex = new Regex(@"\d+");
                var propValue = property.GetValue(entity);
                // Nếu có attribute là [CheckNumberFormat] thì thực hiện kiểm tra dữ liệu định dạng số
                if (property.IsDefined(typeof(CheckNumberFormat), true) && !regex.IsMatch(propValue.ToString()))
                {
                    var requiredAttribute = property.GetCustomAttributes(typeof(CheckNumberFormat), true).FirstOrDefault();
                    if (requiredAttribute != null)
                    {
                        var propertyText = (requiredAttribute as CheckNumberFormat).PropertyName;
                        var errorMsg = (requiredAttribute as CheckNumberFormat).ErrorMessenger;
                        if (errorMsg != null)
                        {
                            _errMsg.UserMsg.Add(errorMsg);
                        }
                        else
                        {
                            _errMsg.UserMsg.Add($"{propertyText} chỉ được nhập số.");
                        }
                    }
                    _serviceResult.Data = _errMsg;
                    _serviceResult.Success = false;
                    _serviceResult.StatusCode = Common.Properties.Resources.ValidateFailedCode;

                }
            }
        }
        /// <summary>
        /// Hàm kiểm tra định dạng Email
        /// </summary>
        /// <param name="entity"></param>
        private void CheckEmailFormat(TEntity entity)
        {
            var properties = typeof(TEntity).GetProperties();

            foreach (var property in properties)
            {
                Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
                var propValue = property.GetValue(entity);
                // Nếu có attribute là [CheckEmailFormat] thì thực hiện kiểm tra dữ liệu định dạng số
                if (property.IsDefined(typeof(CheckEmailFormat), true) && !regex.IsMatch(propValue.ToString()))
                {
                    var requiredAttribute = property.GetCustomAttributes(typeof(CheckEmailFormat), true).FirstOrDefault();
                    if (requiredAttribute != null)
                    {
                        var propertyText = (requiredAttribute as CheckEmailFormat).PropertyName;
                        var errorMsg = (requiredAttribute as CheckEmailFormat).ErrorMessenger;
                        if (errorMsg != null)
                        {
                            _errMsg.UserMsg.Add(errorMsg);
                        }
                        else
                        {
                            _errMsg.UserMsg.Add($"{propertyText} sai định dạng.");
                        }
                    }
                    _serviceResult.Data = _errMsg;
                    _serviceResult.Success = false;
                    _serviceResult.StatusCode = Common.Properties.Resources.ValidateFailedCode;

                }
            }
        }

        #endregion
    }
}