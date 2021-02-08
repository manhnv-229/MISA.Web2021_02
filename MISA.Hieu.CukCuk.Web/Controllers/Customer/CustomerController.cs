using Microsoft.AspNetCore.Mvc;
using MISA.ApplicationCore.Entity;
using MISA.ApplicationCore.interfaces;
using MISA.ApplicationCore.interfaces.Customer;
using MISA.ApplicationCore.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MISA.Hieu.CukCuk.Web.Controllers.Customer
{
    [ApiController]
    public class CustomerController : BaseController<Customers>
    {
        #region DECLARE
        ICustomerService _customerService;
        IBaseService _baseService;
        #endregion

        #region CONSTRUCTOR
        public CustomerController(ICustomerService customerService, IBaseService baseService)
        {
            _customerService = customerService;
            _baseService = baseService;
        }
        #endregion

        #region METHOD
        // GET: api/<Customer>
        /// <summary>
        /// Lấy danh sách khách hàng
        /// </summary>
        /// <returns>Danh sách khách hàng</returns>
        /// CreatedBy: BDHIEU (07/02/2021)
        /*[HttpGet]
        public IActionResult Get()
        {
            var serviceResult = _baseService.GetData<Customers>();
            if(serviceResult.Data != null)
            {
                return StatusCode(204, serviceResult.Data);
            }
            else
            {
                return StatusCode(200, serviceResult.Data);
            }
        }*/

        // GET api/<Customer>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<Customer>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<Customer>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<Customer>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
        #endregion
    }
}
