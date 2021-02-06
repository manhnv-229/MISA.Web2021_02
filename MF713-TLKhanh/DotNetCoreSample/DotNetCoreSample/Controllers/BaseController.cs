using AplicationCore.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DotNetCoreSample.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class BaseController<T> : ControllerBase
    {
        #region Declare
        IBaseService<T> _baseService;
        #endregion

        #region Method
        // GET: api/v1/<Controller>
        public BaseController(IBaseService<T> baseService)
        {
            _baseService = baseService;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var res = _baseService.GetEntities();
            if (res.Success == true)
                return StatusCode(200, res.Data);
            return NoContent();
        }

        // GET: api/v1/<Controller>/5
        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            var res = _baseService.GetEntity(id);
            if (res.Success == true)
                return StatusCode(200, res.Data);
            return NoContent();
        }

        // POST: api/v1/<Controller>
        [HttpPost]
        public IActionResult Post([FromBody] T entity)
        {
            var res = _baseService.InsertEntity(entity);
            if (res.Success == true)
                return StatusCode(201, res.Data);
            return StatusCode(400, res.Data);
        }

        // PUT: api/v1/<Controller>/5
        [HttpPut("{id}")]
        public IActionResult Put(string id, [FromBody] T entity)
        {
            var res = _baseService.UpdateEntity(id, entity);
            if (res.Success == true)
                return StatusCode(200, res.Data);
            return StatusCode(400, res.Data);
        }

        // DELETE: api/v1/<Controller>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            var res = _baseService.DeleteEntity(id);
            if (res.Success == true)
                return StatusCode(200, res.Data);
            return StatusCode(400, res.Data);
        }
        #endregion

    }
}
