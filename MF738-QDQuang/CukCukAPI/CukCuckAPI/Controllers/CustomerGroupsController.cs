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
    [ApiController]
    public class CustomerGroupsController : BaseController<CustomerGroup>
    {
        public CustomerGroupsController(IBaseBL<CustomerGroup> baseBL) : base(baseBL)
        {

        }
    }
}
