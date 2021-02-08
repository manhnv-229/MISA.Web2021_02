using Microsoft.AspNetCore.Mvc;
using MISA.Common.Entities;
using MISA.Common.Enumrations;
using MISA.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.CukCuk.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class BaseController<MISAEnity> : ControllerBase
    {
        IBaseService<MISAEnity> _baseService;
        public BaseController(IBaseService<MISAEnity> baseService)
        {
            _baseService = baseService;
        }

        [HttpGet]
        public IEnumerable<MISAEnity> Get()
        {
            return _baseService.Get();
        }

        [HttpPost]
        public IActionResult Insert(MISAEnity enity)
        {
            var serviceResult = _baseService.Insert(enity);
            return StatusCode(serviceResult.MISACode, serviceResult);
        }

        [HttpPut]
        public IActionResult Update(MISAEnity enity)
        {
            var serviceResult = _baseService.Update(enity);
            return StatusCode(serviceResult.MISACode, serviceResult);

        }

        [HttpDelete]
        public IActionResult Delete(MISAEnity enity)
        {
            var serviceResult = _baseService.Delete(enity);
            return StatusCode(serviceResult.MISACode, serviceResult);
        }
    }
}
