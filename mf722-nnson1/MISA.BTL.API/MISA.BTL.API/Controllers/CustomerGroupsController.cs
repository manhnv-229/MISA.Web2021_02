using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.BTL.Business.Interfaces;
using MISA.BTL.Common;

namespace MISA.BTL.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CustomerGroupsController : BaseController<CustomerGroup>
    {
        public CustomerGroupsController(ICustomerGroupBusiness _customerGroupBusiness) : base(_customerGroupBusiness)
        {
        }

        /*[HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            var res = _customerGroupBusiness.GetCustomerGroupById(id);
            if (res.Success == false)
            {
                return StatusCode(400, res.Data);
            }
            else
            {
                return StatusCode(200, res.Data);
            }
        }*/

        
    }
}
