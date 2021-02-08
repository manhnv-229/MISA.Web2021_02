using FresherProject.Common;
using FresherProject.Common.AttributeBL;
using FresherProject.Common.Enum;
using FresherProject.Common.Result;
using FresherProject.DataLayer.Interfaces;
using FresherProject.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FresherProject.Service
{
    public class EmployeeService : BaseService<Employee>, IEmployeeService
    {
        public EmployeeService(IEmployeeRepository _employeeRepository) :base(_employeeRepository)
        {

        }
        protected override void ValidateObject(Employee employee)
        {
            var properties = typeof(Employee).GetProperties();
            foreach (var property in properties)
            {
                var propValue = property.GetValue(employee);
                var propName = property.Name;
                // Kiểm tra nếu có attribute là [Required] thì thực hiện kiểm tra bắt buộc nhập
                if (property.IsDefined(typeof(Required), true) && (propValue == null || propValue.ToString() == string.Empty))
                {
                    var requiredAttribute = property.GetCustomAttributes(typeof(Required), true).FirstOrDefault();
                    if (requiredAttribute != null)
                    {
                        var propertyText = (requiredAttribute as Required).PropertyName;
                        var errorMsg = (requiredAttribute as Required).ErrorMessenger;
                        _serviceResult.Messenger.Add((errorMsg == null ? $"{propertyText} không được phép để trống" : errorMsg));
                        _serviceResult.MISACukCukCode = MISACukCukServiceCode.BadRequest;
                    }

                }
                //Kiểm tra nếu có attribute là [Duplicate] thì thực hiện kiểm tra
                if (property.IsDefined(typeof(CheckDuplicate), true))
                {
                    var requiredAttribute = property.GetCustomAttributes(typeof(CheckDuplicate), true).FirstOrDefault();
                    if (requiredAttribute != null)
                    {
                        var propertyText = (requiredAttribute as CheckDuplicate).PropertyName;
                        var errorMsg = (requiredAttribute as CheckDuplicate).ErrorMessenger;
                        var sql = $"SELECT {propName} FROM {typeof(Employee).Name} WHERE {propName} = '{propValue}'";
                        var entity = _dBConnector.GetAllData(sql).FirstOrDefault();
                        if (entity != null)
                        {
                            _serviceResult.Messenger.Add((errorMsg == null ? $"{propertyText} đã bị trùng" : errorMsg));
                            _serviceResult.MISACukCukCode = MISACukCukServiceCode.BadRequest;
                        }
                    }

                }
                //Kiểm tra nếu có attribute là [MaxLength] thì thực hiện kiểm tra độ dài
                if (property.IsDefined(typeof(MaxLength), true))
                {
                    var requiredAttribute = property.GetCustomAttributes(typeof(MaxLength), true).FirstOrDefault();
                    if (requiredAttribute != null)
                    {
                        var propertyText = (requiredAttribute as MaxLength).PropertyName;
                        var errorMsg = (requiredAttribute as MaxLength).ErrorMessenger;
                        var length = (requiredAttribute as MaxLength).Length;
                        if (propValue.ToString().Trim().Length > length)
                        {
                            _serviceResult.Messenger.Add((errorMsg == null ? $"{propertyText} không được dài quá {length} kí tự" : errorMsg));
                            _serviceResult.MISACukCukCode = MISACukCukServiceCode.BadRequest;
                        }
                    }

                }
            }
        }
    }
}
