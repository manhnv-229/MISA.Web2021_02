using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MisaCukCuk_ApplicationCore.ApplicationCore.CustomerApplicationCore;
using MisaCukCuk_Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MisaCukCuk_ServiceApi.Controllers
{
    public class CustomerController : BaseController<Customer>
    {
        ICustomerApplicationCore _code;
        public CustomerController(ICustomerApplicationCore customerApplicationCore) : base(customerApplicationCore)
        {
            _code = customerApplicationCore;
        }
    }
}
