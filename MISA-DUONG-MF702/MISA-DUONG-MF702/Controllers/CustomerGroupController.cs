using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.Common;
using MISA.Common.Filters;
using MISA.Service.CustomerGroup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static MISA.Common.ResponseExtensions;

namespace MISA_DUONG_MF702.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerGroupController : ControllerBase
    {
        ICustomerGroupService _custormerGroupService;
        public CustomerGroupController(ICustomerGroupService customerGroupService)
        {
            _custormerGroupService = customerGroupService;
        }
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> Get(int pageIndex = 1, int pageSize = 50)
        {
            GlobalParamFilter filters = new GlobalParamFilter
            {
                Status = Constants.Status.Active,
                PageIndex = pageIndex,
                PageSize = pageSize > 0 ? pageSize : int.MaxValue
            };
            var response = new PagedResponse<MISA.Common.Models.CustomerGroup> { Success = true };
            try
            {
                var entities = await _custormerGroupService.GetAll(filters);
                response.Data = entities.ToList();
                response.PageIndex = pageIndex;
                response.PageSize = pageSize;
                response.TotalPages = entities.TotalPages;
                response.TotalCount = entities.TotalCount;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }

            return response.ToHttpResponse();
        }
        [HttpPost]
        [Route("")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> Post([FromBody] MISA.Common.Models.CustomerGroup model)
        {
            var response = new Response() { Success = true };

            try
            {
                if (model == null)
                {
                    response.Success = false;
                    response.Message = "Data not found";
                    return response.ToHttpResponse();
                }
                //check trung ma khach hang
                var customerGroupName = model.CustomerGroupName;
                var sql = $"SELECT CustomerCode FROM Customer WHERE CustomerCode = '{customerGroupName}'";
                var customerDuplicates = await _custormerGroupService.GetData(sql);
                if (customerDuplicates.Count() > 0)
                {
                    response.Success = false;
                    response.Message = "Duplicates Custormer Group Name";
                    return response.ToHttpResponse();
                }
                var result = await _custormerGroupService.Insert(model);

            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }

            return response.ToHttpResponse();
        }
    }
}
