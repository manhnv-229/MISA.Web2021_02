
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
        
        [HttpGet("{id}")]
        public ServiceResult GetByID([FromRoute] Guid id)
        {
            var serviceResult = _customerGroupService.GetById(id);
            return serviceResult;
        }
    }
}
