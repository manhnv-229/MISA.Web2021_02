using Microsoft.AspNetCore.Mvc;
using MISA.Common;
using MISA.CukCuk.Web.Models;
using MISA.Service;
using MISA.Service.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MISA.CukCuk.Web.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class BaseEntityController<T> : ControllerBase
    {
        #region Declare
        protected IEmployeeService _employeeService;
        #endregion
        #region Constructor
        public BaseEntityController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        #endregion
        #region Method
        /// <summary>
        /// Lấy danh sách các đối tượng
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get()
        {
      
            return Ok(_employeeService.GetAllData<T>());
        }
        /// <summary>
        /// Lấy danh sách các đối tượng theo Page
        /// </summary>
        /// <param name="PageNumber">Vị trí trang</param>
        /// <param name="Limit">Số lượng giới hạn</param>
        /// <returns>trả về danh sách đối tượng theo trang</returns>
        /// Created by PN Thuận : 1/1/2021
        [HttpGet("paging")]
        public IActionResult GetEmployeePaging([FromQuery] int pageNumber = 1, [FromQuery] int limit = 50)
        {
            return Ok(_employeeService.GetAllData<T>(pageNumber,limit).Data);
        }
        /// <summary>
        /// Lấy mã đối tượng lớn nhất
        /// </summary>
        /// <returns>Trả về mã đối tượng lớn nhất</returns>
        /// Created by PN Thuận : 1/1/2021
        [HttpGet("maxcode")]
        public IActionResult GetMaxCode()
        {
            return Ok(_employeeService.GetMaxCode<T>());
        }

        /// <summary>
        /// Lấy danh sách đối tượng dựa vào vị trí/chức vụ
        /// </summary>
        /// <param name="position">Tên vị trí/ chức vụ</param>
        /// <returns>Trả về danh sách đối tượng theo vị trí/ chức vụ</returns>
        /// Created by PN Thuận : 1/1/2021
        [HttpGet("employees/position")]
        public IActionResult GetAllEmployeeByPosition([FromQuery]string positionName)
        {

            return Ok(_employeeService.GetAllEmployeeByPosition<T>(positionName));
        }
        /// <summary>
        /// Lấy danh sahs đối tượng theo phòng ban
        /// </summary>
        /// <param name="department">Tên phòng ban</param>
        /// <returns>Trả về danh sách đối tượng theo phòng ban</returns>
        /// Created by PN Thuận : 1/1/2021
        [HttpGet("employees/department")]
        public IActionResult GetAllEmployeeByDepartmentPosition([FromQuery]string departmentName)
        {

            return Ok(_employeeService.GetAllEmployeeByDepartment<T>(departmentName));
        }
        /// <summary>
        /// Search danh sách đối tượng theo keyword
        /// </summary>
        /// <param name="SearchText">Keyword : Mã / Tên / Số điện thoại</param>
        /// <returns>Trả về danh sách theo yêu cầu tìm kiếm </returns>
        /// Created by PN Thuận : 1/1/2021
        [HttpGet("filter")]
        public IActionResult SearchOther([FromQuery] string searchText, [FromQuery] Guid? departmentId, [FromQuery] Guid? positionId)
        {

            return Ok(_employeeService.SearchOther<T>(searchText, departmentId, positionId));
        }
        /// <summary>
        /// Trả về danh sách đối tượng theo phòng ban và vị trí/ chức vụ
        /// </summary>
        /// <param name="PositionSearch">Tên vị trí/ chức vụ</param>
        /// <param name="DepartmentSearch">Tên phòng ban</param>
        /// <returns>Trả về danh sách đối tượng theo phòng ban và vị trí</returns>
        /// Created by PN Thuận : 1/1/2021
        [HttpGet("filters")]
        public IActionResult SearchOther([FromQuery]string postionName = " ",[FromQuery] string departmentName = " ")
        {
            return Ok(_employeeService.SearchOther<T>(postionName, departmentName));
            
        }
        /// <summary>
        /// Trả về đối tượng theo Id
        /// </summary>
        /// <param name="id">Id đói tượng truyền vào</param>
        /// <returns>Trả về đói tượng theo Id</returns>
        /// Created by PN Thuận : 1/1/2021
        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {

            return Ok(_employeeService.GetEntityById<T>(id));
        }

        /// <summary>
        /// Thêm mới dữ liệu
        /// </summary>
        /// <param name="entity">đối tượng cần thêm</param>
        /// <returns></returns>
        /// Created by PN Thuận : 1/1/2021
        [HttpPost]
        public virtual IActionResult Post([FromBody] T entity)
        {


          /*  var effectRows = _entityService.InsertEntity<T>(entity);
            if (effectRows == -1)
            {
                return BadRequest("Ma bi trung");
            }
            else
            {*/
                return Ok(0);
         /*   }*/


        }
        /// <summary>
        /// Sửa thông tin đối tượng
        /// </summary>
        /// <param name="entity">Đối tượng cần sửa</param>
        /// <returns>Trả về đối tượng đã sửa</returns>
        /// Created by PN Thuận : 1/1/2021
        [HttpPut]
        public virtual IActionResult Put([FromBody] T entity)
        {
            /* var effectRows = _entityService.ModifiedEntity<T>(entity);
             if (effectRows == -1)
             {
                 return BadRequest("Mã bị trùng");
             }
             else
             {
                 return Ok(effectRows);
             }*/
            return Ok(0);

        }
        /// <summary>
        /// xóa đối tượng theo yêu cầu
        /// </summary>
        /// <param name="id">Id đối tượng cần xóa</param>
        /// <returns></returns>
        /// Created by PN Thuận : 1/1/2021
        [HttpDelete("{id}")]
        public IActionResult DeleteById(string id)
        {

            return Ok(_employeeService.DeleteEntityById<T>(id));
        }
        #endregion
    }


}
