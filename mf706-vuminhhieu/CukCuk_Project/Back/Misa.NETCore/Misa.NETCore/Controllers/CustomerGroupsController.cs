using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Misa.Bussiness.Version1;

namespace Misa.NETCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerGroupsController : ControllerBase
    {

        private CustomerGroupBussiness customerGroupBussiness;
        public CustomerGroupsController()
        {
            customerGroupBussiness = new CustomerGroupBussiness();
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(customerGroupBussiness.GetData());
        }
    }
}
