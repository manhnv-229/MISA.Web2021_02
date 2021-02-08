using Dapper;
using Microsoft.AspNetCore.Mvc;
using MISA.Common.Models;
using MISA.Service;
using MISA.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using MISA.Service.Interface;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MISA.DEMO.API.Controllers
{
    [Route("api/employees")]
    [ApiController]
    public class EmployeesController : BaseController<Employee>
    {
        
        public EmployeesController(IEmployeeService _employeeService) : base(_employeeService)
        {

        }


        /// <summary>
        /// PVTRONG 31/12/2020
        /// </summary>
        /// <returns>Trả về mã số nhân viên lớn nhất </returns>
        //[HttpGet("EmployeeCodeMax")]
        //public IActionResult Get()
        //{
        //    var employee = new Employee();
        //    // Lấy dữ liệu:
        //    var employeeCode = dbConnection.Query<Employee>("Proc_GetEmployeeCodeMax", commandType: CommandType.StoredProcedure).FirstOrDefault();

        //    return Ok(employeeCode);
        //}

        /// <summary>
        /// PVTRONG 31/12/2020
        /// </summary>
        /// <param name="employeeId">ID của nhân viên</param>
        /// <returns>Trả về thông tin của nhân viên đó</returns>
        // GET api/<EmployeesController>/5
        //[HttpGet("{employeeId}")]
        //public IActionResult Get(Guid employeeId)
        //{
        //    var employee = new Employee();

        //    var sqlQuery = $"Proc_GetEmployeeById";
        //    // Lấy dữ liệu:
        //    employee = dbConnection.Query<Employee>(sqlQuery, new { EmployeeId = employeeId.ToString()}, commandType:CommandType.StoredProcedure).FirstOrDefault();

        //    return Ok(employee);
        //}

        /// <summary>
        /// PVTRONG 31/12/2020
        /// </summary>
        /// <param name="keyword">từ khóa tìm kiếm</param>
        /// <param name="positionId">Vị trí/ chức vụ</param>
        /// <param name="departmentId">Phòng ban nào</param>
        /// <param name="limitParam">Số lượng bản ghi lấy</param>
        /// <param name="offsetParam">Lấy từ bản ghi thứ bao nhiêu</param>
        /// <returns>Trả về danh sách nhân viên theo tìm kiếm</returns>
        // GET api/<EmployeesController>/search
        //[HttpGet("search")]
        //public IActionResult Get([FromQuery] string keyword, [FromQuery] string positionId, [FromQuery] string departmentId,[FromQuery] string limitParam,[FromQuery] string offsetParam)
        //{
        //        var employees = new List<Employee>();
        //    if (keyword == null)
        //    {
        //        keyword = "N";
        //    }
        //    if (positionId == null)
        //    {
        //        positionId = "-";
        //    }
        //    else positionId = positionId.ToString(); 
        //    if (departmentId == null)
        //    {
        //        departmentId = "-";
        //    }
        //    else departmentId = departmentId.ToString();
        //    // Lấy dữ liệu:
        //    employees = dbConnection.Query<Employee>($"Proc_Search", new { keyword = keyword.ToString(), positiont = positionId, departmentt = departmentId, LimitParam = limitParam, OffsetParam = offsetParam }, commandType: CommandType.StoredProcedure).ToList();

        //    return Ok(employees);
        //}


        ///// <summary>
        ///// PVTRONG 31/12/2020
        ///// </summary>
        ///// <param name="employeeIds">ID của nhân viên được xóa</param>
        ///// <returns>Trả về tình trạng xóa</returns>
        //// DELETE api/<CustomersController>/5
        //[HttpDelete]
        //public IActionResult Delete([FromBody] string[] employeeIds)
        //{

        //    var sqlQuery = $"Proc_DeleteEmployee";
        //    foreach (string item in employeeIds)

        //    {
        //        dbConnection.Query(sqlQuery, new { EmployeeId = item.ToString() }, commandType: CommandType.StoredProcedure);
        //    }
        //    return Ok();
        //}
    }
}
