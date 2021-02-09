using Microsoft.AspNetCore.Mvc;
using Misa.CukCuk.Common;
using Misa8b.CukCuk.BL.Interfaces;
using Misa8b.CukCuk.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Misa8b.CukCuk.Web.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        IEmployeeBL _employeeBL;
        /// <summary>
        /// khởi tạo kết nối với kiểm tra nghiệp vụ
        /// </summary>
        /// <param name="employeeBL"></param>
        public EmployeesController(IEmployeeBL employeeBL)
        {
            _employeeBL = employeeBL;
        }
        /// <summary>
        /// lấy toàn bộ dữ liệu
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get()
        {
            var datas = _employeeBL.GetAllData();
            switch (datas.MisaCode)
            {
                case Misa.CukCuk.Common.Enum.Enumarations.MisaCode.Success:
                    return Ok(datas);
                case Misa.CukCuk.Common.Enum.Enumarations.MisaCode.Validate:
                    return Ok(datas);
                case Misa.CukCuk.Common.Enum.Enumarations.MisaCode.Error:
                    return Ok(datas);
                case Misa.CukCuk.Common.Enum.Enumarations.MisaCode.Exception:
                    return Ok(datas);
                default:
                    return NoContent();
            }

        }
        /// <summary>
        /// lấy dữ liệu với pagging
        /// </summary>
        /// <param name="limit"></param>
        /// <param name="ofset"></param>
        /// <returns>danh sach nhân viên</returns>
        [HttpGet("Pagging")]
        public IActionResult GetWithPagging(int limit, int ofset)
        {
            var datas = _employeeBL.GetAllDataPagging(limit, ofset);
            switch (datas.MisaCode)
            {
                case Misa.CukCuk.Common.Enum.Enumarations.MisaCode.Success:
                    return Ok(datas);
                case Misa.CukCuk.Common.Enum.Enumarations.MisaCode.Validate:
                    return Ok(datas);
                case Misa.CukCuk.Common.Enum.Enumarations.MisaCode.Error:
                    return Ok(datas);
                case Misa.CukCuk.Common.Enum.Enumarations.MisaCode.Exception:
                    return Ok(datas);
                default:
                    return NoContent();
            }

        }
        /// <summary>
        /// lấy nhân viên bằng id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("id")]
        public IActionResult Get([FromQuery] Guid id)
        {
            var data = _employeeBL.GetDataById(id);
            switch (data.MisaCode)
            {
                case Misa.CukCuk.Common.Enum.Enumarations.MisaCode.Success:
                    return Ok(data);
                case Misa.CukCuk.Common.Enum.Enumarations.MisaCode.Validate:
                    return Ok(data);
                case Misa.CukCuk.Common.Enum.Enumarations.MisaCode.Error:
                    return Ok(data);
                case Misa.CukCuk.Common.Enum.Enumarations.MisaCode.Exception:
                    return Ok(data);
                default:
                    return NoContent();
            }
        }
        /// <summary>
        /// lấy nhân viên bằng tìm kiếm mã code, tên và số điện thoại
        /// </summary>
        /// <param name="EmployeeCode"></param>
        /// <param name="FullName"></param>
        /// <param name="PhoneNumber"></param>
        /// <returns></returns>
        [HttpGet("search")]
        public IActionResult Get([FromQuery] string EmployeeCode = "", [FromQuery] string FullName = "", [FromQuery] string PhoneNumber = "")
        {
            var data = _employeeBL.GetDataByOthers(EmployeeCode, FullName, PhoneNumber);
            switch (data.MisaCode)
            {
                case Misa.CukCuk.Common.Enum.Enumarations.MisaCode.Success:
                    return Ok(data);
                case Misa.CukCuk.Common.Enum.Enumarations.MisaCode.Validate:
                    return Ok(data);
                case Misa.CukCuk.Common.Enum.Enumarations.MisaCode.Error:
                    return Ok(data);
                case Misa.CukCuk.Common.Enum.Enumarations.MisaCode.Exception:
                    return Ok(data);
                default:
                    return NoContent();
            }
        }
        /// <summary>
        /// lấy nhân viên với vị trí
        /// </summary>
        /// <param name="dep"></param>
        /// <param name="posi"></param>
        /// <returns>danh sách</returns>
        [HttpGet("dp")]
        public IActionResult GetDepAndPosi([FromQuery]string dep = "", [FromQuery]string posi ="")
        {
            var data = _employeeBL.GetDataByDepAndPosi(dep, posi);
            switch (data.MisaCode)
            {
                case Misa.CukCuk.Common.Enum.Enumarations.MisaCode.Success:
                    return Ok(data);
                case Misa.CukCuk.Common.Enum.Enumarations.MisaCode.Validate:
                    return Ok(data);
                case Misa.CukCuk.Common.Enum.Enumarations.MisaCode.Error:
                    return Ok(data);
                case Misa.CukCuk.Common.Enum.Enumarations.MisaCode.Exception:
                    return Ok(data);
                default:
                    return NoContent();
            }
        }
        /// <summary>
        /// lấy nhân viên với phòng ban
        /// </summary>
        /// <param name="dep"></param>
        /// <returns></returns>
        [HttpGet("dep")]
        public IActionResult GetDep([FromQuery] string dep = "")
        {
            var data = _employeeBL.GetDataByDep(dep);
            switch (data.MisaCode)
            {
                case Misa.CukCuk.Common.Enum.Enumarations.MisaCode.Success:
                    return Ok(data);
                case Misa.CukCuk.Common.Enum.Enumarations.MisaCode.Validate:
                    return Ok(data);
                case Misa.CukCuk.Common.Enum.Enumarations.MisaCode.Error:
                    return Ok(data);
                case Misa.CukCuk.Common.Enum.Enumarations.MisaCode.Exception:
                    return Ok(data);
                default:
                    return NoContent();
            }
        }
        /// <summary>
        /// lấy nhân viên với vị trí
        /// </summary>
        /// <param name="posi"></param>
        /// <returns></returns>
        [HttpGet("posi")]
        public IActionResult GetPosi([FromQuery] string posi = "")
        {
            var data = _employeeBL.GetDataByPosi(posi);
            switch (data.MisaCode)
            {
                case Misa.CukCuk.Common.Enum.Enumarations.MisaCode.Success:
                    return Ok(data);
                case Misa.CukCuk.Common.Enum.Enumarations.MisaCode.Validate:
                    return Ok(data);
                case Misa.CukCuk.Common.Enum.Enumarations.MisaCode.Error:
                    return Ok(data);
                case Misa.CukCuk.Common.Enum.Enumarations.MisaCode.Exception:
                    return Ok(data);
                default:
                    return NoContent();
            }
        }
        /// <summary>
        /// thêm mới nhân viên
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post([FromBody] Employee employee)
        {
            var data = _employeeBL.InsertData(employee);
            switch (data.MisaCode)
            {
                case Misa.CukCuk.Common.Enum.Enumarations.MisaCode.Success:
                    return Ok(data);
                case Misa.CukCuk.Common.Enum.Enumarations.MisaCode.Validate:
                    return Ok(data);
                case Misa.CukCuk.Common.Enum.Enumarations.MisaCode.Error:
                    return Ok(data);
                case Misa.CukCuk.Common.Enum.Enumarations.MisaCode.Exception:
                    return Ok(data);
                default:
                    return NoContent();
            }
        }
        /// <summary>
        /// sửa nhân viên
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult Put([FromBody] Employee employee)
        {
            var data = _employeeBL.UpdateData(employee);
            switch (data.MisaCode)
            {
                case Misa.CukCuk.Common.Enum.Enumarations.MisaCode.Success:
                    return Ok(data);
                case Misa.CukCuk.Common.Enum.Enumarations.MisaCode.Validate:
                    return  Ok(data);
                case Misa.CukCuk.Common.Enum.Enumarations.MisaCode.Error:
                    return Ok(data);
                case Misa.CukCuk.Common.Enum.Enumarations.MisaCode.Exception:
                    return Ok(data);
                default:
                    return NoContent();
            }
        }
        /// <summary>
        /// xóa nhân viên
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        public IActionResult Delete(Guid id)
        {
            var data = _employeeBL.DeleteEmployee(id);
            switch (data.MisaCode)
            {
                case Misa.CukCuk.Common.Enum.Enumarations.MisaCode.Success:
                    return Ok(data);
                case Misa.CukCuk.Common.Enum.Enumarations.MisaCode.Validate:
                    return Ok(data);
                case Misa.CukCuk.Common.Enum.Enumarations.MisaCode.Error:
                    return Ok(data);
                case Misa.CukCuk.Common.Enum.Enumarations.MisaCode.Exception:
                    return Ok(data);
                default:
                    return NoContent();
            }

        }
    }
}
