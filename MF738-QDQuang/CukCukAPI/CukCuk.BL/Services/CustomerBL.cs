using CukCuk.BL.Interfaces;
using CukCuk.Common;
using CukCuk.Common.Models;
using CukCuk.DataLayer;
using CukCuk.DataLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CukCuk.BL
{
    public class CustomerBL:BaseBL<Customer>, ICustomerBL
    {
        #region CONSTRUCTOR
        public CustomerBL(IDbConnector<Customer> _customerDL) : base(_customerDL)
        {

        }
        #endregion

        #region METHODS
        ///// <summary>
        ///// Xóa khách hàng
        ///// </summary>
        ///// <param name="customerCode">string</param>
        ///// <returns>ServiceResult (Object thông tin kết quả)</returns>
        ///// CreatedBy: QDQuang (07/02/2021)
        public override ServiceResult Delete(string customerCode)
        {
            // Gọi đến tầng DataLayer
            var customerDL = new CustomerDL();
            // Xóa dữ liệu khách hàng
            var affectedRows = customerDL.Delete(customerCode);
            // Kiểm tra kết quả trả về
            if (affectedRows > 0)
                _serviceResult.Success = true;
            else
                _serviceResult.Success = false;

            return _serviceResult;
        }

        /// <summary>
        /// Kiểm tra dữ liệu khi thêm mới
        /// </summary>
        /// <param name="customer">Object</param>
        /// <param name="errMsg">Thông báo lỗi</param>
        /// <returns>bool (true - valid, false - invalid)</returns>
        /// CreatedBy: QDQuang (08/02/2021)
        protected override bool ValidateInsertData(Customer customer, ErrMsg errMsg)
        {
            // Gọi đến tầng DataLayer
            var customerDL = new CustomerDL();
            var isValid = true;
            // Validate dữ liệu
            // 1. Validate bắt buộc nhập
            // 1.1 Bắt buộc nhập mã khách hàng
            if (customer.CustomerCode == null || customer.CustomerCode == string.Empty)
            {
                // Trả về lỗi cùng thông báo cho khách hàng và dev
                errMsg.UserMsg.Add(CukCuk.Common.Properties.Resources.ErrServce_NullCustomerCode);
                isValid = false;
            }
            // 1.2 Bắt buộc nhập họ tên
            if (customer.FullName == null || customer.FullName == string.Empty)
            {
                // Trả về lỗi cùng thông báo cho khách hàng và dev
                errMsg.UserMsg.Add(CukCuk.Common.Properties.Resources.ErrService_NullFullName);
                isValid = false;
            }
            // 1.3 Bắt buộc nhập số điện thoại
            if (customer.PhoneNumber == null || customer.PhoneNumber == string.Empty)
            {
                // Trả về lỗi cùng thông báo cho khách hàng và dev
                errMsg.UserMsg.Add(CukCuk.Common.Properties.Resources.ErrService_NullPhoneNumber);
                isValid = false;
            }
            // 2. Kiểm tra trùng
            // 2.1 Trùng số điện thoại
            if (customerDL.CheckDuplicatedPhoneNumber(customer.PhoneNumber))
            {
                // Trả về lỗi cùng thông báo cho khách hàng và dev
                errMsg.UserMsg.Add(CukCuk.Common.Properties.Resources.ErrService_DuplicatedPhoneNumber);
                isValid = false;
            }
            //2.1 Trùng mã khách hàng
            if (customerDL.CheckDuplicatedCode(customer.CustomerCode))
            {
                // Trả về lỗi cùng thông báo cho khách hàng và dev
                errMsg.UserMsg.Add(CukCuk.Common.Properties.Resources.ErrService_DuplicatedCustomerCode);
                isValid = false;
            }

            return isValid;
        }

        /// <summary>
        /// Kiểm tra dữ liệu khi cập nhật
        /// </summary>
        /// <param name="customer">Object</param>
        /// <param name="errMsg">Thông báo lỗi</param>
        /// <returns>bool (true - valid, false - invalid)</returns>
        /// CreatedBy: QDQuang (08/02/2021)
        protected override bool ValidateUpdateData(Customer customer, ErrMsg errMsg)
        {
            // Gọi đến tầng DataLayer
            var customerDL = new CustomerDL();
            var isValid = true;
            // Validate dữ liệu
            // 1. Validate bắt buộc nhập
            // 1.1 Bắt buộc nhập mã khách hàng
            if (customer.CustomerCode == null || customer.CustomerCode == string.Empty)
            {
                // Trả về lỗi cùng thông báo cho khách hàng và dev
                errMsg.UserMsg.Add(CukCuk.Common.Properties.Resources.ErrServce_NullCustomerCode);
                isValid = false;
            }
            // 1.2 Bắt buộc nhập họ tên
            if (customer.FullName == null || customer.FullName == string.Empty)
            {
                // Trả về lỗi cùng thông báo cho khách hàng và dev
                errMsg.UserMsg.Add(CukCuk.Common.Properties.Resources.ErrService_NullFullName);
                isValid = false;
            }
            // 1.3 Bắt buộc nhập số điện thoại
            if (customer.PhoneNumber == null || customer.PhoneNumber == string.Empty)
            {
                // Trả về lỗi cùng thông báo cho khách hàng và dev
                errMsg.UserMsg.Add(CukCuk.Common.Properties.Resources.ErrService_NullPhoneNumber);
                isValid = false;
            }
            // 2. Kiểm tra trùng
            // 2.1 Trùng số điện thoại (mã khách hàng phải khác với mã của khách hàng đang cần cập nhật)
            if (customerDL.CheckDuplicatedPhoneNumber(customer.PhoneNumber, customer.CustomerCode))
            {
                // Trả về lỗi cùng thông báo cho khách hàng và dev
                errMsg.UserMsg.Add(CukCuk.Common.Properties.Resources.ErrService_DuplicatedPhoneNumber);
                isValid = false;
            }

            return isValid;
        }
        #endregion
    }
}
