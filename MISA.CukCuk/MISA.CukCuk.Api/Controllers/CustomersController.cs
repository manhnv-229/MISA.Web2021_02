using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
using Dapper;
using MISA.Common.Model; 
using System.Linq;
using System.Threading.Tasks;
using MISA.Service;

namespace MISA.CukCuk.Api.Controllers
{
    [Route("api/v1/customers")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        /// <summary>
        /// Lấy danh sách khách hàng 
        /// </summary>
        /// <returns>Danh sách khách hàng</returns>
        /// CreatedBy: Đào Đức Thao (01/02/2021)
        [HttpGet]
        public IActionResult GetCustomers()
        {
            CustomerService customerService = new CustomerService();
            var serviceResult = customerService.GetCustomers();
            var customers = serviceResult.Data as List<Customer>;
            if (customers.Count == 0)
                return StatusCode(204, serviceResult.Data);
            else
                return StatusCode(200, serviceResult.Data);
        }

        /// <summary>
        /// Thêm mới khách hàng
        /// </summary>
        /// <param name="customer">Thực thể khách hàng</param>
        /// <returns>Response tương ứng cho Client (201 - thêm thành công)</returns>
        /// CreatedBy: Đào Đức Thao (01/02/2021)
        [HttpPost]
        public IActionResult PostCustomer(Customer customer)
        {
            try
            {
                CustomerService customerService = new CustomerService();
                var res = customerService.InsertCustomer(customer);
                if (res.Success == false)
                {
                    return StatusCode(400, res.Data);
                }
                else if (res.Success == true && (int)res.Data > 0)
                {
                    return StatusCode(201, res.Data);
                }
                else
                {
                    return StatusCode(200, res.Data);
                }
            }
            catch (Exception e)
            {
                // Ghi log (ELKLock)
                return StatusCode(500, "Có lỗi xảy ra vui lòng liên hệ MISA để được trợ giúp");
            }
           
        }
    }
}
