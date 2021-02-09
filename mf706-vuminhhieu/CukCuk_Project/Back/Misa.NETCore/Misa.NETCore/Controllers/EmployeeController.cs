using Microsoft.AspNetCore.Mvc;
using Misa.Bussiness;
using Misa.Bussiness.Interfaces;
using Misa.Common.Entities;
using Misa.Common.Requests;
using Misa.Common.Requests.Employee;
using Misa.Data;
using Misa.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Misa.NETCore.Controllers
{
    [Route("api/employee")]
    [ApiController]
    public class EmployeeController : BaseController<Employee>
    {
        private IEmployeeBussiness _employeeBussiness;       

        public EmployeeController(IEmployeeBussiness employeeBussiness, IBaseBussiness<Employee> baseBussiness):base(baseBussiness)
        {
            _employeeBussiness = employeeBussiness;
           
        }


        // GET: api/employee/allFull
        [HttpGet("fullAll")]
        public async Task<IActionResult> GetFull()
        {
            return Ok(await _employeeBussiness.GetFullData());
        }


        [HttpGet("")]
        public async Task<IActionResult> Get(string keyword, string departmentId, string positionId, int pageIndex, int pageSize)
        {
           
            PageRequest pageRequest = new PageRequest() { 
                KeyWord = keyword,
                DepartmentId = departmentId,
                PositionId = positionId,
                PageIndex = pageIndex,
                PageSize = pageSize };
            return Ok(await _employeeBussiness.GetData(pageRequest));
        }


        // POST api/Employee
        [HttpPost]
        public override async Task<IActionResult> Post([FromBody] Employee employee)
        {
            var result =await _employeeBussiness.Insert(employee);
            return Ok(result);
        }

        // PUT api/Employee
        [HttpPut("")]
        public override async Task<IActionResult> Put([FromBody] Employee employee)
        {
            var result = await _employeeBussiness.Update(employee);
            return Ok(result);
        }

    }
}
