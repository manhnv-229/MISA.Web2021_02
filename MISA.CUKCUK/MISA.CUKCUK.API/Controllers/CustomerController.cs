
using Microsoft.AspNetCore.Mvc;
using System;
using MISA.Common.Model;
using MISA.Service.Interface;

namespace MISA.CUKCUK.API.Controllers
{
    [Route("api/v1/customers")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        /// <summary>
        /// Lấy tất cả khách hàng
        /// </summary>
        /// <returns>Danh sách khách hàng</returns>
        [HttpGet]
        public ServiceResult GetAllCustomer()
        {
            var serviceResult = _customerService.GetAll();
            return serviceResult;
        }

        /// <summary>
        /// Lấy theo Id
        /// </summary>
        /// <param name="id">id cần tìm</param>
        /// <returns>Khách hàng cần tìm</returns>
        [HttpGet("{id}")]
        public ServiceResult GetById([FromRoute] Guid id)
        {
            var serviceResult = _customerService.GetById(id);
            return serviceResult;
        }

        /// <summary>
        /// Thêm mới khách hàng
        /// </summary>
        /// <param name="customer">Thực thể khách hàng cần thêm</param>
        /// <returns>Response tương ứng và số bản ghi được thêm nếu thêm được</returns>
        /// CreatedBy VTThien (07/02/21)
        [HttpPost]
        public IActionResult PostCustomer([FromBody] Customer customer)
        {
            var res = _customerService.InsertCustomer(customer);
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

        /// <summary>
        /// Sửa thông tin khách hàng
        /// </summary>
        /// <param name="id"></param>
        /// <param name="customer"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public IActionResult PutCustomer([FromRoute] Guid id, [FromBody] Customer customer)
        {
            // Gọi đến hàm Insert thực hiện validate -> Sửa
            var res = _customerService.UpdateCustomer( id,  customer);

            if (res.Success == false)
            {
                return StatusCode(400, res.Data);
            }
            else if (res.Success == true && res.Data != null)
            {
                return StatusCode(201, res.Data);
            }
            else
            {
                return StatusCode(200, res.Data);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] Guid id)
        {
            // Gọi đến hàm Insert thực hiện validate -> Sửa
            var res = _customerService.Delete(id);

            if (res.Success == false)
            {
                return StatusCode(400, res.Data);
            }
            else
            {
                return StatusCode(200, res.Data);
            }
        }
    }
}
