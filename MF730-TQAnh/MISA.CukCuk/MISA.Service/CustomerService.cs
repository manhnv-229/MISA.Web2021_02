using MISA.Common.Model;
using MISA.Common;
using MISA.DataLayer;
using System;
using System.Collections.Generic;
using System.Text;
using MISA.Service.Interfaces;
using MISA.DataLayer.Interfaces;

namespace MISA.Service
{
    /// <summary>
    /// service cho khách hàng
    /// </summary>
    /// CreatedBy: TQAnh (08/02/2021)
    public class CustomerService : BaseService<Customer>, ICustomerService
    {
        public CustomerService(ICustomerRepository customerRepository) : base(customerRepository)
        {
         
        }
        protected override bool ValidateData(Customer customer ,ErroMsg erroMsg)
        {
            var isValid = true;
            // 1. Trường bắt buộc nhập

            // check mã khách hàng có trống hay không 
            if (customer.CustomerCode == null || customer.CustomerCode == string.Empty)
            {
                if(erroMsg!=null)
                erroMsg.UserMsg.Add(MISA.Common.Properties.Resources.UserMsg_EmptyCustomerCode);
          
                isValid=false;
            }

            // check số điện thoại có trống hay không 
            if (customer.PhoneNumber == null || customer.PhoneNumber == string.Empty)
            {
                if (erroMsg != null)
                    erroMsg.UserMsg.Add(MISA.Common.Properties.Resources.UserMsg_EmptyPhoneNumber);
           
                isValid= false;
            }


            // 2. Kiểm tra dữ liệu không được phép trùng : Trùng mã khách hàng, trùng số điện thoại
            // - kiểm tra trong database đã có mã khách hàng hay chưa 

            var isExits = _dbContext.CheckExits(customer.CustomerCode, "CustomerCode");
            if (isExits == true)
            {
                if (erroMsg != null)
                    erroMsg.UserMsg.Add( MISA.Common.Properties.Resources.UserMsg_Duplicated_CustomerCode);
            
                isValid= false;
            }

            // - kiểm tra trong database đã có số điện thoại hay chưa 

            isExits = _dbContext.CheckExits(customer.PhoneNumber, "PhoneNumber");
            if (isExits == true)
            {
                if (erroMsg != null)
                    erroMsg.UserMsg.Add(MISA.Common.Properties.Resources.UserMsg_Duplicated_PhoneNumber);
          
                isValid= false;
            }
            return isValid;

        }

    }
}
