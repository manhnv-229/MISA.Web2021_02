using Microsoft.AspNetCore.Mvc;
using MISA.Common.Models;
using MISA.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MISA.CukCuk.Web.Models
{
    [Route("api/[controller]")]
    [ApiController]
    public class PositionController : ControllerBase
    {
        protected DbConnector dbConnector;
        public PositionController()
        {
            dbConnector = new DbConnector();
        }
        /// <summary>
        /// Trả về danh sách vị trí/ chức vụ
        /// </summary>
        /// <returns>Trả về danh sách chức vụ</returns>
        [HttpGet("AllPosition")]

        public IActionResult Get()
        {
            return Ok(dbConnector.GetAllPosition<Position>());
        }
        
        // GET api/<PositionController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<PositionController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<PositionController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PositionController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
