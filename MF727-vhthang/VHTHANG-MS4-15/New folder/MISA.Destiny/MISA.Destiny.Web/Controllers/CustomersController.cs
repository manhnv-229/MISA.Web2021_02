using Dapper;
using Microsoft.AspNetCore.Mvc;
using MISA.Destiny.Web.Controllers.Models;
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
        // GET: api/<CustomersController>
        [HttpGet]
        public List<Customer> Get()
        {
            List<Customer> customers = new List<Customer>();
            string connectionString = "Host=103.124.92.43;User Id=nvmanh; password=12345678;Database=MS4_15_VHTHANG_destiny;Charater Set=utf8";
            using (IDbConnection db = new MySqlConnection(connectionString))
            {
                customers = db.Query<Customer>("Select * FROM Customers").ToList();
            }
            return customers;
        }

        // GET api/<CustomersController>/5
        [HttpGet("{id}")]
        public Customer Get(Guid id)
        {
            var customer = new Customer();
            string connectionString = "Host=103.124.92.43;User Id=nvmanh; password=12345678;Database=MS4_15_VHTHANG_destiny;Charater Set=utf8";
            using (IDbConnection dbConnection = new MySqlConnection(connectionString))
            {
                var sqlQuery = $"Proc_GetCustomerById";
                customer = dbConnection.Query<Customer>(sqlQuery, new { CustomerId = id.ToString() }, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
            return customer;
        }

        // POST api/<CustomersController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<CustomersController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CustomersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}




