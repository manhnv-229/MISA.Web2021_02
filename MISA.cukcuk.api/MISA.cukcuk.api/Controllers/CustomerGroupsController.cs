using Microsoft.AspNetCore.Mvc;
using MISA.Common.Model;
using MISA.Service;
using MISA.Service.Interfaces;
using System.Collections.Generic;

namespace MISA.cukcuk.api.Controllers
{
    [Route("api/v1/customer-groups")]
    [ApiController]
    public class CustomerGroupsController : BaseController<CustomerGroup>
    {
       public CustomerGroupsController(IBaseService<CustomerGroup> customerGroupService):base(customerGroupService)
        {

        }
    }
}

