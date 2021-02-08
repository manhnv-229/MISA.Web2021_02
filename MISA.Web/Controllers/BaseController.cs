using Microsoft.AspNetCore.Mvc;
using MISA.ApplicationCore.Interface;
using MISA.Common.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MISA.Web.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class BaseController<T> : ControllerBase
    {
        IBaseBL<T> _baseBL;
        public BaseController(IBaseBL<T> baseBL)
        {
            _baseBL = baseBL;
        }
        
        [HttpGet]
        public IActionResult Get()
        {
            var serviceResult = new ServiceResult();
            serviceResult = _baseBL.GetData();
            var entity = serviceResult.Data as List<T>;

            if (entity.Count() == 0)
            {
                return StatusCode(204, serviceResult.Data);
            }
            return StatusCode(200, serviceResult.Data);
        }

    }
}
