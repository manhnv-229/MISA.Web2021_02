using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.DataLayer;
using MISA.Common.Models;
using MISA.Services;

namespace MISA_API_Demo.Controllers
{
    public class EmployeesController : BaseEntityController<Employee>
    {

        /// <summary>
        /// Tạo mới nhân viên
        /// </summary>
        /// <param name="employee">Thực thể nhân viên mới</param>
        /// <returns>Response tương ứng cho Client</returns>
        /// CreatedBy: TXTrinh (02/02/2021)
        public override IActionResult Post([FromBody] Employee employee)
        {
            employee.EmployeeId = Guid.NewGuid();

            EmployeeService employeeService = new EmployeeService();
            var res = employeeService.InsertEmployee(employee);
            switch (res.MISACode)
            {
                case EnumCodes.Success:
                    return Ok(res);
                case EnumCodes.BadRequest:
                    return BadRequest(res);
                case EnumCodes.Exception:
                    return StatusCode(500);
                default:
                    return NoContent();
            }
        }
        /// <summary>
        /// Sửa thông tin nhân viên
        /// </summary>
        /// <param name="employee">Thực thể đã sửa</param>
        /// <returns>Response tương ứng cho Client</returns>
        /// CreatedBy: TXTrinh (02/02/2021)
        public override IActionResult Put([FromBody] Employee employee)
        {
            EmployeeService employeeService = new EmployeeService();
            var res = employeeService.UpdateEmployee(employee);
            switch (res.MISACode)
            {
                case EnumCodes.Success:
                    return Ok(res);
                case EnumCodes.BadRequest:
                    return BadRequest(res);
                case EnumCodes.Exception:
                    return StatusCode(500);
                default:
                    return NoContent();
            }
        }
        /// <summary>
        /// Tìm kiếm bản ghi theo điều kiện
        /// </summary>
        /// <param name="EmployeeCode">Mã nhân viên</param>
        /// <param name="Position">Vị trí</param>
        /// <param name="Department">Phòng ban</param>
        /// <returns>List bản ghi</returns>
        /// CreatedBy: TXTrinh (02/02/2021)
        [HttpGet]
        [Route("Search")]
        public IActionResult Search(string EmployeeCode, string PositionId, string DepartmentId)
        {
            var employees = _db.GetData("SELECT * FROM Employee e WHERE(e.EmployeeCode LIKE CONCAT('%',@EmployeeCode, '%') OR e.FullName LIKE CONCAT('%',@FullName, '%') OR e.PhoneNumber LIKE CONCAT('%',@PhoneNumber, '%')) AND((@PositionId IS NOT NULL AND e.PositionId = @PositionId) OR @PositionId IS NULL) AND((@DepartmentId IS NOT NULL AND e.DepartmentId = @DepartmentId) OR @DepartmentId IS NULL);", new { EmployeeCode = EmployeeCode, FullName = EmployeeCode, PhoneNumber = EmployeeCode, PositionId = PositionId, DepartmentId = DepartmentId }, System.Data.CommandType.Text);
            return Ok(new ActionServiceResult()
            {
                Success = true,
                Message = MISA.Common.Properties.Resources.SuccessMsg,
                Data = employees,
                MISACode = EnumCodes.Success,
            });
        }
    }
}
