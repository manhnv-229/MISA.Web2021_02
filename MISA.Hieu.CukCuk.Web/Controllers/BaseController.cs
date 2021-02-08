using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.ApplicationCore.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.Hieu.CukCuk.Web.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class BaseController<T> : ControllerBase
    {
        IBaseService _baseService;

        public BaseController(IBaseService baseService)
        {
            _baseService = baseService;
        }

        public BaseController()
        {
        }

        [HttpGet]
        public IActionResult Get()
        {
            var serviceResult = _baseService.GetData<T>();
            if (serviceResult.Data != null)
            {
                return StatusCode(204, serviceResult.Data);
            }
            else
            {
                return StatusCode(200, serviceResult.Data);
            }
        }
    }
}
