using Dapper;
using Microsoft.AspNetCore.Mvc;
using MISA.Common.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using MISA.Service;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MISA.CukCuk.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {

        // GET: api/<CustomerController>
        [HttpGet]
        public IActionResult GetCustomers()
        {
            var customerService = new CustomerService();
            var actionServiceResult = customerService.GetData();
            var customers = actionServiceResult.data as List<Customer>;
            if (customers.Count == 0)
                return StatusCode(204, actionServiceResult.data);
            else
                return StatusCode(200, actionServiceResult.data);
        }

        // GET api/<CustomerController>/5
        [HttpGet]
        [Route("filter")]
        public IActionResult GetCustomerByCodeAndPhone()
        {
            var customerService = new CustomerService();
            var actionServiceResult = customerService.GetCustomerByCodeAndPhone();
            var customers = actionServiceResult.data as List<Customer>;
            if (customers.Count == 0)
                return StatusCode(204, actionServiceResult.data);
            else
                return StatusCode(200, actionServiceResult.data);
        }

        // POST api/<CustomerController>
        [HttpPost]
        public IActionResult PostCustomer(Customer customer)
        {
            CustomerService customerService = new CustomerService();
            var res = customerService.Insert(customer);
            if(res.Success == false)
            {
                return StatusCode(400, res.data);
            }
            else if(res.Success == true && (int)res.data>0)
            {
                return StatusCode(201, res.Message);
            }
            else
            {
                return StatusCode(200, res.data);
            }
        }

        // PUT api/<CustomerController>/5
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] Customer customer)
        {
            CustomerService customerService = new CustomerService();
            var res = customerService.Update(id, customer);
            if (res.Success == false)
            {
                return StatusCode(400, res.data);
            }
            else if (res.Success == true && (int)res.data > 0)
            {
                return StatusCode(201, res.Message);
            }
            else
            {
                return StatusCode(200, res.data);
            }
        }

        // DELETE api/<CustomerController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            CustomerService customerService = new CustomerService();
            var res = customerService.Delete(id);
            return StatusCode(200, res.data);
        }
    }
}
