using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FresherProject.Service;
using FresherProject.Common.Enum;
using FresherProject.Service.Interfaces;

namespace FresherProject.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class BaseEntitiesController<T> : ControllerBase
    {
        IBaseService<T> _baseService;

        public BaseEntitiesController(IBaseService<T> baseService)
        {
            _baseService = baseService;
        }
        // GET: api/<TsController>
        /// <summary>
        /// API thực hiện lấy ds T
        /// </summary>
        /// <returns>List T</returns>
        /// createdBy NgocPham
        [HttpGet]
        public virtual IActionResult Get()
        {
            return Ok(_baseService.GetAllData());
        }
        //[HttpGet("filter")]
        //public IActionResult Get([FromQuery] string filter)
        //{
        //    return Ok(_dBConnector.GetByFilter<T>(filter));
        //}
        // GET api/<TsController>/5
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            return Ok(_baseService.GetById(id));
        }

        // POST api/<TsController>
        [HttpPost]
        public virtual IActionResult Insert([FromBody] T entity)
        {
            //return Ok(_baseService.Insert(entity));
            // Validate tại Service
            var res = _baseService.Insert(entity);
            //Trả về kết quả
            switch (res.MISACukCukCode)
            {
                case MISACukCukServiceCode.Success:
                    return Ok(res);
                case MISACukCukServiceCode.BadRequest:
                    return BadRequest(res);
                case MISACukCukServiceCode.Exception:
                    return StatusCode(500);
                default:
                    return Ok();
            }
        }
        // PUT api/<TsController>/5
        [HttpPut]
        public IActionResult Put([FromBody] T entity)
        {
            return Ok(_baseService.Update(entity));
        }
        // DELETE api/<TsController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            return Ok(_baseService.Delete(id));
        }
    }
}
