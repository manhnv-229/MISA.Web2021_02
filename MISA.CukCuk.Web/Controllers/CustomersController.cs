using Dapper;
using Microsoft.AspNetCore.Mvc;
using MISA.Common.Models;
using MISA.Service;
using MISA.Common.Enum;
using MISA.DataLayer;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using MISA.Service.interfaces;

namespace MISA.CukCuk.Web.Controllers
{
   
   /* public class CustomersController : BaseEntityController<Customer>
    {
        *//*public CustomersController(ICustomerService customerService) : base(customerService)
        {
        }
        public override IActionResult Post([FromBody] Customer entity)
        {  
            var res = _employeeService.InsertEntity(entity);
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


        }*//*


    }*/
}
