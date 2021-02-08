using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.ApplicationCore.Entity;
using MISA.ApplicationCore.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.Hieu.CukCuk.Web.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        IDepartmentService _departmentService;
        #region Constructor
        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }
        #endregion

        #region Method
        /// <summary>
        /// Lấy danh sách vị trí
        /// </summary>
        /// <returns>Danh sách vị trí</returns>
        /// CreatedBy: BDHIEU (01/02/2021)
        [HttpGet]
        public IActionResult Get()
        {
            var serviceResult = _departmentService.GetDepartments();
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
        /// Lấy thông tin vị trí theo id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Thông tin vị trí theo id</returns>
        /// CreatedBy: BDHIEU (01/02/2021)
        [HttpGet("{id}")]
        public string GetDepartmentById(int id)
        {
            return _departmentService.GetDepartmentById(id);
        }
        #endregion
    }
}
