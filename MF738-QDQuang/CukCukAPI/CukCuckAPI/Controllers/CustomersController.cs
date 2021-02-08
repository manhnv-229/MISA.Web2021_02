using CukCuk.BL;
using CukCuk.BL.Interfaces;
using CukCuk.Common.Models;
using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
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
