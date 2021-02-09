using System;
using System.Collections.Generic;
using System.Text;
using MISA.Common.Model;
using MISA.DATALayer;
using MISA.DATALayer.Interface;
using MISA.Service.Interface;

namespace MISA.Service
{
    public class CustomerService: BaseService<Customer>, ICustomerService
    {
        ICustomerRepository _customerRepository;
        public CustomerService(ICustomerRepository customerRepository) : base(customerRepository)
        {
            _customerRepository = customerRepository;
        }
        protected override bool validateData(Customer customer, ErrorMsg errorMsg = null)
        {
            var isValid = true;
            //Validate dữ liệu
            //1. Validate bắt buộc nhập
            if (customer.CustomerCode == null || customer.CustomerCode == string.Empty)
            {
                if(errorMsg != null)
                    errorMsg.UserMsg.Add(Properties.Resources.errorEmptyCustomerCode);
                isValid = false;
            }

            //2. Validate không trùng dữ liệu
            //* Kiểm tra mã khách hàng đã tồn tại hay chưa
            var isExits = _customerRepository.checkCustomerCodeExits(customer.CustomerCode);
            if (isExits == true)
            {
                if (errorMsg != null)
                    errorMsg.UserMsg.Add(Properties.Resources.errorDuplicateCustomerCode);
                isValid = false;
            }

            //* Tiếp tục nếu okay
            isExits = _customerRepository.checkPhoneNumberExits(customer.PhoneNumber);
            if (isExits == true)
            {
                if (errorMsg != null)
                    errorMsg.UserMsg.Add(Properties.Resources.errDuplicatePhoneNumber);
                isValid = false;
            }

            return isValid;
        }
    }
}
