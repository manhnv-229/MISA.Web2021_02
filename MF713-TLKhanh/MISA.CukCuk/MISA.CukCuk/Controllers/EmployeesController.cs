using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.CukCuk.Core.Entities;
using MISA.CukCuk.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.CukCuk.Controllers
{
 
    public class EmployeesController : BaseController<Employee>
    {
        #region Declare
        IEmployeeService _employeeService;
        #endregion
        #region Constructor
        /// <summary>
        /// Hàm khởi tạo
        /// </summary>
        /// <param name="employeeService"></param>
        /// CreatedBy TLKhanh (19/2/2021)
        public EmployeesController(IEmployeeService employeeService) : base(employeeService)
        {
            _employeeService = employeeService;
        }
        #endregion

        #region Method
        public override IActionResult Get()
        {
            var res = _employeeService.GetEmployees();
            return StatusCode(res.StatusCode, res.Data);
        }
        /// <summary>
        /// Lấy giá trị lớn nhất của code
        /// </summary>
        /// <returns></returns>
        /// CreatedBy: TLKhanh (19/2/2021)
        [HttpGet("max-code")]
        public IActionResult GetMaxCode()
        {
            var res = _employeeService.GetMaxCode();
            return Ok(res.Data);
        }
        /// <summary>
        /// Lấy dữ liệu theo tình trạng công việc (Demo)
        /// </summary>
        /// <param name="workStatus">id trạng thái công việc</param>
        /// <returns>Danh sách nhân viên có trạng thái công việc truyền vào</returns>
        /// CreatedBy: TLKhanh(19/2/2021)
        [HttpGet("filter")]
        public IActionResult GetByWorkStatus([FromQuery] string workStatus)
        {
            var res = _employeeService.GetByWorkStatus(workStatus);
            return Ok(res.Data);
        }
        #endregion
    }
}
