using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MISA.Service;
using MISA.Common.Model;

namespace MISA.CukCuk.Api.Controllers
{
    [Route("api/v1/customer-groups")]
    [ApiController]
    public class CustomerGroupController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            var customerGroupService = new CustomerGroupService();
            var actionServiceResult = customerGroupService.GetData();
            var customerGroups = actionServiceResult.data as List<CustomerGroup>;
            if (customerGroups.Count == 0)
                return StatusCode(204, actionServiceResult.data);
            else
                return StatusCode(200, actionServiceResult.data);
        }
        public IActionResult PostCustomerGroup(CustomerGroup customerGroup)
        {
            var customerGroupService = new CustomerGroupService();
            var res = customerGroupService.InsertCustomerGroup(customerGroup);
            if (res.Success == false)
            {
                return StatusCode(400, res.data);
            }
            else if (res.Success == true && (int)res.data > 0)
            {
                return StatusCode(201, res.Message);
            }
            else
            {
                return StatusCode(200, res.data);
            }
        }
    }
}
