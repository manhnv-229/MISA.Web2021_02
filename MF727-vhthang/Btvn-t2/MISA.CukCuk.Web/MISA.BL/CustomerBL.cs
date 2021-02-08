using MISA.BL.Interfaces;
using MISA.Common;
using MISA.Common.Entities;
using MISA.Common.Properties;
using MISA.DL;
using MISA.DL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace MISA.BL
{
    public class CustomerBL : BaseBL<Customer>, ICustomerBL
    {
        ICustomerDL _customerDL;
        IDbContext<Customer> _dbContext;
        public CustomerBL(IDbContext<Customer> dbContext, ICustomerDL customerDL) :base(dbContext)
        {
            _customerDL = customerDL;
            _dbContext = dbContext;
        }

        /// <summary>
        /// Overrride hàm kiểm tra dữ liệu
        /// </summary>
        /// <param name="customer">Khách hàng</param>
        /// <returns>ServiceResult</returns>
        protected override ServiceResult Validate(Customer customer)
        {
            var serviceResult = new ServiceResult();
            //Kiểm tra trùng mã
            var checkCode = _customerDL.CheckDuplicate("CustomerCode", customer.CustomerCode);
            if (checkCode.Count() > 0)
            {
                var msg = new
                {
                    devMsg = new { fieldName = "CustomerCode", Messenger = Resources.ErroService_DuplicateCustomerCode },
                    userMsg = Resources.ErroService_DuplicateCustomerCode,
                };
                serviceResult.MISACode = MISACode.NotValid;
                serviceResult.Messenger = Resources.ErroService_DuplicateCustomerCode;
                serviceResult.Data = msg;
                return serviceResult;
            }
            //Kiểm tra số điện thoai
            var checkPhone = _customerDL.CheckDuplicate("PhoneNumber", customer.PhoneNumber);
            if (checkPhone.Count() > 0)
            {
                var msg = new
                {
                    devMsg = new { fieldName = "PhoneNumber", Messenger = Resources.ErroService_DuplicatePhoneNumber },
                    userMsg = Resources.ErroService_DuplicatePhoneNumber,
                };
                serviceResult.MISACode = MISACode.NotValid;
                serviceResult.Messenger = Resources.ErroService_DuplicatePhoneNumber;
                serviceResult.Data = msg;
                return serviceResult;
            }
            serviceResult.MISACode = MISACode.IsValid;
            serviceResult.Messenger = Resources.SuccessService_IsVaid;
            serviceResult.Data = 1;
            return serviceResult;
        }







        //public int InsertCustomer(Customer customer)
        //{
        //    //CustomerDL customerDL = new CustomerDL();
        //    // check trung ma
        //    if(_customerDL.CheckDuplicateCustomerCode(customer.CustomerCode) == true)
        //    {
        //        return -1;
        //    }
        //    else
        //    {
        //        var effectRows = _customerDL.Insert(customer);
        //        return effectRows;
        //    }
        //    // check trung sdt

        //}
    }
}
