using MISA.Common;
using MISA.Common.Model;
using MISA.DL;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Service
{
    public class CustomerService:BaseService<Customer>
    {
        /// <summary>
        /// Lấy danh sách khách hàng
        /// </summary>
        /// <returns></returns>
        //public ActionServiceResult GetCustomers()
        //{
        //    var actionServiceResult = new ActionServiceResult();
        //    var dbContext = new CustomerRepository();
        //    actionServiceResult.data = dbContext.GetData("Proc_GetCustomer",commandType:System.Data.CommandType.StoredProcedure);
        //    return actionServiceResult;

        //}
        public ActionServiceResult GetCustomerByCodeAndPhone()
        {
            var actionServiceResult = new ActionServiceResult();
            var dbContext = new CustomerRepository();
            actionServiceResult.data = dbContext.GetData("SELECT * FROM Customer WHERE CustomerCode LIKE CONCAT('%',@CustomerCode,'%')", new { CustomerCode = "3700" }, commandType: System.Data.CommandType.Text);
            //actionServiceResult.data = dbContext.GetData<Customer>("Proc_GetCustomerByCodeAndPhone", commandType: System.Data.CommandType.StoredProcedure);

            return actionServiceResult;
        }



        /// <summary>
        /// Thêm Khách hàng
        /// </summary>
        /// <param name="customer">object khách hàng</param>
        /// <returns></returns>
        /// CREATEDBY: CUONGDV(07/02/2021)
        public ActionServiceResult InsertCustomer(Customer customer)
        {
            var erroMsg = new ErrorMsg();
            var dbContext = new CustomerRepository();
            var actionServiceResult = new ActionServiceResult();
            //Validate dữ liệu (xử lý về nghiệp vụ):
            //1. Validate bắt buộc nhập:
            if (customer.CustomerCode == null || customer.CustomerCode == string.Empty)
            {
                erroMsg.UserMsg = MISA.Common.Properties.Resources.Error_Required_CustomerCode;
                actionServiceResult.data = erroMsg;
                actionServiceResult.Success = false;
                actionServiceResult.MISACode = Enumarations.MISACode.Validate;
                return actionServiceResult;
            }

            if (customer.CustomerName == null || customer.CustomerName == string.Empty)
            {
                erroMsg.UserMsg = MISA.Common.Properties.Resources.Error_Required_CustomerName;
                actionServiceResult.data = erroMsg;
                actionServiceResult.Success = false;
                actionServiceResult.MISACode = Enumarations.MISACode.Validate;
                return actionServiceResult;
            }

            // -Số điện thoại không được bỏ trống!
            if (customer.PhoneNumber == null || customer.PhoneNumber == string.Empty)
            {
                erroMsg.UserMsg = MISA.Common.Properties.Resources.Error_Required_PhoneNumber;
                actionServiceResult.data = erroMsg;
                actionServiceResult.Success = false;
                actionServiceResult.MISACode = Enumarations.MISACode.Validate;
                return actionServiceResult;
            }
            //2. Validate trùng dữ liệu: 
            // -Kiểm tra tồn tại mã khách hàng?
            var isDuplicate = dbContext.CheckCustomerCodeDuplicate(customer.CustomerCode);
            if(isDuplicate == true)
            {
                erroMsg.UserMsg = MISA.Common.Properties.Resources.Error_Duplicates_CustomerCode;
                actionServiceResult.data = erroMsg;
                actionServiceResult.Success = false;
                actionServiceResult.MISACode = Enumarations.MISACode.Validate;
                return actionServiceResult;
            }

            //-Kiểm tra tồn tại số điện thoại
            var phoneNumberDuplicate = dbContext.CheckPhoneNumberDuplicate(customer.PhoneNumber);
            if (phoneNumberDuplicate == true)
            {
                erroMsg.UserMsg = MISA.Common.Properties.Resources.Error_Duplicates_PhoneNumber;
                actionServiceResult.data = erroMsg;
                actionServiceResult.Success = false;
                actionServiceResult.MISACode = Enumarations.MISACode.Validate;
                return actionServiceResult;
            }
            //Validate thành công!
            var res = dbContext.InsertObject(customer);
            if(res > 0)
            {
                actionServiceResult.Message = MISA.Common.Properties.Resources.Success;
                actionServiceResult.Success = true;
                actionServiceResult.MISACode = Enumarations.MISACode.Success;
                actionServiceResult.data = res;
                return actionServiceResult;
            }
            else
            {
                actionServiceResult.Success = true;
                actionServiceResult.MISACode = Enumarations.MISACode.Success;
                actionServiceResult.data = res;
                return actionServiceResult;
            }

        }
    }
}
