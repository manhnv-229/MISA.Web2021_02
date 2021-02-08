using MISA.Common.Model;
using MISA.DataLayer.Interfaces;
using MISA.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Service
{  
   /// <summary>
   /// service cho nhóm khách hàng
   /// </summary>
   /// CreatedBy: TQAnh (08/02/2021)
    public class CustomerGroupService : BaseService<CustomerGroup>, ICustomerGroupService
    {

      
        public CustomerGroupService(ICustomerGroupRepository customerGroupRepository) : base(customerGroupRepository)
        {

        }
    }
}
