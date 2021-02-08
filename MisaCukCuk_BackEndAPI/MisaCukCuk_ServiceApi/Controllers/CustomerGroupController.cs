using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MisaCukCuk_ApplicationCore.ApplicationCore.CustomerGroupApplicationCore;
using MisaCukCuk_Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MisaCukCuk_ServiceApi.Controllers
{
    public class CustomerGroupController : BaseController<CustomerGroup>
    {
        ICustomerGroupApplicationCore _code;
        public CustomerGroupController(ICustomerGroupApplicationCore customerGroupApplicationCore) : base(customerGroupApplicationCore)
        {
            _code = customerGroupApplicationCore;
        }

    }
}
