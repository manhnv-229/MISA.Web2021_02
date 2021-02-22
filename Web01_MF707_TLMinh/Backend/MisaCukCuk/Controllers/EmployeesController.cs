using Common;
using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.Service.Interfaces;
using MySql.Data.MySqlClient;
using Service;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace MisaCukCuk.Controllers
{
    [Route("api/v1/employees")]
    [ApiController]
    public class EmployeesController : BasesController<Employee>
    {
        public EmployeesController(IEmployeeService employeeService) : base(employeeService)
        { 
        
        }
    }

}
