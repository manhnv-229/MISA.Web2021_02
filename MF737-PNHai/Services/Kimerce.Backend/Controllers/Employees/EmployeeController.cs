using Kimerce.Backend.Domain.Employees;
using Kimerce.Backend.Dto.Models.Employees;
using Kimerce.Backend.Infrastructure.Repositories;
using Kimerce.Backend.Infrastructure.Services.Employees;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kimerce.Backend.Dto.Results;

namespace Kimerce.Backend.Controllers.Employees
{
    [Route("db1/[controller]")]
    [ApiController]
    
    
    public class EmployeeController: ControllerBase
    {
        private readonly IEmployeeService _service;
        /// <summary>
        /// Controller tương tác với Employee trong DB số 1 
        /// </summary>
        /// <param name="service"></param>
        public EmployeeController(IEmployeeService service)
        {
            _service = service;
        }


        /// <summary>
        /// Trả về danh sách các nhận viên 
        /// </summary>
        /// <param name="Filter"></param>
        /// <returns></returns>
        [HttpGet("employees")]
        public async Task<IActionResult> GetAll(String? Filter)
        {
            var res = await _service.GetAll(Filter);
            if(res.Count != 0)
            {
                return StatusCode(200, res);
            }
            else
            {
                return StatusCode(204, res);
            }

        }

        //[HttpPost("employees")]
        //public async Task<IActionResult> CreateOrUpdate([FromBody] EmployeeModel employee)
        //{

        //    var result = await _service.CreateOrUpdate(employee);

        //    if(result.Result == Result.Success)
        //    {
        //        return StatusCode(201, result);
        //    }
        //    else
        //    {
        //        return StatusCode(409, result);
        //    }
        //}
        /// <summary>
        /// Tạo mới một nhân viên
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>

        [HttpPost("employees")]
        public async Task<IActionResult> Create([FromBody] EmployeeModel employee)
        {
            var result = await _service.Create(employee);
            if (result.Result == Result.Success)
            {
                return StatusCode( 201,result);
            }
            else
            {
                return StatusCode( 400 ,result);
            }
        }

        /// <summary>
        /// Chỉnh sửa một nhân viên tồn tại sẵn trong database
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        [HttpPut("employees")]
        public async Task<IActionResult> Update([FromBody] EmployeeModel employee)
        {
            var result = await _service.Update(employee);
            if (result.Result == Result.Success)
            {
                 return StatusCode(201, result); ;
            }
            else
            {
                return StatusCode(409, result);
            }
        }

        /// <summary>
        /// Xóa một nhân viên trong bản ghi - không xóa thật
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("employees")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _service.Delete(id);
            if (result.Result == Result.Success)
            {
                return StatusCode(200, result); ;
            }
            else
            {
                return StatusCode(400, result);
            }
        }
    }
}
