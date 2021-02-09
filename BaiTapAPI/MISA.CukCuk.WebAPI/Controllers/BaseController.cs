using Microsoft.AspNetCore.Mvc;
using MISA.BL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MISA.CukCuk.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController<T> : ControllerBase
    {

        IBaseBL<T> _baseBL;

        public BaseController(IBaseBL<T> baseBL)
        {
            _baseBL = baseBL;
        }
        // GET: api/<BaseController>
        /// <summary>
        /// Thêm bản ghi vào cơ sở dữ liệu
        /// </summary>
        /// <returns></returns>
        /// CreatedBy: NDLuu (8/2/2021)
        [HttpGet]
        public IActionResult Get()
        {
            var result = _baseBL.GetAllData();
            var entities = result.Data as List<T>;
            if (result.Success)
            {
                if (entities.Count == 0)
                    return StatusCode(204, entities);
                else
                    return StatusCode(200, entities);
            }
            else
            {
                return StatusCode(404, entities);
            }
        }


        // POST api/<BaseController>
        /// <summary>
        /// Thêm mới bản ghi
        /// </summary>
        /// <param name="entity">đối tượng cần thêm</param>
        /// <returns></returns>
        /// CreatedBy: NDLuu (8/2/2021)
        [HttpPost]
        public IActionResult Post([FromBody] T entity)
        {
            var result = _baseBL.Insert(entity);
            if (result.Success == false)
                return StatusCode(400, result.Data);
            return StatusCode(200, result.Data);
        }

        // PUT api/<BaseController>/5
        /// <summary>
        /// Cập nhật bản ghi
        /// </summary>
        /// <param name="entity">Đối tượng cần sửa</param>
        /// <returns></returns>
        /// CreatedBy: NDLuu (8/2/2021)
        [HttpPut]
        public IActionResult Put([FromBody] T entity)
        {
            var result = _baseBL.Update(entity);
            if (result.Success == false)
                return StatusCode(400, result.Data);
            else if (result.Success == true && (int)result.Data > 0)
                return StatusCode(201, result.Data);
            return StatusCode(200, result.Data);
        }

        // DELETE api/<BaseController>/5
        /// <summary>
        /// Xoá bản ghi
        /// </summary>
        /// <param name="id">id đối tượng cần xoá</param>
        /// <returns></returns>
        /// CreatedBy: NDLuu (8/2/2021)
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            // Kết quả trả về
            var result = _baseBL.Delete(id);
            // Kiểm tra trạng thái trả về
            if (result.Success == false)
                return StatusCode(404, result.Data);
            return StatusCode(200, result.Data);
        }
    }
}
