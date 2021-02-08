using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using MISA.DataLayer;
using MISA.Common.Models;
using MISA.Services;
using MySql.Data.MySqlClient;

namespace MISA_API_Demo.Controllers
{
    public class CustomersController : BaseEntityController<Customer>
    {
        /// <summary>
        /// Thêm mới khách hàng
        /// </summary>
        /// <param name="customer">Thực thể khách hàng mới</param>
        /// <returns>Response tương ứng cho Client</returns>
        /// CreatedBy: TXTrinh (02/02/2021)
        public override IActionResult Post([FromBody] Customer customer)
        {
            customer.CustomerId = Guid.NewGuid();

            CustomerService customerService = new CustomerService();
            var res = customerService.InsertCustomer(customer);
            switch (res.MISACode)
            {
                case EnumCodes.Created:
                    {
                        res.Message = MISA.Common.Properties.Resources.CreatedSuccess;
                        return StatusCode(201, res);
                    }
                case EnumCodes.BadRequest:
                    return BadRequest(res);
                case EnumCodes.Exception:
                    return StatusCode(500);
                default:
                    return NoContent();
            }
        }
        /// <summary>
        /// Sửa khách hàng
        /// </summary>
        /// <param name="customer">Thực thể khách hàng đã sửa</param>
        /// <returns>Response tương ứng cho Client</returns>
        /// CreatedBy: TXTrinh (02/02/2021)
        public override IActionResult Put([FromBody] Customer customer)
        {
            CustomerService customerService = new CustomerService();
            var res = customerService.UpdateCustomer(customer);
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
    }
}
