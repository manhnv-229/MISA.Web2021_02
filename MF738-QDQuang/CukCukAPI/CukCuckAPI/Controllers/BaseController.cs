using CukCuk.BL;
using CukCuk.BL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CukCuckAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class BaseController<TEntity> : ControllerBase
    {
        #region DECLARE
        IBaseBL<TEntity> _baseBL;
        #endregion

        #region CONSTRUCTOR
        public BaseController(IBaseBL<TEntity> baseBL)
        {
            _baseBL = baseBL;
        }
        #endregion

        #region METHODS
        /// <summary>
        /// Phương thức GET - Đọc dữ liệu
        /// </summary>
        /// <returns>Entities</returns>
        /// CreatedBy: QDQuang (08/02/2021)
        [HttpGet]
        public IActionResult Get()
        {
            // Lấy dữ liệu
            var result = _baseBL.GetData();
            // Ép kiểu thành dạng List<TEntity> để có thể kiểm tra số lượng bản ghi
            var entities = result.Data as List<TEntity>;
            // Kiểm tra trạng thái trả về
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

        /// <summary>
        /// Phương thức POST - Ghi dữ liệu
        /// </summary>
        /// <returns></returns>
        /// CreatedBy: QDQuang (08/02/2021)
        [HttpPost]
        public IActionResult Post([FromBody] TEntity entity)
        { 
            // Kết quả trả về
            var result = _baseBL.Insert(entity);
            // Kiểm tra trạng thái trả về
            if (result.Success == false)
                return StatusCode(400, result.Data);
            return StatusCode(200, result.Data);
        }

        /// <summary>
        /// Phương thức PUT - Cập nhật dữ liệu
        /// </summary>
        /// <returns></returns>
        /// CreatedBy: QDQuang (08/02/2021)
        [HttpPut]
        public IActionResult Put([FromBody] TEntity entity)
        {
            // Kết quả trả về
            var result = _baseBL.Update(entity);
            // Kiểm tra trạng thái trả về
            if (result.Success == false)
                return StatusCode(400, result.Data);
            else if (result.Success == true && (int)result.Data > 0)
                return StatusCode(201, result.Data);
            return StatusCode(200, result.Data);
        }

        /// <summary>
        /// Phương thức DELETE - Xóa bản ghi
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            // Kết quả trả về
            var result = _baseBL.Delete(id);
            // Kiểm tra trạng thái trả về
            if (result.Success == false)
                return StatusCode(404, result.Data);
            return StatusCode(204, result.Data);
        }
        #endregion
    }
}
