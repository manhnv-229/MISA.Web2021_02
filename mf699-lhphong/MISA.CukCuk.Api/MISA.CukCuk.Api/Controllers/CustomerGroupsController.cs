using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MISA.Service;
using MISA.Common.Model;
using MISA.Service.Interface;

namespace MISA.CukCuk.Api.Controllers
{
    [Route("api/v1/customer-groups")]
    public class CustomerGroupsController : BaseController<CustomerGroup>
    {
        public CustomerGroupsController(IBaseService<CustomerGroup> _customerGroupController) : base(_customerGroupController)
        {

        }
        
    }
}
