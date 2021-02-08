using Dapper;
using Microsoft.AspNetCore.Mvc;
using MISA.BL.Interfaces;
using MISA.CukCuk.Web.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MISA.CukCuk.Web.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CustomerGroupsController : BaseController<CustomerGroup>
    {
        ICustomerGroupBL _customerGroupBL;
        public CustomerGroupsController(ICustomerGroupBL customerGroupBL) : base(customerGroupBL)
        {
            _customerGroupBL = customerGroupBL;
        }


    }
}
