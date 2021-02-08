using MISA.ApplicationCore.Entity;
using MISA.ApplicationCore.interfaces.Customer;
using MISA.ApplicationCore.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.ApplicationCore
{
    public class CustomerService : BaseService, ICustomerService
    {
        #region DECLARE
        ICustomerRepository _customerRepository;
        #endregion

        #region Constructor
        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }
        #endregion


        #region METHOD
        /// <summary>
        /// Lấy danh sách khách hàng
        /// </summary>
        /// <returns>Danh sách khách hàng</returns>
        /// CreatedBy: BDHIEU (07/02/2021)
        public ServiceResult GetCustomers()
        {
            var serviceResult = new ServiceResult();
            serviceResult.Data = _customerRepository.GetCustomers();
            return serviceResult;
        }
        #endregion
    }
}
