using ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CukCuk.Controllers
{
    /// <summary>
    /// Lớp cơ sở của Controller
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    [Route("api/v1/[controller]")]
    [ApiController]
    public class BaseController<TEntity> : ControllerBase
    {
        #region Decla
        IBaseService<TEntity> _baseService;
        #endregion
        #region Constructor
        public BaseController(IBaseService<TEntity> baseService) {
            this._baseService = baseService; 
        }
        #endregion
        #region Method
        /// <summary>
        /// Lấy danh sách các đối tượng 
        /// </summary>
        /// <returns>Danh sách các đối tượng</returns>
        // GET: api/<BaseController>
        [HttpGet]
        public IActionResult Get()
        {
            var serviceResult =  _baseService.GetData();
            return StatusCode(int.Parse(serviceResult.StatusCode) , serviceResult.Data);
        }

        /// <summary>
        /// Thêm mới đối tượng
        /// </summary>
        /// <param name="entity">Thực thể đối tượng</param>
        /// <returns>Trạng thái thành công/ thất bại</returns>
        // POST api/<BaseController>
        [HttpPost]
        public IActionResult Post([FromBody] TEntity entity)
        {
            var serviceResult = _baseService.Insert(entity);
            return StatusCode(int.Parse(serviceResult.StatusCode), serviceResult.Data);
        }
        /// <summary>
        /// Chỉnh sửa thông tin đối tượng
        /// </summary>
        /// <param name="entity">Thực thể đối tượng</param>
        /// <returns>Trạng thái thành công/ thất bại</returns>
        // PUT api/<BaseController>/5
        [HttpPut]
        public IActionResult Put([FromBody] TEntity entity)
        {
            var serviceResult = _baseService.Update(entity);
            return StatusCode(int.Parse(serviceResult.StatusCode), serviceResult.Data);
        }
        /// <summary>
        /// Xóa một đối tượng
        /// </summary>
        /// <param name="id">Id của đới tượng</param>
        /// <returns>Trạng thái thành công/ thất bại</returns>
        // DELETE api/<BaseController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var serviceResult = _baseService.Delete(id);
            return StatusCode(int.Parse(serviceResult.StatusCode), serviceResult.Data);
        }
        #endregion
    }
}
