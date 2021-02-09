using System;
using System.Collections.Generic;
using System.Text;
using MISA.Common.Model;
using MISA.DataLayer;
using MISA.Service.Interface;
using MISA.DataLayer.Interface;

namespace MISA.Service
{
    /// <summary>
    /// Xử lý nghiệp vụ trả về serviceResult
    /// </summary>
    /// CreatedBy: NMDAT (04/02/2021)
    public class CustomerService : BaseService<Customer>, ICustomerService
    {
        #region Contructor
        public CustomerService(ICustomerDBConnecttion customerDBConnection): base(customerDBConnection)
        {

        }
        #endregion

        #region Method
        /// <summary>
        /// Override Validate insert từ BaseService
        /// </summary>
        /// <param name="entity">customer</param>
        /// <param name="errorMsg">messenger trả về</param>
        /// <returns>true : dữ liệu hợp lệ - false : dữ liệu không hợp lệ</returns>
        protected override bool Validate(Customer entity,ErrorMsg errorMsg)
        {
            // Khởi tạo biến isValid lưu trạng thái validate
            var isValid = true;

            // Khởi tạo kết nối db
            DbConnectCustomer dbConnectCustomer = new DbConnectCustomer();

            //Validate dữ liệu(xử lý về nghiệp vụ):
            //1. Validate bắt buộc nhập:
            if (entity.CustomerCode == null || entity.CustomerCode == string.Empty)
            {
                errorMsg.UserMsg.Add(MISA.Common.Properties.Resources.ErrorService_EmptyCustomer);
                isValid = false;
            }

            //2. Validate dữ liệu không được phép (trùng): mã khách hàng,  số điện thoại
            // kiểm tra trong database đã tồn tại đã mã kh hay chưa
            var isExits = dbConnectCustomer.CheckCustomerCodeExits(entity.CustomerCode);
            if (isExits)
            {
                errorMsg.UserMsg.Add(MISA.Common.Properties.Resources.ErrorService_DuplicateCustomerCode);
                isValid = false;
            }

            // kiểm tra trong database đã tồn tại đã sđt kh hay chưa
            isExits = dbConnectCustomer.CheckPhoneNumberExits(entity.PhoneNumber);
            if (isExits)
            {
                errorMsg.UserMsg.Add(MISA.Common.Properties.Resources.ErrorService_DuplicateCustomerPhoneNumber);
                isValid = false;
            }
            return isValid;
        }

        /// <summary>
        /// Override Validate update từ BaseService
        /// </summary>
        /// <param name="entity">customer</param>
        /// <param name="errorMsg">messenger trả về</param>
        /// <returns>true : dữ liệu hợp lệ - false : dữ liệu không hợp lệ</returns>
        protected override bool ValidateUpdate(Customer entity, ErrorMsg errorMsg)
        {
            // Khởi tạo biến isValid lưu trạng thái validate
            var isValid = true;

            // Khởi tạo kết nối db
            DbConnectCustomer dbConnectCustomer = new DbConnectCustomer();

            //Validate dữ liệu(xử lý về nghiệp vụ):
            //1. Validate bắt buộc nhập:
            if (entity.CustomerCode == null || entity.CustomerCode == string.Empty)
            {
                errorMsg.UserMsg.Add(MISA.Common.Properties.Resources.ErrorService_EmptyCustomer);
                isValid = false;
            }
            return isValid;
        }
        #endregion

    }
}
