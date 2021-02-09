using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.Common.Models;
using MISA.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.CukCuk.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        protected DbConnector dbConnector;
        public DepartmentController()
        {
            dbConnector = new DbConnector();
        }
        /// <summary>
        /// Trả về danh sách phòng ban
        /// </summary>
        /// <returns>Trả về danh sách phòng ban</returns>
        [HttpGet("AllDepartment")]

        public IActionResult Get()
        {
            return Ok(dbConnector.GetAllDepartment<Department>());
        }
    }
}
