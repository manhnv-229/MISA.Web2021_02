using MISA.Common.Model;
using System;
using System.Collections.Generic;
using System.Text;
using MISA.DataLayer;

namespace MISA.Service
{
    public class CustomerService
    {
        public ServiceResult GetCustomers()
        {
            var serviceResult = new ServiceResult();
            var dbContext = new CustomerRepository();
            //serviceResult.Data = dbContext.GetAll<Customer>();
            //serviceResult.Data = dbContext.GetAll<Customer>("SELECT * FROM Customer LIMIT 1");
            serviceResult.Data = dbContext.GetData();
            //serviceResult.Data = dbContext.GetData<Customer>("Proc_GetCustomers",commandType: System.Data.CommandType.StoredProcedure);
            //serviceResult.Data = dbContext.GetData<Customer>("SELECT * FROM Customer WHERE CustomerCode LIKE CONCAT('%',@CustomerCode,'%')", new { CustomerCode = "KH88617", PhoneNumber = "09"});
            return serviceResult;
        }

        public ServiceResult GetCustomersTop100()
        {
            var serviceResult = new ServiceResult();
            var dbContext = new CustomerRepository();
            serviceResult.Data = dbContext.GetCustomerTop100();
            return serviceResult;
        }

        /// <summary>
        /// Thêm mới 
        /// </summary>
        /// <param name="customer">object khách hàng</param>
        /// <returns></returns>
        /// CreatedBy: Đào Đức Thao (03/02/2021)
        public ServiceResult InsertCustomer(Customer customer)
        {
            var serviceResult = new ServiceResult();
            var erroMsg = new ErroMsg();
            var dbContext = new CustomerRepository();
            //Validate dữ liệu (xử lý về nghiệp vụ): 
            //1. validate bắt buộc nhập:
            if (customer.CustomerCode == null || customer.CustomerCode == string.Empty)
            {
                erroMsg.UserMsg = MISA.Common.Properties.Resources.ErroService_EmptyCustomerCode;
                serviceResult.Success = false;
                serviceResult.Data = erroMsg;
                return serviceResult;
            }



            //2. validate dữ liệu không được phép trùng: trùng mã khách hàng, trùng số điện thoại  
            // - Kiểm tra trong database đã tồn tại mã khách hàng này hay chưa
        
            var isExits = dbContext.CheckCustomerCodeExits(customer.CustomerCode);

            if (isExits == true)
            {
                erroMsg.UserMsg = MISA.Common.Properties.Resources.ErroService_DuplicateCustomerCode;
                serviceResult.Success = false;
                serviceResult.Data = erroMsg;
                return serviceResult;
            }


            // - Kiểm tra trong database đã tồn tại số điện thoại này hay chưa
            isExits = dbContext.CheckCustomerPhoneNumberExits(customer.PhoneNumber);
            if (isExits == true)
            {
                erroMsg.UserMsg = MISA.Common.Properties.Resources.ErroService_DuplicateCustomerPhoneNumber;
                serviceResult.Success = false;
                serviceResult.Data = erroMsg;
                return serviceResult;
            }

            // Validate dữ liệu Ok thì thực hiện thêm mới:
            var res = dbContext.InsertObject(customer);
            if (res > 0)
            {
                serviceResult.Success = true;
                serviceResult.Data = res;
                return serviceResult;
            }
            else
            {
                serviceResult.Success = true;
                serviceResult.Data = res;
                return serviceResult;
            }
        }
    }
}
