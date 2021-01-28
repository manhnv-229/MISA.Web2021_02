using Dapper;//xoa
using Microsoft.AspNetCore.Mvc;
using MISA.BL.Interfaces;
using MISA.Common;
using MySql.Data.MySqlClient;//xóa
using System;
using System.Collections.Generic;
using System.Data;//xóa
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MISA.CukCuk.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        //Khởi tạo Service
        IEmployeeBL _employeeBL;

        public EmployeesController(IEmployeeBL employeeBL)
        {
            _employeeBL = employeeBL;
        }

        // Lấy toàn bộ Dữ liêu nhân viên 
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_employeeBL.GetEmployees());
        }
        //Lấy dữ liệu nhân viên theo số trang và cách sắp sếp
        [HttpGet("page")]
        public IActionResult Get(int num ,int type)
        {
            return Ok(_employeeBL.GetEmployeeByNumAndType(num,type));
        }


        // Lấy thông tin 1 nhân viên theo code
        [HttpGet("{code}")]
        public IActionResult Get(string code)
        {
            return Ok(_employeeBL.GetEmployeeByCode(code));
        }


        // Lấy Mã code cao nhất
        [HttpGet("code")]
        public IActionResult Get(string code, string id)
        {
            return Ok(_employeeBL.GetEmployeeCodeMax());

        }

        
        // Thêm mới nhân viên(Có check trùng mã)
        [HttpPost]
        public IActionResult Post(Employee employee)
        {
            var serviceResult = _employeeBL.InsertEmployee(employee);
            if (serviceResult.MISACode == MISACode.NotValid)
            {
                return BadRequest(serviceResult.Data);
            }
            if (serviceResult.MISACode == MISACode.IsValid && (int)serviceResult.Data > 0)
            {
                return Created("Success", serviceResult.Messenger);
            }
            else return NoContent();
        }

        // Update nhân viên

        [HttpPost("update")]
        public IActionResult Post(Employee employee, string code)
        {
            var serviceResult = _employeeBL.UpdateEmployee(employee);
            if (serviceResult.MISACode == MISACode.NotValid)
            {
                return BadRequest(serviceResult.Messenger);
            }
            if (serviceResult.MISACode == MISACode.IsValid && (int)serviceResult.Data > 0)
            {
                return Created("Success", serviceResult.Messenger);
            }
            else return NoContent();
        }


        //xóa 1 nhân viên
        [HttpPost("delete")]
        public IActionResult Delete([FromBody] string id)
        {
            var serviceResult = _employeeBL.DeleteEmployee(id);
            
            if (serviceResult.MISACode == MISACode.Success && (int)serviceResult.Data > 0)
            {
                return Created("Success", serviceResult.Messenger);
            }
            else return NoContent();
        }
    }
}

