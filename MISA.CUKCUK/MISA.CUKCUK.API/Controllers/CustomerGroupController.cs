
using Microsoft.AspNetCore.Mvc;
using System;
using MISA.Common.Model;
using MISA.Service.Interface;

namespace MISA.CUKCUK.API.Controllers
{
    [Route("api/v1/customer-group")]
    [ApiController]
    public class CustomerGroup : ControllerBase
    {
        private readonly ICustomerGroupService _customerGroupService;

        public CustomerGroup(ICustomerGroupService customerGroupService)
        {
            _customerGroupService = customerGroupService;
        }


        /// <summary>
        /// Lấy Nhóm khách hàng
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ServiceResult GetCustomerGroup()
        {
            var serviceResult = _customerGroupService.GetAll();
            return serviceResult;
        }
        
        /// <summary>
        /// Lấy nhóm khách hàng theo Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public ServiceResult GetByID([FromRoute] Guid id)
        {
            var serviceResult = _customerGroupService.GetById(id);
            return serviceResult;
        }

        //[HttpPost]
        //public IActionResult PostCustomerGroup([FromBody] CustomerGroup customerGroup)
        //{
        //    var res = _customerGroupService.InsertCustomerGroup(customerGroup);
        //    if (res.Success == false)
        //    {
        //        return StatusCode(400, res.Data);
        //    }
        //    else if (res.Success == true && (int)res.Data > 0)
        //    {
        //        return StatusCode(201, res.Data);
        //    }
        //    else
        //    {
        //        return StatusCode(200, res.Data);
        //    }
        //}
    }
}
