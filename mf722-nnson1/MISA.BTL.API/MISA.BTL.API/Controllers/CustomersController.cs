using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MISA.BTL.Business;
using MISA.BTL.Business.Interfaces;
using MISA.BTL.Common;

namespace MISA.BTL.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CustomersController : BaseController<Customer>
    {
        public CustomersController(ICustomerBusiness _customerBusiness):base(_customerBusiness)
        {
        }

        /*[HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            var res = _customerBusiness.GetCustomerById(id);
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
