using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Misa.Bussiness.Interfaces;
using System.Threading.Tasks;

namespace Misa.NETCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController<T> : ControllerBase
    {
        private IBaseBussiness<T> _baseBussiness;

        public BaseController(IBaseBussiness<T> baseBussiness)
        {
            _baseBussiness = baseBussiness;
        }

        // GET: api/[controller]/All
        [HttpGet("all")]
        public async Task<IActionResult> Get()
        {
            return Ok(await _baseBussiness.GetData());
        }

        // GET api/[controller]/{id}
        // todo...
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/[controller]
        [HttpPost]
        public virtual async Task<IActionResult> Post([FromBody] T entity)
        {
            var result =await _baseBussiness.Insert(entity);
            return Ok(result);
        }

        // PUT api/[controller]
        [HttpPut("")]
        public virtual async Task<IActionResult> Put([FromBody] T entity)
        {
            var result = await _baseBussiness.Update(entity);
            return Ok(result);
        }

        // DELETE api/[controller]/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            return Ok(await _baseBussiness.Delete(id));
        }
    }
}
