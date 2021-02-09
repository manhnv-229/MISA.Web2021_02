using MISA.Common.Model;
using MISA.CUKCUK.DataLayer;
using MISA.DataLayer.Interface;
using MISA.Service.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Service
{
    public class CustomerGroupService: BaseService<CustomerGroup>, ICustomerGroupService
    {
        private readonly ICustomerGroupDL _customerGroupService;

        public CustomerGroupService(IBaseDL<CustomerGroup> baseDL,ICustomerGroupDL customerGroupService): base(baseDL)
        {
            _customerGroupService = customerGroupService;
        }
    }
}
