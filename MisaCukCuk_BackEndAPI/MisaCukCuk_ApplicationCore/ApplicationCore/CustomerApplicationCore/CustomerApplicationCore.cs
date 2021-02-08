using MisaCukCuk_ApplicationCore.BaseApplicationCore;
using MisaCukCuk_Entity.Common;
using MisaCukCuk_Entity.Models;
using MisaCukCuk_Infarstructure;
using MisaCukCuk_Infarstructure.Infarstructure.CustomerInfarstructure;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MisaCukCuk_ApplicationCore.ApplicationCore.CustomerApplicationCore
{
    public class CustomerApplicationCore : BaseApplicationCore<Customer>, ICustomerApplicationCore
    {
        ICustomerInfarstructure _customerInfarstructure;
        public CustomerApplicationCore(ICustomerInfarstructure customerInfarstructure) : base(customerInfarstructure)
        {
            _customerInfarstructure = customerInfarstructure;
        }
        /// <summary>
        /// Validate thêm mới dữ liệu
        /// CreateBy: MinhHq(08/02/2021)
        /// </summary>
        /// <param name="customer"></param>
        /// <param name="errorMsg"></param>
        /// <returns>true : đúng; false: trùng số điện thoại || trùng mã khách hàng || mã khách hàng để trống</returns>
        protected override async Task<bool> ValidateDataInsert(Customer customer, ErrorMsg errorMsg = null)
        {
            var service = new ServiceResult();
            //var _db = new MisaCukCukContext<Customer>();
            var isValid = true;

            #region kiểm tra mã khách hàng có để trống hay không?
            if (customer.CustomerCode == null || customer.CustomerCode == string.Empty)
            {
                errorMsg.UserMsg.Add(MisaCukCuk_Entity.Properties.Resources.ErroService_EmptyCustomerCode);
                service.Success = false;
                service.Data = errorMsg;
                isValid = false;
            }
            #endregion

            #region kiểm tra trùng mã khách hàng
            var isExitByCode = await _customerInfarstructure.CheckCodeExit(customer.CustomerCode);
            if (isExitByCode == false)
            {
                errorMsg.UserMsg.Add(MisaCukCuk_Entity.Properties.Resources.ErroService_DuplicateCustomerCode);
                service.Success = false;
                service.Data = errorMsg;
                isValid = false;
            }
            #endregion

            #region kiểm tra trùng số điện thoại
            var isExitPhoneNumber = await _customerInfarstructure.CheckPhoneNumberExit(customer.PhoneNumber);
            if (isExitPhoneNumber == false)
            {
                errorMsg.UserMsg.Add(MisaCukCuk_Entity.Properties.Resources.ErroService_DuplicatePhoneNumber);
                service.Success = false;
                service.Data = errorMsg;
                isValid = false;
            }
            #endregion

            return isValid;
        }
        /// <summary>
        /// Validate sửa dữ liệu
        /// CreateBy: MinhHq(08/02/2021)
        /// </summary>
        /// <param name="customer"></param>
        /// <param name="errorMsg"></param>
        /// <returns>true: thực hiện tiếp; false: mã khách hàng để trống</returns>
        protected override async Task<bool> ValidateDataUpdate(Customer customer, ErrorMsg errorMsg = null)
        {
            var service = new ServiceResult();
            //var _db = new MisaCukCukContext<Customer>();
            var isValid = true;

            #region kiểm tra mã khách hàng có để trống hay không?
            if (customer.CustomerCode == null || customer.CustomerCode == string.Empty)
            {
                errorMsg.UserMsg.Add(MisaCukCuk_Entity.Properties.Resources.ErroService_EmptyCustomerCode);
                service.Success = false;
                service.Data = errorMsg;
                isValid = false;
            }
            #endregion

            #region kiểm tra trùng mã khách hàng
            var isExitByCode = await _customerInfarstructure.CheckCodeExit(customer.CustomerCode);
            if (isExitByCode == false)
            {
                errorMsg.UserMsg.Add(MisaCukCuk_Entity.Properties.Resources.ErroService_DuplicateCustomerCode);
                service.Success = false;
                service.Data = errorMsg;
                isValid = false;
            }
            #endregion

            #region kiểm tra trùng số điện thoại
            var isExitPhoneNumber = await _customerInfarstructure.CheckPhoneNumberExit(customer.PhoneNumber);
            if (isExitPhoneNumber == false)
            {
                errorMsg.UserMsg.Add(MisaCukCuk_Entity.Properties.Resources.ErroService_DuplicatePhoneNumber);
                service.Success = false;
                service.Data = errorMsg;
                isValid = false;
            }
            #endregion

            return isValid;
        }
    }
}
