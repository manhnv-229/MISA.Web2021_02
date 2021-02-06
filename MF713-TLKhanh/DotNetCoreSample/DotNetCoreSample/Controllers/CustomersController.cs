using AplicationCore.Entities;
using AplicationCore.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace DotNetCoreSample.Controllers
{
    public class CustomersController : BaseController<Customer>
    {
        public CustomersController(ICustomerService customerService) : base(customerService)
        {

        }
    }
}
