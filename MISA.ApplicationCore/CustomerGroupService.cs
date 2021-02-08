using Microsoft.EntityFrameworkCore;
using MISA.ApplicationCore.Entity;
using MISA.ApplicationCore.interfaces;
using MISA.ApplicationCore.interfaces.Customer;
using MISA.ApplicationCore.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.ApplicationCore
{
    public class CustomerGroupService : BaseService, ICustomerGroupService
    {
        #region DECLARE
        ICustomerGroupRepository _customerGroupRepository;
        #endregion

        #region Constructor
        public CustomerGroupService(ICustomerGroupRepository customerGroupRepository)
        {
            _customerGroupRepository = customerGroupRepository;
        }
        #endregion

        #region METHOD

        public ErrorMsg InsertCustomerGroup(CustomerGroup customerGroup)
        {
            var errorMsg = new ErrorMsg();
            _customerGroupRepository.InsertCustomerGroup(customerGroup);
            errorMsg.devMsg.Add(MISA.ApplicationCore.Properties.Resources.ErrorMsg_AddEmployeeSuccess_dev);
            errorMsg.userMsg.Add(MISA.ApplicationCore.Properties.Resources.ErrorMsg_AddEmployeeSuccess_user);
            errorMsg.success = true;
            return errorMsg;
        }
        #endregion
    }
}
