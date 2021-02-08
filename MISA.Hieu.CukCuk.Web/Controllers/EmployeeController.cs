using Microsoft.AspNetCore.Mvc;
using MISA.ApplicationCore;
using MISA.ApplicationCore.Entity;
using MISA.ApplicationCore.interfaces;
using MISA.ApplicationCore.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MISA.Hieu.CukCuk.Web.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        #region DECLARE
        IEmployeeService _employeeService;
        IBaseService _baseService;
        #endregion

        #region Constructor
        public EmployeeController(IEmployeeService employeeService, IBaseService baseService)
        {
            _employeeService = employeeService;
            _baseService = baseService;
        }
        #endregion

        #region Method
        // GET: api/<EmployeeController>
        /// <summary>
        /// Lấy danh sách nhân viên
        /// </summary>
        /// <returns>Danh sách nhân viên</returns>
        /// CreatedBy: BDHIEU (01/02/2021)
        [HttpGet]
        public IActionResult Get()
        {
            var serviceResult = _baseService.GetData<Employee>();
            if (serviceResult.Data != null)
            {
                return StatusCode(204, serviceResult.Data);
            }
            else
            {
                return StatusCode(200, serviceResult.Data);
            }
        }

        /// <summary>
        /// Lấy nhân viên theo id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Thông tin nhân viên theo id</returns>
        /// CreatedBy: BDHIEU (01/02/2021)
        [HttpGet("{id}")]
        public Employee GetById(Guid id)
        {
            var employee = _employeeService.GetEmployeeById(id);
            return employee;
        }

        /// <summary>
        /// Lấy mã nhân viên lớn nhất
        /// </summary>
        /// <returns>Mã nhân viên lớn nhất</returns>
        /// CreatedBy: BDHIEU (01/02/2021)
        [HttpGet("/max-employee-code")]
        public string GetMaxEmployeeCode()
        {
            var maxEmployeeCode = _employeeService.GetMaxEmployeeCode();
            return maxEmployeeCode;
        }

        /// <summary>
        /// Lấy danh sách nhân viên nối với bảng vị trí và phòng ban
        /// </summary>
        /// <returns>Danh sách nhân viên nối với bảng vị trí và phòng ban</returns>
        /// CreatedBy: BDHIEU (01/02/2021)
        [HttpGet("/employee-info")]
        public IActionResult GetEmployeeInfos()
        {
            var serviceResult = _baseService.GetData<EmployeeInfo>();
            if (serviceResult.Data != null)
            {
                return StatusCode(204, serviceResult.Data);
            }
            else
            {
                return StatusCode(200, serviceResult.Data);
            }
        }

        /// <summary>
        /// Lấy số lượng nhân viên
        /// </summary>
        /// <returns>Số lượng nhân viên</returns>
        /// CreatedBy: BDHIEU (01/02/2021)
        [HttpGet("/number-employee")]
        public int GetNumberOfEmployee()
        {
            var numberOfEmployee = _employeeService.GetNumberOfEmployee();
            return numberOfEmployee;
        }

        /// <summary>
        /// Lấy danh sách nhân viên theo vị trí công việc
        /// </summary>
        /// <param name="PositionId"></param>
        /// <returns>Danh sách nhân viên theo vị trí công việc</returns>
        /// CreatedBy: BDHIEU (01/02/2021)
        [HttpGet("/Position/{PositionId}")]
        public IActionResult GetEmployeeByPosition(int PositionId)
        {
            return Ok(_employeeService.GetEmployeeByPosition(PositionId));
        }

        /// <summary>
        /// Lấy danh sách nhân viên theo phòng ban
        /// </summary>
        /// <param name="DepartmentId"></param>
        /// <returns>Danh sách nhân viên theo phòng ban</returns>
        /// CreatedBy: BDHIEU (01/02/2021)
        [HttpGet("/Department/{DepartmentId}")]
        public IActionResult GetEmployeeByDepartment(int DepartmentId)
        {
            return Ok(_employeeService.GetEmployeeByDepartment(DepartmentId));
        }

        /// <summary>
        /// Lấy danh sách nhân viên theo từ khóa tìm kiếm
        /// </summary>
        /// <param name="search"></param>
        /// <returns>Danh sách nhân viên theo từ khóa tìm kiếm</returns>
        /// CreatedBy: BDHIEU (04/02/2021)
        [HttpGet("/api/v1/Search")]
        public IActionResult GetEmployeeBySearchText([FromQuery] string search)
        {
            return Ok(_employeeService.GetEmployeeBySearchText(search));
        }

        [HttpGet("/api/v1/Employee/Paging")]
        public IActionResult GetEmployeeByIndexAndOffset([FromQuery] int positionStart, [FromQuery] int offset)
        {
            return Ok(_employeeService.GetEmployeeByIndexAndOffset(positionStart, offset));
        }

        /// <summary>
        /// Thêm mới nhân viên
        /// </summary>
        /// <param name="employee"></param>
        /// CreatedBy: BDHIEU (01/02/2021)
        [HttpPost]
        public IActionResult Post(Employee employee)
        {
            var serviceResult = _employeeService.AddEmployee(employee);
            if (serviceResult.Success == false)
            {
                return StatusCode(400, serviceResult);
            }
            if (serviceResult.Success == true)
            {
                return StatusCode(201, serviceResult);
            }
            else
            {
                return StatusCode(401, "Error");
            }
        }

        /// <summary>
        /// Cập nhật thông tin nhân viên
        /// </summary>
        /// <param name="employee"></param>
        /// CreatedBy: BDHIEU (01/02/2021)
        [HttpPut]
        public void Put(Employee employee)
        {
            _employeeService.UpdateEmployee(employee);
        }

        /// <summary>
        /// Xóa nhân viên
        /// </summary>
        /// <param name="id"></param>
        /// CreatedBy: BDHIEU (01/02/2021)
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            _employeeService.DeleteEmployee(id);
        }
        #endregion
    }
}
