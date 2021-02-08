using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.Common;
using MISA.Common.Filters;
using MISA.Service.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static MISA.Common.ResponseExtensions;

namespace MISA_DUONG_MF702.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustormerController : ControllerBase
    {
        ICustomerService _custormerService;
        public CustormerController(ICustomerService customerService)
        {
            _custormerService = customerService;
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
            var response = new PagedResponse<MISA.Common.Models.Customer> { Success = true };
            try
            {
                var entities = await _custormerService.GetAll(filters);
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
        public async Task<IActionResult> Post([FromBody] MISA.Common.Models.Customer model)
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
                var customerCode = model.CustomerCode;
                var sql = $"SELECT CustomerCode FROM Customer WHERE CustomerCode = '{customerCode}'";
                var customerDuplicates =await _custormerService.GetData(sql);
                if (customerDuplicates.Count() > 0)
                {
                    response.Success = false;
                    response.Message = "Duplicates Custormer code";
                    return response.ToHttpResponse();
                }
                var result=await  _custormerService.Insert(model);
                
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
