using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MISA.Service;
using System.Linq;
using MISA.Common.Model;

namespace MISA.CukCuk.Api.Controllers
{
    [Route("api/v1/customer-groups")]
    [ApiController]
    public class CustomerGroupsController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            var customerGroupService = new CustomerGroupService();
            var serviceResult = customerGroupService.GetCustomerGroups();
            var customerGroups = serviceResult.Data as List<CustomerGroup>;          
            if(customerGroups.Count == 0)
                return StatusCode(204, serviceResult.Data);
            else
                return StatusCode(200, serviceResult.Data);
        }
    }
}
