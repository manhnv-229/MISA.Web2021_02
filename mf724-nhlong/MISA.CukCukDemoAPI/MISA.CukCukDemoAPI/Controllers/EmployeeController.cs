using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using MISA.Service;
using MISA.Service.Entities;
using MISA.Service.Interfaces;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DemoApi.Controllers
{
    public class EmployeeController : BaseController<Employee>
    {
       #region Declare Field
        IEmployeeServices  _employeeService;

        #endregion

        #region Constructor
        public EmployeeController(IEmployeeServices  employeeService):base(employeeService)
        {
            _employeeService = employeeService;

        }
        #endregion


        #region Children Own Method
        /// <summary>
        /// Controller nhận request GET lấy về Mã Nhân Viên mới nhất trong DB
        /// </summary>
        /// <returns>Mã Nhân viên lớn nhất tại thời điểm gọi hàm</returns>
        /// Created By : NHLong (07/02/2021)
        [HttpGet()]
        [Route("/api/v1/Employee/GetLastestEmployeeCode")]
        public IActionResult GetLastestEmployeeCode()
        {
                var employees = _employeeService.GetLastestEmployeeCode();
                if (employees.Data != null)
                    return Ok( new
                    {
                        Success = true,
                        Message = employees.Data
                    });
                else 
                    return Ok( new
                    {
                        Success = true,
                        Message = "Null"
                    });

        }

        // GET api/GetEmployeeByDepartmentID/<DepartmentID>

        // PUT api/<EmployeeController>/5
        [HttpPut()]
        public override IActionResult UpdateEntity( [FromBody] Employee employee)
        {
 
                var effecRows = _employeeService.UpdateEntity(employee);
                return Ok(new
                {
                    Success = true,
                    Message = "Thành Công",
                    Data = effecRows.Data
                });

        }

        #endregion
    }
}
