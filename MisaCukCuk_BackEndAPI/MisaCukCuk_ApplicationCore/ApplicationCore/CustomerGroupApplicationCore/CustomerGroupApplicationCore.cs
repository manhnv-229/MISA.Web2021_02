using MisaCukCuk_ApplicationCore.BaseApplicationCore;
using MisaCukCuk_Entity.Common;
using MisaCukCuk_Entity.Models;
using MisaCukCuk_Infarstructure;
using MisaCukCuk_Infarstructure.Infarstructure.CustomerGroupInfarstructure;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MisaCukCuk_ApplicationCore.ApplicationCore.CustomerGroupApplicationCore
{
    public class CustomerGroupApplicationCore : BaseApplicationCore<CustomerGroup>,ICustomerGroupApplicationCore
    {
        ICustomerGroupInfarstructure _customerGroupInfarstructure;
        public CustomerGroupApplicationCore(ICustomerGroupInfarstructure customerGroupInfarstructure) : base(customerGroupInfarstructure)
        {
            _customerGroupInfarstructure = customerGroupInfarstructure;
        }
        /// <summary>
        /// Validate thêm mới dữ liệu
        /// CreateBy: MinhHq(08/02/2021)
        /// </summary>
        /// <param name="CustomerGroup"></param>
        /// <param name="errorMsg"></param>
        /// <returns>true : đúng; false: trùng số điện thoại || trùng mã khách hàng || mã khách hàng để trống</returns>
        protected override async Task<bool> ValidateDataInsert(CustomerGroup customerGroup, ErrorMsg errorMsg = null)
        {
            var service = new ServiceResult();
            //var _db = new MisaCukCukContext<CustomerGroup>();
            var isValid = true;

            #region kiểm tra mã khách hàng có trống hay ko?
            if (customerGroup.CustomerGroupName == null || customerGroup.CustomerGroupName == string.Empty)
            {
                errorMsg.UserMsg.Add(MisaCukCuk_Entity.Properties.Resources.ErroService_EmptyCustomerGroupName);
                service.Success = false;
                service.Data = errorMsg;
                isValid = false;
            }
            #endregion

            #region kiểm tra trùng mã khách hàng
            var isExitByCode = await _customerGroupInfarstructure.CheckNameExit(customerGroup.CustomerGroupName);
            if (isExitByCode == false)
            {
                errorMsg.UserMsg.Add(MisaCukCuk_Entity.Properties.Resources.ErroService_DuplicateCustomerGroupName);
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
        /// <param name="customerGroup"></param>
        /// <param name="errorMsg"></param>
        /// <returns>true : đúng; false: trùng số điện thoại || trùng mã khách hàng || mã khách hàng để trống</returns>
        protected override async Task<bool> ValidateDataUpdate(CustomerGroup customerGroup, ErrorMsg errorMsg = null)
        {
            var service = new ServiceResult();
            //var _db = new MisaCukCukContext<CustomerGroup>();
            var isValid = true;

            #region kiểm tra mã khách hàng có trống hay không?
            if (customerGroup.CustomerGroupName == null || customerGroup.CustomerGroupName == string.Empty)
            {
                errorMsg.UserMsg.Add(MisaCukCuk_Entity.Properties.Resources.ErroService_EmptyCustomerGroupName);
                service.Success = false;
                service.Data = errorMsg;
                isValid = false;
            }
            #endregion

            #region kiểm tra trùng mã khách hàng
            var isExitByCode = await _customerGroupInfarstructure.CheckNameExit(customerGroup.CustomerGroupName);
            if (isExitByCode == false)
            {
                errorMsg.UserMsg.Add(MisaCukCuk_Entity.Properties.Resources.ErroService_DuplicateCustomerGroupName);
                service.Success = false;
                service.Data = errorMsg;
                isValid = false;
            }
            #endregion

            return isValid;
        }
    }
}
