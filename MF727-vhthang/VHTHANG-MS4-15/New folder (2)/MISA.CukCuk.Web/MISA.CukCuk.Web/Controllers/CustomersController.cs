using Dapper;
using Microsoft.AspNetCore.Mvc;
using MISA.BL;
using MISA.BL.Interfaces;
using MISA.Common;
using MISA.CukCuk.Web;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MISA.Destiny.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        ICustomerBL _customerBL;
        public CustomersController(ICustomerBL customerBL)
        {
            _customerBL = customerBL;
        }
        //DbConnector dbConnector;
        //public CustomersController() {
        //    dbConnector = new DbConnector();
        //}
        
        //// GET: api/<CustomersController>
        //[HttpGet]
        //public IActionResult Get()
        //{
        //    return Ok(dbConnector.GetAllData<Customer>());
            
        //}
        //[HttpGet("{id}")]
        //public IActionResult Get(string id)
        //{
        //    return Ok(dbConnector.GetById<Customer>(id));

        //}
        //[HttpGet("search")]
        //public IActionResult Get([FromQuery] string phone, [FromQuery] string code)
        //{
        //    return Ok(dbConnector.GetDataByPhoneAndCode<Customer>(phone,code));

        //}
        [HttpPost]
        public IActionResult Post(Customer customer)
        {
            
            var rowEffects = _customerBL.InsertCustomer(customer);
            if(rowEffects == -1)
            {
                return BadRequest("Mã khách hàng bị trùng rồi bro nhé");
            }
            else
            {
                return Ok(rowEffects);
            }
            

        }




    }
}




