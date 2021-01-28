using Dapper;
using Microsoft.AspNetCore.Mvc;
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
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerGroupsController : ControllerBase
     {
        //DbConnector dbConnector;
        //public CustomerGroupsController()
        //{
        //    dbConnector = new DbConnector();
        //}

        //// GET: api/<CustomersController>
        //[HttpGet]
        //public IActionResult Get()
        //{
        //    return Ok(dbConnector.GetAllData<CustomerGroup>());
        //}


        //[HttpGet("{id}")]
        //public IActionResult Get(string id)
        //{
        //    return Ok(dbConnector.GetById<CustomerGroup>(id));

        //}
        //[HttpPost]
        //public IActionResult Post(CustomerGroup customerGroup)
        //{
        //    return Ok(dbConnector.Insert<CustomerGroup>(customerGroup));

        //}


    }
}
