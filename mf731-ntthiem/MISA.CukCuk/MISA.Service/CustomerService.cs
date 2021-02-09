using System;
using System.Collections.Generic;
using System.Text;
using MISA.Common.Models;
using MISA.DataLayer;
using MISA.Service.Interfaces;

namespace MISA.Service
{
    public class CustomerService : BaseService<Customer>,ICustomerService
    {
        /// <summary>
        /// Láy 10 khách hàng đầu tiên
        /// </summary>
        /// <returns></returns>
        /// CreatedBy: NTTHIEM
        /// CreatedDate: 08/02/2021
        public ServiceResult GetCustomerTop10()
        {
            var serviceResult = new ServiceResult();
            var dbContext = new CustomerRepository();
            serviceResult.Data = dbContext.GetCustomerTop10();
            return serviceResult;
        }

        /// <summary>
        /// Xử lý validate dữ liệu
        /// </summary>
        /// <param name="customer">Khách hàng truyền vào để validate </param>
        /// <param name="errorMsg">Thông báo lỗi trả về</param>
        /// <returns>true/false</returns>
        protected override  bool ValidateData(Customer customer,ErrorMsg errorMsg = null)
        {
            var dbContext = new CustomerRepository();
            var isValidate = true;
            // Validate dữ liệu (xử lý nghiệp vụ):
            // 1. validate bắt buộc nhập:
            if (customer.CustomerCode == null || customer.CustomerCode == "")
            {
                if(errorMsg != null)
                    errorMsg.UserMsg.Add(MISA.Common.Properties.Resources.ErrorService_EmptyCustomerCode);
                isValidate = false;
            }

            // 2. validate dữ liệu không được phép trùng
            // - Kiểm tra mã khách hàng đã tồn tại trong data base chưa
            var isExist = dbContext.CheckCustomerCodeExist(customer.CustomerCode);
            if (isExist == true)
            {
                if(errorMsg != null)
                    errorMsg.UserMsg.Add(MISA.Common.Properties.Resources.ErrorService_DuplicateCustomerCode);
                isValidate = false;
                
            }
            // - Kiểm tra số điện thoại đã tồn tại trong data base chưa
            isExist = dbContext.CheckPhoneNumberExist(customer.PhoneNumber);
            if (isExist == true)
            {
                if(errorMsg != null)
                    errorMsg.UserMsg.Add(MISA.Common.Properties.Resources.ErrorService_DuplicateCustomerPhoneNumber);
                isValidate = false;
            }

            return isValidate;
            // 3. validate dữ liệu đúng định dạng không? (Email cần đúng định dạng...). (hiện chưa có gì)
        }
    }
}
