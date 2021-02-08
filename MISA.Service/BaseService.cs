using MISA.Common.Enum;
using MISA.Common.Models;
using MISA.DataLayer;
using MISA.Service.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MISA.Service
{
    public class BaseService<T> : IBaseService<T>
    {
        protected IDbConnector _dbConnector;
        protected ServiceResult _serviceResult;

        public BaseService(IDbConnector dbConnector)
        {
            _dbConnector = dbConnector;
            _serviceResult = new ServiceResult();
        }
        /// <summary>
        /// Xóa đói tượng ra khỏi danh sách
        /// </summary>
        /// <typeparam name="T">Kiểu dữ liệu cần truyền vào</typeparam>
        /// <param name="id">Id của đối tượng cần xóa</param>
        /// <returns></returns>
        /// Created by PN Thuận : 2/1/2021
        public ServiceResult DeleteEntityById(string id)
        {
            return new ServiceResult()
            {
                Data = _dbConnector.DeleteById<Employee>(id),
                userMsg = new List<string>(),
                Code = EnumPattern.Success
            };
        }

        /// <summary>
        /// Lấy danh sách tất cả các đối tượng 
        /// </summary>
        /// <typeparam name="T">Kiểu dữ liệu truyền vào</typeparam>
        /// <returns></returns>
        /// Created by PN Thuận : 2/1/2021
        public ServiceResult GetAllData()
        {
            return new ServiceResult()
            {
                Data = _dbConnector.GetAllData<Employee>(),
                userMsg = new List<string>(),
                Code = EnumPattern.Success
            };
        }

        /// <summary>
        /// Thêm đối tượng vào danh sách
        /// </summary>
        /// <typeparam name="T">Kiểu dữ liệu truyền vào</typeparam>
        /// <param name="entity">Đối tượng cần chèn</param>
        /// <returns></returns>
        /// Created by PN Thuận : 2/1/2021
        public ServiceResult InsertEntity(T entity)
        {
            // validate data 
            ValidateObject(entity);
            if (_serviceResult.Code == EnumPattern.BadRequest)
            {
                return _serviceResult;
            }
            return new ServiceResult()
            {
                Data = _dbConnector.Insert<T>(entity),
                userMsg = new List<string> { MISA.Common.Properties.Resources.Msg_Success },
                Code = EnumPattern.Success
            };
        }

        /// <summary>
        /// Chỉnh sửa thông tin của đối tượng
        /// </summary>
        /// <typeparam name="T">Kiểu dữ liệu truyền vào</typeparam>
        /// <param name="entity">Đối tượng cần truyền</param>
        /// <param name="Id">Id của đối tượng đó</param>
        /// <returns></returns>
        /// Created by PN Thuận : 2/1/2021
        public ServiceResult ModifiedEntity(T entity, string Id)
        {
            var properties = typeof(T).GetProperties();

            Employee entityCheck = _dbConnector.GetById<Employee>(Id);
            // check trùng mã
            foreach (var property in properties)
            {
                var proValue = property.GetValue(entity);
                var proName = property.Name;
                // attribute là required thì phải nhập
                if ((property.IsDefined(typeof(Required), true)) && (proValue == null || proValue.ToString() == String.Empty))
                {
                    var requiredAttribute = property.GetCustomAttributes(typeof(Required), true).FirstOrDefault();
                    if (requiredAttribute != null)
                    {
                        var propertyText = (requiredAttribute as Required).PropertyName;
                        var errorMessenger = (requiredAttribute as Required).ErrorMessenger;
                        _serviceResult.userMsg.Add(errorMessenger == null ? $"{propertyText} không được phép để trống" : errorMessenger);
                    }
                    else
                    {
                        _serviceResult.userMsg.Add(MISA.Common.Properties.Resources.Error_Required);
                        _serviceResult.devMsg.Add(MISA.Common.Properties.Resources.Error_Required);
                    }
                    _serviceResult.Code = EnumPattern.BadRequest;

                }
                // check Duplicate
                if ((property.IsDefined(typeof(CheckDuplicate), true)))
                {
                    var requiredAttribute = property.GetCustomAttributes(typeof(CheckDuplicate), true).FirstOrDefault();
                    if (requiredAttribute != null && property.GetValue(entityCheck).ToString().Trim() != proValue.ToString().Trim())
                    {
                        var propertyText = (requiredAttribute as CheckDuplicate).PropertyName;
                        var errorMessenger = (requiredAttribute as CheckDuplicate).ErrorMessenger;
                        var sql = $"SELECT {proName} From {typeof(T).Name} Where {proName} = '{proValue}'";
                        var res = _dbConnector.GetAllData<T>(sql).FirstOrDefault();
                        if (res != null)
                        {
                            _serviceResult.userMsg.Add(errorMessenger == null ? $"{propertyText} không được phép trùng" : errorMessenger);
                            _serviceResult.devMsg.Add(errorMessenger == null ? $"{propertyText} không được phép trùng" : errorMessenger);
                            _serviceResult.Code = EnumPattern.BadRequest;
                        }
                    }
                }
                // check length
                if ((property.IsDefined(typeof(MaxLength), true)))
                {
                    var requiredAttribute = property.GetCustomAttributes(typeof(MaxLength), true).FirstOrDefault();
                    if (requiredAttribute != null)
                    {
                        var propertyText = (requiredAttribute as MaxLength).PropertyName;
                        var errorMessenger = (requiredAttribute as MaxLength).ErrorMessenger;
                        var maxLength = (requiredAttribute as MaxLength).Length;
                        if (proValue.ToString().Trim().Length > maxLength)
                        {
                            _serviceResult.userMsg.Add(errorMessenger == null ? $"{propertyText} không được phép vượt quá {maxLength} ký tự" : errorMessenger);
                            _serviceResult.devMsg.Add(errorMessenger == null ? $"{propertyText} không được phép vượt quá {maxLength} ký tự" : errorMessenger);
                            _serviceResult.Code = EnumPattern.BadRequest;
                        }
                    }
                }
            }
            if (_serviceResult.Code == EnumPattern.BadRequest)
            {
                return _serviceResult;
            }
            return new ServiceResult()
            {
                Data = _dbConnector.ModifiedEntity<T>(entity),
                userMsg = new List<string> { MISA.Common.Properties.Resources.Msg_Success },
                Code = EnumPattern.Success
            };
        }
        /// <summary>
        /// Validate data
        /// </summary>
        /// <typeparam name="T">Kiểu dữ liệu cần truyền</typeparam>
        /// <param name="entity">Đối tượng cần truyền</param>
        /// Created by PN Thuận : 2/1/2021
        protected void ValidateObject(T entity)
        {
            var properties = typeof(T).GetProperties();
            foreach (var property in properties)
            {
                var proValue = property.GetValue(entity);
                var proName = property.Name;
                // attribute là required thì phải nhập
                if ((property.IsDefined(typeof(Required), true)) && (proValue == null || proValue.ToString() == String.Empty))
                {
                    var requiredAttribute = property.GetCustomAttributes(typeof(Required), true).FirstOrDefault();
                    if (requiredAttribute != null)
                    {
                        var propertyText = (requiredAttribute as Required).PropertyName;
                        var errorMessenger = (requiredAttribute as Required).ErrorMessenger;
                        _serviceResult.userMsg.Add(errorMessenger == null ? $"{propertyText} không được phép để trống" : errorMessenger);
                    }
                    else
                    {
                        _serviceResult.userMsg.Add(MISA.Common.Properties.Resources.Error_Required);
                        _serviceResult.devMsg.Add(MISA.Common.Properties.Resources.Error_Required);
                    }
                    _serviceResult.Code = EnumPattern.BadRequest;

                }
                // check duplicate
                if ((property.IsDefined(typeof(CheckDuplicate), true)))
                {
                    var requiredAttribute = property.GetCustomAttributes(typeof(CheckDuplicate), true).FirstOrDefault();
                    if (requiredAttribute != null)
                    {
                        var propertyText = (requiredAttribute as CheckDuplicate).PropertyName;
                        var errorMessenger = (requiredAttribute as CheckDuplicate).ErrorMessenger;
                        var sql = $"SELECT {proName} From {typeof(T).Name} Where {proName} = '{proValue}'";
                        var res = _dbConnector.GetAllData<T>(sql).FirstOrDefault();
                        if (res != null)
                        {
                            _serviceResult.userMsg.Add(errorMessenger == null ? $"{propertyText} không được phép trùng" : errorMessenger);
                            _serviceResult.devMsg.Add(errorMessenger == null ? $"{propertyText} không được phép trùng" : errorMessenger);
                            _serviceResult.Code = EnumPattern.BadRequest;
                        }
                    }



                }
                if ((property.IsDefined(typeof(MaxLength), true)))
                {
                    var requiredAttribute = property.GetCustomAttributes(typeof(MaxLength), true).FirstOrDefault();
                    if (requiredAttribute != null)
                    {
                        var propertyText = (requiredAttribute as MaxLength).PropertyName;
                        var errorMessenger = (requiredAttribute as MaxLength).ErrorMessenger;
                        var maxLength = (requiredAttribute as MaxLength).Length;
                        if (proValue.ToString().Trim().Length > maxLength)
                        {
                            _serviceResult.userMsg.Add(errorMessenger == null ? $"{propertyText} không được phép vượt quá {maxLength} ký tự" : errorMessenger);
                            _serviceResult.devMsg.Add(errorMessenger == null ? $"{propertyText} không được phép vượt quá {maxLength} ký tự" : errorMessenger);
                            _serviceResult.Code = EnumPattern.BadRequest;
                        }
                    }



                }
            }
        }
    }
}
