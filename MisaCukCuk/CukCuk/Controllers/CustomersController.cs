using Common.Model;
using Microsoft.AspNetCore.Mvc;
using ApplicationCore.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CukCuk.Controllers
{
    /// <summary>
    /// Controller cho đối tượng khách hàng
    /// </summary>
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CustomersController : BaseController<Customer>
    {
        public CustomersController(ICustomerService customerService):base(customerService)
        {
        }
    }
}
