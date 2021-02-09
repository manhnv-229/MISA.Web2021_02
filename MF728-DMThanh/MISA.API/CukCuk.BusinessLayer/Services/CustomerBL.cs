using CukCuk.BusinessLayer.Interfaces;
using CukCuk.Common;
using CukCuk.Common.Models;
using CukCuk.DataLayer;
using CukCuk.DataLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CukCuk.BusinessLayer
{
    public class CustomerBL:BaseBL<Customer>, ICustomerBL
    {
        #region Constructor
        public CustomerBL(IDbConnector<Customer> _customerDL) : base(_customerDL)
        {

        }
        #endregion

        #region Method
        /// <summary>
        /// Xoá khách hàng
        /// </summary>
        /// <param name="customerCode"></param>
        /// <returns></returns>
        /// CreatedBy: DMThanh (06/02/2021)
        public override ServiceResult Delete(string customerCode)
        {
            
            var customerDL = new CustomerDL();            
            var affectedRows = customerDL.Delete(customerCode);            
            if (affectedRows > 0)
                _serviceResult.Success = true;
            else
                _serviceResult.Success = false;

            return _serviceResult;
        }

        /// <summary>
        /// Check dữ liệu khi thêm mới
        /// </summary>
        /// <param name="customer">Object</param>
        /// <param name="errorMsg">Thông báo lỗi</param>
        /// <returns></returns>
        /// CreatedBy: DMThanh (06/02/2021)
        protected override bool ValidateInsertData(Customer customer, ErrorMsg errorMsg)
        {
            
            var customerDL = new CustomerDL();
            var isValid = true;
            // Validate dữ liệu
                // 1. Validate bắt buộc nhập
                // 1.1 Bắt buộc nhập mã khách hàng
            if (customer.CustomerCode == null || customer.CustomerCode == string.Empty)
            {                
                errorMsg.UserMsg.Add(CukCuk.Common.Properties.Resources.EmptyCustomerCode);
                isValid = false;
            }
            
            if (customer.FullName == null || customer.FullName == string.Empty)
            {               
                errorMsg.UserMsg.Add(CukCuk.Common.Properties.Resources.EmptyFullName);
                isValid = false;
            }
            // 1.2 Bắt buộc nhập số điện thoại
            if (customer.PhoneNumber == null || customer.PhoneNumber == string.Empty)
            {
                
                errorMsg.UserMsg.Add(CukCuk.Common.Properties.Resources.EmptyPhoneNumber);
                isValid = false;
            }
            // 2. Check trùng
            // 2.1 Check trùng số điện thoại
            if (customerDL.CheckDuplicatedPhoneNumber(customer.PhoneNumber))
            {
                
                errorMsg.UserMsg.Add(CukCuk.Common.Properties.Resources.DuplicatedPhoneNumber);
                isValid = false;
            }
            //2.1 Check trùng mã khách hàng
            if (customerDL.CheckDuplicatedCode(customer.CustomerCode))
            {
                
                errorMsg.UserMsg.Add(CukCuk.Common.Properties.Resources.DuplicatedCustomerCode);
                isValid = false;
            }

            return isValid;
        }
        /// <summary>
        /// Kiểm tra dữ liệu khi sửa
        /// </summary>
        /// <param name="customer">Object</param>
        /// <param name="errorMsg">Thông báo lỗi</param>
        /// <returns></returns>
        /// CreatedBy: DMThanh (06/02/2021)
        protected override bool ValidateUpdateData(Customer customer, ErrorMsg errorMsg)
        {           
            var customerDL = new CustomerDL();
            var isValid = true;
            // Validate dữ liệu
                // 1. Validate bắt buộc nhập
                 // 1.1 Bắt buộc nhập mã khách hàng
            if (customer.CustomerCode == null || customer.CustomerCode == string.Empty)
            {                
                errorMsg.UserMsg.Add(CukCuk.Common.Properties.Resources.EmptyCustomerCode);
                isValid = false;
            }
                // 1.2 Bắt buộc nhập họ tên
            if (customer.FullName == null || customer.FullName == string.Empty)
            {                
                errorMsg.UserMsg.Add(CukCuk.Common.Properties.Resources.EmptyFullName);
                isValid = false;
            }
                // 1.3 Bắt buộc nhập số điện thoại
            if (customer.PhoneNumber == null || customer.PhoneNumber == string.Empty)
            {                
                errorMsg.UserMsg.Add(CukCuk.Common.Properties.Resources.EmptyPhoneNumber);
                isValid = false;
            }
            // 2. Kiểm tra trùng
                // 2.1 Trùng số điện thoại 
            if (customerDL.CheckDuplicatedPhoneNumber(customer.PhoneNumber, customer.CustomerCode))
            {                
                errorMsg.UserMsg.Add(CukCuk.Common.Properties.Resources.DuplicatedPhoneNumber);
                isValid = false;
            }

            return isValid;
        }
        #endregion
    }
}
