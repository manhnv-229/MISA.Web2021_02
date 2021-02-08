using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.Service.Services;
using MISA.Common.Enum;
using MISA.DataLayer;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using MISA.Common.Models;
using MISA.Service;
using MISA.Service.Interfaces;

namespace MISA.DEMO.API.Controllers
{
    public class EmployeesController : BaseEntityController<Employee>
    {
        
        IEmployeeService _baseService;
        public EmployeesController(IEmployeeService baseService):base(baseService)
        {
           
            _baseService = baseService;
        }

        [HttpGet("code")]
        public  IActionResult Get([FromQuery] string employeeCode)
        {
            var employees = _baseService.GetByEmployeeCode(employeeCode);
            return Ok(employees);
        }

    }
}
