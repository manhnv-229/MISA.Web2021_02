using Microsoft.AspNetCore.Mvc;
using MISA.ApplicationCore;
using MISA.ApplicationCore.Interface;
using MISA.Common;
using MISA.Common.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MISA.Web.Controllers
{
    [Route("api/v1/employees")]
    public class EmployeesController: BaseController<Employee>
    {
        IEmployeeBL _employeeBL;
        public EmployeesController(IEmployeeBL employeeBL): base(employeeBL)
        {
            _employeeBL = employeeBL;
        }
        ///// <summary>
        /// Lấy toàn bộ dữ liệu nhân viên
        /// </summary>
        /// <returns>list danh sách nhân viên</returns>
        /// CreatedBy: PNVĐ (02/02/2021)
        //[HttpGet]
        //public IActionResult Get()
        //{
        //    var serviceResult = new ServiceResult();
        //    serviceResult = _employeeBL.GetData<Employee>();
        //    var employee = serviceResult.Data as List<Employee>;
            
        //    if(employee.Count() == 0)
        //    {
        //        return StatusCode(204, serviceResult.Data);
        //    }
        //    return StatusCode(200, serviceResult.Data);
        //}
        /// <summary>
        /// Đếm số lượng nhân viên trong database
        /// </summary>
        /// <returns>Số lượng nhân viên</returns>
        /// CreatedBy: PNVĐ (02/02/2021)
        [HttpGet("count")]
        public IActionResult GetCount()
        {
            return Ok(_employeeBL.GetCountData<Employee>());
        }
        /// <summary>
        /// Lấy danh sách viên trong 1 trang
        /// </summary>
        /// <param name="offset">Vị trí bắt đầu lấy</param>
        /// <param name="size">Số lượng cần lấy</param>
        /// <returns>Res tương ứng danh sách nhân viên của 1 page</returns>
        /// CreatedBy: PNVĐ (02/02/2021)
        [HttpGet("page/{offset}&{size}")]
        public IActionResult GetPage(int offset,int size)
        {
            return Ok(_employeeBL.GetDataPage<Employee>(offset,size));
        }

        ///// <summary>
        ///// lấy toàn bộ danh sách phòng ban
        ///// </summary>
        ///// <returns></returns>
        ///// CreatedBy: PNVĐ (02/02/2021)
        //[HttpGet("department")]
        //public IActionResult Get2()
        //{
        //    return Ok(_employeeBL.GetData<EmployeeDepartment>());
        //}
        ///// <summary>
        ///// lấy toàn bộ danh sách các vị trí
        ///// </summary>
        ///// <returns></returns>
        ///// CreatedBy: PNVĐ (02/02/2021)
        //[HttpGet("position")]
        //public IActionResult Get3()
        //{
        //    return Ok(_employeeBL.GetData<EmployeePosition>());
        //}
        /// <summary>
        /// Lấy ra dữ liệu nhân viên có mã nhân viên lớn nhất
        /// </summary>
        /// <returns>Res là 1 {} chưa mã nhân viên max và còn lại là null</returns>
        /// CreatedBy: PNVĐ (02/02/2021)
        [HttpGet("max")]
        public IActionResult Get4()
        {
            return Ok(_employeeBL.GetEmployeeCodeM<Employee>());
        }

        /// <summary>
        /// lấy dữ liệu nhân viên theo id
        /// </summary>
        /// <param name="id">khóa chính của nhân viên</param>
        /// <returns></returns>
        /// CreatedBy: PNVĐ (02/02/2021)
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            return Ok(_employeeBL.GetDataById<Employee>(id.ToString()));
        }
        /// <summary>
        /// Thêm mới nhân viên
        /// </summary>
        /// <param name="employee"></param>
        /// <returns>Trả về số lượng bản ghi thêm mới nếu chính xác</returns>
        /// CreatedBy: PNVĐ (02/02/2021)
        [HttpPost]
        public IActionResult Post(Employee employee)
        {
            var serviceResult = _employeeBL.InsertEmployee(employee);
            if (!serviceResult.Success)
            {
                return StatusCode(400, serviceResult.Data);
            }
            return StatusCode(201, serviceResult.Data);
        }

        /// <summary>
        /// Sửa dữ liệu nhân viên
        /// </summary>
        /// <param name="employee">Thuộc tính nhân viên</param>
        /// <returns>Trả về số bản ghi đã sửa</returns>
        /// CreatedBy: PNVĐ (02/02/2021)
        [HttpPut]
        public IActionResult Put(Employee employee)
        {
            var serviceResult = _employeeBL.UpdateEmployee(employee);
            if (!serviceResult.Success)
            {
                return StatusCode(400, serviceResult.Data);
            }
            return StatusCode(201, serviceResult.Data);
        }

        /// <summary>
        /// Xóa dữ liệu nhân viên theo id
        /// </summary>
        /// <param name="id">Khóa chính của nhân viên</param>
        /// <returns>Trả về số bản ghi đã xóa</returns>
        /// CreatedBy: PNVĐ (02/02/2021)
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            Employee employee = new Employee();
            employee.EmployeeId = Guid.Parse(id);
            var effect = _employeeBL.DeleteEmployee(employee);
            if (effect == -1)
                return StatusCode(400,"Id không tồn tại");
            return Ok(effect);
        }


    }
}
