using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.DataLayer;
using MISA.Service;
using MISA.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MisaCukCuk.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class BasesController<TEntity> : ControllerBase
    {
        #region DECLARE
        IBaseService<TEntity> _baseService;
        #endregion

        #region CONTRUCTOR
        public BasesController(IBaseService<TEntity> baseService)
        {
            _baseService = baseService;
        }
        #endregion

        #region METHODS

        /// <summary>
        /// Lấy toàn bộ danh sách nhân viên
        /// </summary>
        /// <returns>Mã trạng thái và toàn bộ dữ liệu</returns>
        /// CreatedBy: TLMinh (01/02/2021)
        [HttpGet]
        public IActionResult Get()
        {
            var result = _baseService.Get();
            var datas = (List<TEntity>)result.Data;
            if (datas.Count == 0)
            {
                return StatusCode(204, result.Data);
            }

            return StatusCode(200, result.Data);
        }

        /// <summary>
        /// Thêm một nhân viên vào danh sách
        /// </summary>
        /// <param name="employee">Thực thể khách hàng</param>
        /// <param name="entityCode">Mã thực thể mà chủ thể có khóa ngoại chỉ tới</param>
        /// <returns>Mã trạng thái và số bản ghi được thêm</returns>
        /// CreatedBy: TLMinh (01/02/2021)
        [HttpPost]
        public IActionResult Post([FromBody] TEntity entity, [FromQuery] string entityCode = null)
        {
            var result = _baseService.Post(entity,entityCode);
            if (result.Success && (int)result.Data > 0)
            {
                return StatusCode(201, result.Data);
            }
            else if (result.Success)
                return StatusCode(204, result.Data);
            else
                return StatusCode(400, result.Data);
        }

        /// <summary>
        /// Xóa một bản ghi
        /// </summary>
        /// <param name="entityId">Id của bản ghi cần xóa</param>
        /// <param name="way">1 xóa theo id chính, 2 xóa theo id ngoại</param>
        /// <returns>Mã trạng thái và số bản ghi bị xóa</returns>
        /// CreatedBy: TLMinh (07/02/2021)
        [HttpDelete]
        public IActionResult Delete([FromQuery]string entityId, [FromQuery] int way = 1)
        {
            var result = _baseService.Delete(entityId,way);
            if ((int)result.Data > 0)
                return StatusCode(200, result.Data);
            return StatusCode(204, result.Data);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="entityCode"></param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult Put([FromBody]TEntity entity, [FromQuery] string entityCode = null)
        {
            var result = _baseService.Put(entity,entityCode);
            if (result.Success && (int)result.Data > 0)
            {
                return StatusCode(201, result.Data);
            }
            else if (result.Success)
                return StatusCode(204, result.Data);
            else
                return StatusCode(400, result.Data);
        }

        #endregion
    }
}
