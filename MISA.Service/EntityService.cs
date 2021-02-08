using Microsoft.AspNetCore.Mvc;
using MISA.Common.Enum;
using MISA.Common.Models;
using MISA.Common;
using MISA.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MISA.Service.interfaces;

namespace MISA.Service
{
    public class EntityService : BaseService<Employee>, IEmployeeService
    {
        #region Declare
        IDbConnector _dbConnector;
        ServiceResult _serviceResult;
        #endregion
        #region Constructor
        public EntityService(IDbConnector dbConnector)
        {
            _dbConnector = dbConnector;
            _serviceResult = new ServiceResult();
        }
        #endregion
        #region Method
        /// <summary>
        /// Lấy danh sách tất cả các đối tượng 
        /// </summary>
        /// <typeparam name="T">Kiểu dữ liệu truyền vào</typeparam>
        /// <returns></returns>
        /// Created by PN Thuận : 2/1/2021
        public ServiceResult GetAllData<T>()
        {
            return new ServiceResult()
            {
                Data = _dbConnector.GetAllData<T>(),
                userMsg = new List<string>(),
                Code = EnumPattern.Success
            };
        }
        /// <summary>
        /// Lấy danh sách theo trang 
        /// </summary>
        /// <typeparam name="T">Kiểu dữ liệu truyền vào</typeparam>
        /// <param name="pageNumber">Vị trí</param>
        /// <param name="limit">Giới hạn bản ghi</param>
        /// <returns></returns>
        /// Created by PN Thuận : 2/1/2021
        public ServiceResult GetAllData<T>(int pageNumber, int limit)
        {
            return new ServiceResult()
            {
                Data = _dbConnector.GetAllData<T>(pageNumber, limit),
                userMsg = new List<string>(),
                Code = EnumPattern.Success
            };
        }
        /// <summary>
        /// Trả về mã lớn nhất của đối tượng
        /// </summary>
        /// <typeparam name="T">Kiểu dữ liệu truyền vào</typeparam>
        /// <returns></returns>
        /// Created by PN Thuận : 2/1/2021
        public ServiceResult GetMaxCode<T>()
        {
            return new ServiceResult()
            {
                Data = _dbConnector.GetMaxCode<T>(),
                userMsg = new List<string>(),
                Code = EnumPattern.Success
            };
        }
        /// <summary>
        /// Trả về danh sách các đối tượng theo vị trí, chức vụ
        /// </summary>
        /// <typeparam name="T">Kiểu dữ liệu truyền vào</typeparam>
        /// <param name="position">Tên vị trí, chức vụ</param>
        /// <returns></returns>
        /// Created by PN Thuận : 2/1/2021
        public ServiceResult GetAllEmployeeByPosition<T>(string position)
        {
            return new ServiceResult()
            {
                Data = _dbConnector.GetAllEmployeeByPosition<T>(position),
                userMsg = new List<string>(),
                Code = EnumPattern.Success
            };
        }
        /// <summary>
        /// Trả vè danh sách các đối tượng theo phòng ban
        /// </summary>
        /// <typeparam name="T">Kiểu dữ liệu truyền vào</typeparam>
        /// <param name="department">Tên phòng ban</param>
        /// <returns></returns>
        /// Created by PN Thuận : 2/1/2021
        public ServiceResult GetAllEmployeeByDepartment<T>(string department)
        {
            return new ServiceResult()
            {
                Data = _dbConnector.GetAllEmployeeByDepartment<T>(department),
                userMsg = new List<string>(),
                Code = EnumPattern.Success
            };
        }
        /// <summary>
        /// Lọc danh sách các đối tượng theo Mã, Họ tên, Số điện thoại, Vị trí/ Chức vụ, Phòng ban
        /// </summary>
        /// <typeparam name="T">Kiểu dữ liệu truyền vào</typeparam>
        /// <param name="searchText">Chuỗi gồm : Họ tên || Mã đối tượng || Số điện thoại</param>
        /// <param name="department">Id phòng ban || Null</param>
        /// <param name="position">Id vị trí/chức vu || Null</param>
        /// <returns></returns>
        /// Created by PN Thuận : 2/1/2021
        public ServiceResult SearchOther<T>(string searchText, Guid? department, Guid? position)
        {
            if (searchText.Trim().Length > 50)
            {
                return new ServiceResult()
                {
                    Code = EnumPattern.BadRequest,
                    userMsg = new List<string> { MISA.Common.Properties.Resources.Error_Max_Length },
                    devMsg = new List<string> { MISA.Common.Properties.Resources.Error_Max_Length },
                };
            }
            else 
                return new ServiceResult()
                {
                    Data = _dbConnector.SearchOther<T>(searchText, department, position),
                    userMsg = new List<string>(),
                    Code = EnumPattern.Success
                };
        }
        /// <summary>
        /// Lọc sánh sách các đối tượng theo vị trí/ chức vụ và phòng ban
        /// </summary>
        /// <typeparam name="T">Kiểu dữ liệu truyền vào</typeparam>
        /// <param name="positionName">Tên vị trí/ chức vụ</param>
        /// <param name="departmentName">Tên phòng ban</param>
        /// <returns></returns>
        /// Created by PN Thuận : 2/1/2021
        public ServiceResult SearchOther<T>(string positionName , string departmentName)
        {
            return new ServiceResult()
            {
                Data = _dbConnector.SearchOther<T>(positionName, departmentName),
                userMsg = new List<string>(),
                Code = EnumPattern.Success
            };
        }
        /// <summary>
        /// Lấy thông tin đối tượng theo Id
        /// </summary>
        /// <typeparam name="T">Kiểu dữ liệu truyền vào</typeparam>
        /// <param name="id">Id của đối tượng</param>
        /// <returns></returns>
        /// Created by PN Thuận : 2/1/2021
        public ServiceResult GetEntityById<T>(string id)
        {
            return new ServiceResult()
            {
                Data = _dbConnector.GetById<T>(id),
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
        public ServiceResult InsertEntity<T>(T entity)
        {
            // validate data 
            ValidateObject<T>(entity);
            if (_serviceResult.Code == EnumPattern.BadRequest)
            {
                return _serviceResult;
            }
            return new ServiceResult() {
                Data = _dbConnector.Insert<T>(entity),
                userMsg = new List<string> { MISA.Common.Properties.Resources.Msg_Success },
                Code = EnumPattern.Success
            };
        }
        /// <summary>
        /// Xóa đói tượng ra khỏi danh sách
        /// </summary>
        /// <typeparam name="T">Kiểu dữ liệu cần truyền vào</typeparam>
        /// <param name="id">Id của đối tượng cần xóa</param>
        /// <returns></returns>
        /// Created by PN Thuận : 2/1/2021
        public ServiceResult DeleteEntityById<T>(string id)
        {
            return new ServiceResult()
            {
                Data = _dbConnector.DeleteById<T>(id),
                userMsg = new List<string>(),
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
        public ServiceResult ModifiedEntity<T>(T entity, string Id)
        {
            var properties = typeof(T).GetProperties();
            
            Employee entityCheck = _dbConnector.GetById<Employee>(Id);
            // check trùng mã
            foreach(var property in properties)
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
        private void ValidateObject<T>(T entity)
        {
            var properties = typeof(T).GetProperties();
            foreach(var property in properties)
            {
                var proValue = property.GetValue(entity);
                var proName = property.Name;
                // attribute là required thì phải nhập
                if((property.IsDefined(typeof(Required),true)) && (proValue == null || proValue.ToString() == String.Empty))
                {
                    var requiredAttribute = property.GetCustomAttributes(typeof(Required), true).FirstOrDefault();
                    if (requiredAttribute != null)
                    {
                        var propertyText = (requiredAttribute as Required).PropertyName;
                        var errorMessenger = (requiredAttribute as Required).ErrorMessenger;
                        _serviceResult.userMsg.Add(errorMessenger == null ? $"{propertyText} không được phép để trống" : errorMessenger);
                    }else
                    {
                        _serviceResult.userMsg.Add(MISA.Common.Properties.Resources.Error_Required);
                        _serviceResult.devMsg.Add(MISA.Common.Properties.Resources.Error_Required);
                    }
                    _serviceResult.Code = EnumPattern.BadRequest;
                    
                }
                // check duplicate
                if((property.IsDefined(typeof(CheckDuplicate),true)) )
                {
                    var requiredAttribute = property.GetCustomAttributes(typeof(CheckDuplicate), true).FirstOrDefault();
                    if (requiredAttribute != null)
                    {
                        var propertyText = (requiredAttribute as CheckDuplicate).PropertyName;
                        var errorMessenger = (requiredAttribute as CheckDuplicate).ErrorMessenger;
                        var sql = $"SELECT {proName} From {typeof(T).Name} Where {proName} = '{proValue}'";
                        var res = _dbConnector.GetAllData<T>(sql).FirstOrDefault();
                        if(res != null)
                        {
                            _serviceResult.userMsg.Add(errorMessenger == null ? $"{propertyText} không được phép trùng" : errorMessenger);
                            _serviceResult.devMsg.Add(errorMessenger == null ? $"{propertyText} không được phép trùng" : errorMessenger);
                            _serviceResult.Code = EnumPattern.BadRequest;
                        }
                    }
                    
                    
                    
                }
                if((property.IsDefined(typeof(MaxLength),true)) )
                {
                    var requiredAttribute = property.GetCustomAttributes(typeof(MaxLength), true).FirstOrDefault();
                    if (requiredAttribute != null)
                    {
                        var propertyText = (requiredAttribute as MaxLength).PropertyName;
                        var errorMessenger = (requiredAttribute as MaxLength).ErrorMessenger;                     
                        var maxLength = (requiredAttribute as MaxLength).Length; 
                        if(proValue.ToString().Trim().Length > maxLength)
                        {
                            _serviceResult.userMsg.Add(errorMessenger == null ? $"{propertyText} không được phép vượt quá {maxLength} ký tự" : errorMessenger);
                            _serviceResult.devMsg.Add(errorMessenger == null ? $"{propertyText} không được phép vượt quá {maxLength} ký tự" : errorMessenger);
                            _serviceResult.Code = EnumPattern.BadRequest;
                        }
                    }
                    
                    
                    
                }
            }
        }
        #endregion
    }
}
