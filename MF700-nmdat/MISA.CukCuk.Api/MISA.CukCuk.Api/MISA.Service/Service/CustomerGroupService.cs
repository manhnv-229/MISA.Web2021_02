using MISA.Common.Model;
using MISA.DataLayer;
using MISA.DataLayer.Interface;
using MISA.Service.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Service
{
    public class CustomerGroupService :BaseService<CustomerGroup> , ICustomerGroupService
    {
        #region Contructor
        public CustomerGroupService(ICustomerGroupDBConnection customerGroupDBConnection) : base(customerGroupDBConnection)
        {

        }
        #endregion

    }
}
