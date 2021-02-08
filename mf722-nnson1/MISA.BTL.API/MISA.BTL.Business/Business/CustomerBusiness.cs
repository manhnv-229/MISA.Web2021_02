using System;
using System.Collections.Generic;
using System.Text;
using MISA.BTL.Business.Interfaces;
using MISA.BTL.Common;
using MISA.BTL.Database;
using MISA.BTL.Database.Interfaces;

namespace MISA.BTL.Business
{
    public class CustomerBusiness : BaseBusiness<Customer>, ICustomerBusiness
    {
        IDbConnector<Customer> _dbConnector;
        public CustomerBusiness(IDbConnector<Customer> dbConnector):base(dbConnector)
        {
            _dbConnector = dbConnector;
        }

        /*public ServiceResult GetDataById(string id)
        {
            var serviceResult = new ServiceResult();
            var errorMsg = new ErrorMsg();
            if (_customerRepository.CheckCustomerIdExist(id) == false)
            {
                errorMsg.UserMsg.Add(Properties.Resources.Erro_Customer_Not_Exist);
                serviceResult.Data = errorMsg;
                serviceResult.Success = false;
            }
            else
            {
                serviceResult.Data = customerRepository.GetData($"Proc_GetCustomerById", new { CustomerId = id }, System.Data.CommandType.StoredProcedure);
                serviceResult.Success = true;
            }
            return serviceResult;
        }*/

        protected override bool ValidateData(Customer customer, ErrorMsg errorMsg = null)
        {
            var isValid = true;
            // 1. check trùng mã: 
            if (_dbConnector.CheckCustomerCodeExist(customer.CustomerCode) == true)
            {
                errorMsg.UserMsg.Add(Properties.Resources.Erro_Duplicate_CustomerCode);
                isValid = false;
            }
            if (_dbConnector.CheckPhoneNumberExist(customer.PhoneNumber) == true)
            {
                errorMsg.UserMsg.Add(Properties.Resources.Erro_Duplicate_PhoneNumber);
                isValid = false;
            }
            if (_dbConnector.CheckEmptyCustomerCode(customer.CustomerCode) == true)
            {
                errorMsg.UserMsg.Add(Properties.Resources.Erro_Required_CustomerCode);
                isValid = false;
            }
            if (_dbConnector.CheckEmptyFullName(customer.FullName) == true)
            {
                errorMsg.UserMsg.Add(Properties.Resources.Erro_Required_FullName);
                isValid =  false;
            }
            if (_dbConnector.CheckEmptyPhoneNumber(customer.PhoneNumber) == true)
            {
                errorMsg.UserMsg.Add(Properties.Resources.Erro_Required_PhoneNumber);
                isValid = false;
            }
            if (_dbConnector.CheckEmptyEmail(customer.Email) == true)
            {
                errorMsg.UserMsg.Add(Properties.Resources.Erro_Required_Email);
                isValid = false;
            }

            return isValid;

        }
    }
}
