using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.Common.Models;
using MISA.Service;
using MISA.Common.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MISA.Service.interfaces;

namespace MISA.CukCuk.Web.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class EmployeeController : BaseEntityController<Employee>

    {
        public EmployeeController(IEmployeeService employeeService) :base(employeeService)
        {   
        }
        public override IActionResult Post([FromBody] Employee entity)
        {
            // check trung ma khach hang
            try
            {
                var res = _employeeService.InsertEntity<Employee>(entity);
                switch (res.Code)
                {
                    case EnumPattern.BadRequest:
                        return BadRequest(res);

                    case EnumPattern.Success:
                        return Ok(res);

                    case EnumPattern.Exception:
                        return StatusCode(500);
                    default:
                        return NoContent();

                }
            }
            catch (Exception e)
            {
                return StatusCode(500, "Có lỗi xảy ra vui lòng liên hệ công ty để trợ giúp.");
            }



        }
        public override IActionResult Put([FromBody] Employee entity)
        {
            var res = _employeeService.ModifiedEntity<Employee>(entity, entity.EmployeeId.ToString());
            switch (res.Code)
            {
                case EnumPattern.BadRequest:
                    return BadRequest(res);

                case EnumPattern.Success:
                    return Ok(res);

                case EnumPattern.Exception:
                    return StatusCode(500);
                default:
                    return NoContent();

            }
        }
    }
}
