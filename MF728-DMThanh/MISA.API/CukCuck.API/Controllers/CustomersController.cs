using CukCuk.BusinessLayer;
using CukCuk.BusinessLayer.Interfaces;
using CukCuk.Common.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace CukCuckAPI.Controllers
{
    [Route("api/v1/[controller]")]
    public class CustomersController : BaseController<Customer>
    {
        public CustomersController(ICustomerBL _customerBL) :base(_customerBL)
        {

        }
    }
}
