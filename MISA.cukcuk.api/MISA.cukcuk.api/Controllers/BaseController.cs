using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.Common.Model;
using MISA.Service;
using MISA.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.cukcuk.api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class BaseController<MISAEntity> : ControllerBase
    {
        IBaseService<MISAEntity> _baseService;
        public BaseController(IBaseService<MISAEntity> baseService)
        {
            _baseService = baseService; 
        }
        [HttpGet]
        public IActionResult Get()
        {
            var serviceResult = _baseService.GetData();
            var entities = serviceResult.Data as List<MISAEntity>;
            if (entities.Count == 0)
            {
                return StatusCode(204, serviceResult.Data);
            }
            else
            {
                return StatusCode(200, serviceResult.Data);
            }
        }
        [HttpPost]
        public IActionResult Post(MISAEntity entity)
        {
            var res = _baseService.Insert(entity);
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
    }
}
