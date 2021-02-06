using AplicationCore.Entities;
using AplicationCore.Interfaces;
using System;
using System.Data;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace AplicationCore.Services
{
    public class CustomerService : BaseService<Customer>, ICustomerService
    {
        ICustomerRepository _customerRepository;
        public CustomerService(ICustomerRepository customerRepository) : base(customerRepository)
        {
            _customerRepository = customerRepository;
        }
        public override bool Validate(Customer customer, ErrorMsg errorMsg = null, string id = null)
        {
            bool isValid = true;
            // Sử lý validate chung
            if(customer.CustomerCode == string.Empty || customer.CustomerCode == null)
            {
                if(errorMsg != null)
                    errorMsg.UserMsg.Add("Mã khách hàng không được để trống!");
                isValid = false;
            }
            if(customer.PhoneNumber == string.Empty || customer.PhoneNumber == null)
            {
                if (errorMsg != null)
                    errorMsg.UserMsg.Add("Số điện thoại không được để trống!");
                isValid = false;
            }
            if (customer.FullName == string.Empty || customer.FullName == null)
            {
                if (errorMsg != null)
                    errorMsg.UserMsg.Add("Họ và tên không được để trống!");
                isValid = false;
            }
            
            var customerByCode = _customerRepository.Get($"Select * from Customer Where CustomerCode = '{customer.CustomerCode}'").FirstOrDefault();
            var customerByPhone = _customerRepository.Get($"Select * from Customer Where PhoneNumber = '{customer.PhoneNumber}'").FirstOrDefault();
            // Xử lý valy date các trường cho update
            if(id != null)
            {
                var customerById = _customerRepository.Get($"Select * from Customer Where CustomerId = '{id}'").FirstOrDefault();
                if (customerByCode != null && customerByCode.CustomerCode != customerById.CustomerCode)
                {
                    if (errorMsg != null)
                        errorMsg.UserMsg.Add("Mã khách hàng đã tồn tại, vui lòng kiểm tra lại!");
                    isValid = false;
                }

                if (customerByPhone != null && customerByPhone.PhoneNumber != customerById.PhoneNumber)
                {
                    if (errorMsg != null)
                        errorMsg.UserMsg.Add("Số điện thoại đã được sử dụng, vui lòng kiểm tra lại!");
                    isValid = false;
                }
            }
            // Xử lý valy date các trường cho insert
            else
            {
                if (customerByCode != null)
                {
                    if (errorMsg != null)
                        errorMsg.UserMsg.Add("Mã khách hàng đã tồn tại, vui lòng kiểm tra lại!");
                    isValid = false;
                }

                if (customerByPhone != null)
                {
                    if (errorMsg != null)
                        errorMsg.UserMsg.Add("Số điện thoại đã được sử dụng, vui lòng kiểm tra lại!");
                    isValid = false;
                }
            }
            
            return isValid;
        }
    }
}
