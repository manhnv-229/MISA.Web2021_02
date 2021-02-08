using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.BTL.Business;
using MISA.BTL.Business.Interfaces;

namespace MISA.BTL.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class BaseController<T> : ControllerBase
    {
        IBaseBusiness<T> _baseBusiness;
        public BaseController(IBaseBusiness<T> baseBusiness)
        {
            _baseBusiness = baseBusiness;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var res = _baseBusiness.GetData();
            var customers = res.Data as List<T>;
            if (customers.Count == 0)
            {
                return StatusCode(204, res.Data);
            }
            else
            {
                return StatusCode(200, res.Data);
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] T entity)
        {
            var res = _baseBusiness.Insert(entity);
            switch (res.Success)
            {
                case false:
                    return StatusCode(400, res.Data);
                case true:
                    return StatusCode(201, res.Data);
            }
        }

        [HttpPut]
        public IActionResult Put([FromBody] T entity)
        {
            var res = _baseBusiness.Update(entity);
            switch (res.Success)
            {
                case false:
                    return StatusCode(400, res.Data);
                case true:
                    return StatusCode(201, res.Data);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            var res = _baseBusiness.Delete(id);
            switch (res.Success)
            {
                case false:
                    return StatusCode(400, res.Data);
                case true:
                    return StatusCode(200, res.Data);
            }
        }
    }
}
