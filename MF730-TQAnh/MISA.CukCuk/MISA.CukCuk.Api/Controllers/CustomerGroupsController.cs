using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.Common.Model;
using MISA.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.CukCuk.Api.Controllers
{
    /// <summary>
    /// Controller cho nhóm khách hàng
    /// </summary>
    ///   CreatedBy: TQAnh (08/02/2021)
    [Route("api/v1/customer-groups")]
    [ApiController]

   
    public class CustomerGroupsController : BaseController<CustomerGroup>
    {


        public CustomerGroupsController(ICustomerGroupService customerGroupService) : base(customerGroupService)
        {
        }
    }
}
