using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MISA.Service;
using MISA.Common.Models;
using MISA.Service.Interfaces;

namespace MISA.CukCuk.Api.Controllers
{
    [Route("api/v1/customer-groups")]
    public class CustomerGroupsController : BaseController<CustomerGroup>
    {
        /// <summary>
        /// Khởi tạo biến kết nối CustomerGroupService và truyền thông tin lên base
        /// </summary>
        /// <param name="customerGroupService">biến để truyền lên base</param>
        /// CreatedBy: NTTHIEM
        /// CreatedDate: 08/02/2021
        public CustomerGroupsController(ICustomerGroupService customerGroupService) :base(customerGroupService)
        {
        }
    }
}
