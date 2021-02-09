using MISA.Common.Model;
using MISA.Service;
using MISA.Service.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MISA.cukcuk.api.Controllers
{

    public class CustomersController : BaseController<Customer>
    {
        public CustomersController(ICustomerService _customerService):base(_customerService)
        {

        }
    }
}
