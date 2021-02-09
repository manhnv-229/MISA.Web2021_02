using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using MISA.Service;
using MISA.Common.Model;
using MISA.Service.Interface;

namespace MISA.CukCuk.Api.Controllers
{
    [Route("api/v1/customers")]
    public class CustomersController : BaseController<Customer>
    {
        public CustomersController(ICustomerService _customerService) : base(_customerService)
        {

        }
    }
}
