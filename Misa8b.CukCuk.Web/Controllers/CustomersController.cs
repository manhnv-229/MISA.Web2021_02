using Microsoft.AspNetCore.Mvc;
using Misa.CukCuk.Common;
using Misa8b.CukCuk.BL;
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
    public class CustomersController : ControllerBase
    {
        ICustomerBL _customerBL;
        public CustomersController(ICustomerBL customerBL)
        {
            _customerBL = customerBL;
        }
        // GET: api/<CustomersController>
        [HttpGet]
        public IActionResult Get()
        {
            var datas = _customerBL.GetAllData();
            switch (datas.MisaCode)
            {
                case Misa.CukCuk.Common.Enum.Enumarations.MisaCode.Success:
                    return Ok(datas.Data);
                case Misa.CukCuk.Common.Enum.Enumarations.MisaCode.Validate:
                    return BadRequest(datas.Data);
                case Misa.CukCuk.Common.Enum.Enumarations.MisaCode.Error:
                    return BadRequest(datas.Data);
                case Misa.CukCuk.Common.Enum.Enumarations.MisaCode.Exception:
                    return BadRequest(datas.Data);
                default:
                    return NoContent();
            }

        }

        // GET api/<CustomersController>/5
        [HttpGet("id")]
        public IActionResult Get([FromQuery] Guid id)
        {
            var data = _customerBL.GetDataById(id);
            switch (data.MisaCode)
            {
                case Misa.CukCuk.Common.Enum.Enumarations.MisaCode.Success:
                    return Ok(data.Data);
                case Misa.CukCuk.Common.Enum.Enumarations.MisaCode.Validate:
                    return BadRequest(data.Data);
                case Misa.CukCuk.Common.Enum.Enumarations.MisaCode.Error:
                    return BadRequest(data.Data);
                case Misa.CukCuk.Common.Enum.Enumarations.MisaCode.Exception:
                    return BadRequest(data.Data);
                default:
                    return NoContent();
            }
        }
        [HttpGet("search")]
        public IActionResult Get([FromQuery] string CustomerCode = "", [FromQuery] string FullName = "", [FromQuery] string PhoneNumber = "")
        {
            var data = _customerBL.GetDataByOthers(CustomerCode, FullName, PhoneNumber);
            switch (data.MisaCode)
            {
                case Misa.CukCuk.Common.Enum.Enumarations.MisaCode.Success:
                    return Ok(data.Data);
                case Misa.CukCuk.Common.Enum.Enumarations.MisaCode.Validate:
                    return BadRequest(data.Data);
                case Misa.CukCuk.Common.Enum.Enumarations.MisaCode.Error:
                    return BadRequest(data.Data);
                case Misa.CukCuk.Common.Enum.Enumarations.MisaCode.Exception:
                    return BadRequest(data.Data);
                default:
                    return NoContent();
            }
        }

        /// <summary>
        /// thêm mới khách hàng
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post([FromBody] Customer customer)
        {
            var data = _customerBL.InsertData(customer);
            switch (data.MisaCode)
            {
                case Misa.CukCuk.Common.Enum.Enumarations.MisaCode.Success:
                    return Ok(data);
                case Misa.CukCuk.Common.Enum.Enumarations.MisaCode.Validate:
                    return BadRequest(data);
                case Misa.CukCuk.Common.Enum.Enumarations.MisaCode.Error:
                    return BadRequest(data);
                case Misa.CukCuk.Common.Enum.Enumarations.MisaCode.Exception:
                    return BadRequest(data);
                default:
                    return NoContent();
            }
        }
        /// <summary>
        /// sửa dữ liệu khách hàng
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult Put([FromBody] Customer customer)
        {
            var data = _customerBL.UpdateData(customer);
            switch (data.MisaCode)
            {
                case Misa.CukCuk.Common.Enum.Enumarations.MisaCode.Success:
                    return Ok(data);
                case Misa.CukCuk.Common.Enum.Enumarations.MisaCode.Validate:
                    return BadRequest(data);
                case Misa.CukCuk.Common.Enum.Enumarations.MisaCode.Error:
                    return BadRequest(data);
                case Misa.CukCuk.Common.Enum.Enumarations.MisaCode.Exception:
                    return BadRequest(data);
                default:
                    return NoContent();
            }
        }
        /// <summary>
        /// xóa dữ liệu khách hàng
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        public IActionResult Delete(Guid id)
        {
            var data = _customerBL.DeleteCustomer(id);
            switch (data.MisaCode)
            {
                case Misa.CukCuk.Common.Enum.Enumarations.MisaCode.Success:
                    return Ok(data);
                case Misa.CukCuk.Common.Enum.Enumarations.MisaCode.Validate:
                    return BadRequest(data);
                case Misa.CukCuk.Common.Enum.Enumarations.MisaCode.Error:
                    return BadRequest(data);
                case Misa.CukCuk.Common.Enum.Enumarations.MisaCode.Exception:
                    return BadRequest(data);
                default:
                    return NoContent();
            }

        }
    }
}
