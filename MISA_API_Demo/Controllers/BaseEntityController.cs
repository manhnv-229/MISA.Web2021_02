using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.DataLayer;
using MISA.Common.Models;
using MISA.Service;

namespace MISA_API_Demo.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class BaseEntityController<TEntity> : ControllerBase
    {
        protected DBConnector<TEntity> _db;
        protected BaseService<TEntity> _base;

        /// <summary>
        /// Khởi tạo kết nối tới DB
        /// </summary>
        public BaseEntityController()
        {
            _base = new BaseService<TEntity>();
            _db = new DBConnector<TEntity>();
        }
        /// <summary>
        /// Lấy danh sách khách hàng
        /// </summary>
        /// <returns>List bản ghi</returns>
        /// CreatedBy: TXTrinh (02/02/2021)
        // GET: api/<CustomersController>
        [HttpGet]
        public virtual IActionResult Get()
        {
            var res = _base.GetData();
            var entities = res.Data as List<TEntity>;
            if (entities.Count == 0)
                return StatusCode(204, res.Data);
            else return StatusCode(200, res.Data);
        }

        /// <summary>
        /// Lấy dữ liệu theo Id
        /// </summary>
        /// <param name="customerId">ID bản ghi</param>
        /// <returns>Bản ghi cần lấy</returns>
        /// CreatedBy: TXTrinh (02/02/2021)
        [HttpGet]
        [Route("{id}")]
        public virtual IActionResult Get(Guid id)
        {
            var result = _db.GetById(id);
            return Ok(new ActionServiceResult()
            {
                Success = true,
                Message = MISA.Common.Properties.Resources.SuccessMsg,
                Data = result,
                MISACode = EnumCodes.Success,
            });

        }

        /// <summary>
        /// Thêm mới dữ liệu
        /// </summary>
        /// <param name="entity">Kiểu của object</param>
        /// <returns>Số bản ghi ảnh hưởng</returns>
        /// CreatedBy: TXTrinh (02/02/2021)
        [HttpPost]
        public virtual IActionResult Post([FromBody] TEntity entity)
        {
            var effectRows = _db.Insert(entity);
            return Ok(new ActionServiceResult()
            {
                Success = true,
                Message = MISA.Common.Properties.Resources.SuccessMsg,
                Data = effectRows,
                MISACode = EnumCodes.Success,
            });
        }

        /// <summary>
        /// Chỉnh sửa dữ liệu
        /// </summary>
        /// <param>Bản ghi mới</param>
        /// <returns>Số bản ghi ảnh hưởng</returns>
        /// CreatedBy: TXTrinh (02/02/2021)
        [HttpPut]
        public virtual IActionResult Put([FromBody] TEntity entity)
        {
            var effectRows = _db.Update(entity);
            return Ok(new ActionServiceResult()
            {
                Success = true,
                Message = MISA.Common.Properties.Resources.SuccessMsg,
                Data = effectRows,
                MISACode = EnumCodes.Success,
            });
        }

        // DELETE api/<CustomersController>/5
        /// <summary>
        /// Xóa bản ghi
        /// </summary>
        /// <param name="customerId">ID của bản ghi</param>
        /// <returns>Số bản ghi ảnh hưởng</returns>
        /// CreatedBy: TXTrinh (02/02/2021)
        [HttpDelete]
        [Route("{customerId}")]
        public IActionResult Delete(Guid customerId)
        {
            var effectRows = _db.Delete(customerId);
            return Ok(new ActionServiceResult()
            {
                Success = true,
                Message = MISA.Common.Properties.Resources.SuccessMsg,
                Data = effectRows,
                MISACode = EnumCodes.Success,
            });
        }

        // Get api/<startPoint>/<number>
        /// <summary>
        /// Lấy số lượng bản ghi theo khoảng
        /// </summary>
        /// <param name="startPoint">Bản ghi bắt đầu</param>
        /// <param name="number">Số lượng bản ghi cần lấy</param>
        /// <returns>List các bản ghi</returns>
        /// CreatedBy: TXTrinh (02/02/2021)
        [HttpGet]
        [Route("{startPoint}/{number}")]
        public virtual IActionResult GetWithRange(int startPoint, int number)
        {
            var result = _db.GetWithRange(startPoint, number);
            return Ok(new ActionServiceResult()
            {
                Success = true,
                Message = MISA.Common.Properties.Resources.SuccessMsg,
                Data = result,
                MISACode = EnumCodes.Success,
            });
        }
        //GetMaxCode api/<Employee>/<GetMaxCode>
        /// <summary>
        /// Lấy ra mã lớn nhất trong bảng
        /// </summary>
        /// <returns>Mã lớn nhất</returns>
        /// CreatedBy: TXTrinh (02/02/2021)
        [HttpGet]
        [Route("GetMaxCode")]
        public virtual IActionResult GetMaxCode()
        {
            var result = _db.GetMaxCode();
            return Ok(new ActionServiceResult()
            {
                Success = true,
                Message = MISA.Common.Properties.Resources.SuccessMsg,
                Data = result,
                MISACode = EnumCodes.Success,
            });
        }
    }
}
