using MISA.CukCuk.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MISA.CukCuk.Controllers
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
        public virtual IActionResult Get()
        {
            var res = _baseService.GetEntities();
            return StatusCode(res.StatusCode, res.Data);
        }

        // GET: api/v1/<Controller>/5
        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            var res = _baseService.GetEntity(id);
            return StatusCode(res.StatusCode, res.Data);
        }

        // POST: api/v1/<Controller>
        [HttpPost]
        public IActionResult Post([FromBody] T entity)
        {
            var res = _baseService.InsertEntity(entity);
            return StatusCode(res.StatusCode, res.Data);
        }

        // PUT: api/v1/<Controller>/5
        [HttpPut("{id}")]
        public IActionResult Put(string id, [FromBody] T entity)
        {
            var res = _baseService.UpdateEntity(id, entity);
            return StatusCode(res.StatusCode, res.Data);
        }

        // DELETE: api/v1/<Controller>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            var res = _baseService.DeleteEntity(id);
            return StatusCode(res.StatusCode, res.Data);
        }
        #endregion

    }
}
