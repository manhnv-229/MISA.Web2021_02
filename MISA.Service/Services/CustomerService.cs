using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MISA.DataLayer;
using MISA.Common.Models;
using MISA.Service;

namespace MISA.Services
{
    public class CustomerService:BaseService<Customer>
    {
        CustomerRepositoty _dBConnector;
        ActionServiceResult _actionServiceResult;
        public CustomerService()
        {
            _dBConnector = new CustomerRepositoty();
            _actionServiceResult = new ActionServiceResult();
        }

        /// <summary>
        /// Thêm mới khách hàng
        /// </summary>
        /// <param name="customer">Thực thể khách hàng</param>
        /// <returns>Response tương ứng cho Client</returns>
        /// CreatedBy: TXTrinh (02/02/2021)
        public ActionServiceResult InsertCustomer(Customer customer)
        {
            var errMsg = new ErroMsg();
            /**
             * Kiểm tra thông tin trước khi thêm mới
             */
            ValidateObj(customer, 0, errMsg);
            var k = errMsg;
            if(_actionServiceResult.MISACode == EnumCodes.BadRequest)
            {
                return _actionServiceResult;
            }

            return new ActionServiceResult()
            {
                Success = true,
                Message = MISA.Common.Properties.Resources.SuccessMsg,
                Data = _dBConnector.Insert(customer),
                MISACode = EnumCodes.Created,
            };
        }

        /// <summary>
        /// Sửa thông tin khách hàng
        /// </summary>
        /// <param name="customer">Thực thể khách hàng đã được sửa</param>
        /// <returns>Response tương ứng cho Client</returns>
        /// CreatedBy: TXTrinh (02/02/2021)
        public ActionServiceResult UpdateCustomer(Customer customer)
        {
            var errMsg = new ErroMsg();
            /**
             * Kiểm tra thông tin trước khi cập nhập
             */
            ValidateObj(customer, 1, errMsg);
            if (_actionServiceResult.MISACode == EnumCodes.BadRequest)
            {
                return _actionServiceResult;
            }

            return new ActionServiceResult()
            {
                Success = true,
                Message = MISA.Common.Properties.Resources.SuccessMsg,
                Data = _dBConnector.Update(customer),
                MISACode = EnumCodes.Success,
            };
        }

        /// <summary>
        /// Validate thông tin
        /// </summary>
        /// <param name="customer">Khách hàng cần kiểm tra</param>
        /// <param name="index">Chỉ mục để phân biệt: 0-Thêm mới; 1-Sửa</param>
        /// CreatedBy: TXTrinh (02/02/2021)
        private void ValidateObj(Customer customer, int index, ErroMsg errorMsg = null)
        {
            var properties = typeof(Customer).GetProperties();
            foreach(var property in properties)
            {
                var propName = property.Name;
                var propValue = property.GetValue(customer);
                // Nếu có attribute là [Required] thì kiểm tra
                if(property.IsDefined(typeof(Required), true) && (propValue == null || propValue.ToString() == string.Empty))
                {
                    var requiredAttribute = property.GetCustomAttributes(typeof(Required), true).FirstOrDefault();
                    if(requiredAttribute != null)
                    {
                        var propertyText = (requiredAttribute as Required).PropertyName;
                        errorMsg.UserMsg.Add($"{propertyText} {MISA.Common.Properties.Resources.ErrorRequired} ");
                        _actionServiceResult.Message += $"{propertyText} {MISA.Common.Properties.Resources.ErrorRequired} ";
                    }    
                    _actionServiceResult.MISACode = EnumCodes.BadRequest;
                }
                // Nếu có attribute là [CheckDuplicate] thì kiểm tra
                if (property.IsDefined(typeof(CheckDuplicate), true) && (index == 0))
                {
                    var requiredAttribute = property.GetCustomAttributes(typeof(CheckDuplicate), true).FirstOrDefault();
                    if (requiredAttribute != null)
                    {
                        var propertyText = (requiredAttribute as CheckDuplicate).PropertyName;
                        var isDuplicate = _dBConnector.checkDuplicate(propName, propValue);
                        if(isDuplicate)
                        {
                            errorMsg.UserMsg.Add($"{propertyText} {MISA.Common.Properties.Resources.ErrorExisted} ");
                            _actionServiceResult.Message += $"{propertyText} {MISA.Common.Properties.Resources.ErrorExisted} ";
                            _actionServiceResult.MISACode = EnumCodes.BadRequest;
                        }
                    }
                }
                // Nếu có attribute là [MaxLength] thì kiểm tra
                if (property.IsDefined(typeof(MaxLength), true))
                {
                    var requiredAttribute = property.GetCustomAttributes(typeof(MaxLength), true).FirstOrDefault();
                    if (requiredAttribute != null)
                    {
                        var propertyText = (requiredAttribute as MaxLength).PropertyName;
                        var length = (requiredAttribute as MaxLength).Length;
                        if (propValue.ToString().Trim().Length > length)
                        {
                            _actionServiceResult.Message += $"{propertyText} {MISA.Common.Properties.Resources.ErrorLength} ";
                            _actionServiceResult.MISACode = EnumCodes.BadRequest;
                        }
                    }
                }
            }
        }
    }
}
