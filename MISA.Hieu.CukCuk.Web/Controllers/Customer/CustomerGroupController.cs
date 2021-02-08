using Microsoft.AspNetCore.Mvc;
using MISA.ApplicationCore;
using MISA.ApplicationCore.Entity;
using MISA.ApplicationCore.interfaces;
using MISA.ApplicationCore.interfaces.Customer;
using MISA.ApplicationCore.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MISA.Hieu.CukCuk.Web.Controllers.Customer
{
    //[Route("api/v1/[controller]")]
    public class CustomerGroupController : BaseController<CustomerGroup>
    {
        #region DECLARE
        ICustomerGroupService _customerGroupService;
        IBaseService _baseService;
        #endregion

        #region CONSTRUCTOR
        public CustomerGroupController(ICustomerGroupService customerGroupService, IBaseService baseService)
        {
            _customerGroupService = customerGroupService;
            _baseService = baseService;
        }
        #endregion

        #region METHOD
        // GET: api/<CustomerGroupController>
        /// <summary>
        /// Lấy danh sách nhóm khách hàng
        /// </summary>
        /// <returns>Danh sách nhóm khách hàng</returns>
        /// CreatedBy: BDHIEU (07/02/2021)
        /*[HttpGet]
        public IActionResult Get()
        {
            var serviceResult = _baseService.GetData<CustomerGroup>();
            if (serviceResult.Data != null)
            {
                return StatusCode(204, serviceResult.Data);
            }
            else
            {
                return StatusCode(200, serviceResult.Data);
            }
        }*/

        // POST api/<CustomerGroupController>
        [HttpPost]
        public IActionResult InsertCustomerGroup(CustomerGroup customerGroup)
        {
            var msg = _customerGroupService.InsertCustomerGroup(customerGroup);
            if (msg.success == false)
            {
                return StatusCode(400, msg);
            }
            if (msg.success == true)
            {
                return StatusCode(201, msg);
            }
            else
            {
                return StatusCode(401, "Error");
            }
        }
        #endregion
    }
}
