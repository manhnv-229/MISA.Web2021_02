using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.BL.Interfaces;
using MISA.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.CukCuk.Web.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class BaseController<TEntity> : ControllerBase
    {
        IBaseBL<TEntity> _baseBL;
        public BaseController(IBaseBL<TEntity> baseBL)
        {
            _baseBL = baseBL;
        }

        /// <summary>
        /// Lấy toàn bộ dữ liệu 
        /// </summary>
        /// <returns>Trạng thái và dữ liệu</returns>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_baseBL.GetAll());
        }
        
        /// <summary>
        /// Thêm mới dữ liệu có check dữ liệu trùng
        /// </summary>
        /// <param name="entity">Dữ liệu truyền vào</param>
        /// <returns>Status</returns>
        [HttpPost]
        public IActionResult Post(TEntity entity)
        {
            var serviceResult = _baseBL.Insert(entity);
            if (serviceResult.MISACode == MISACode.NotValid)
            {
                return BadRequest(serviceResult.Data);
            }
            if (serviceResult.MISACode == MISACode.Success && (int)serviceResult.Data > 0)
            {
                return Created("Success", serviceResult.Messenger);
            }
            else return NoContent();
        }

        [HttpPut]
        public IActionResult Put(TEntity entity)
        {
            var serviceResult = _baseBL.Update(entity);
            if (serviceResult.MISACode == MISACode.NotValid)
            {
                return BadRequest(serviceResult.Data);
            }
            if (serviceResult.MISACode == MISACode.Success && (int)serviceResult.Data > 0)
            {
                return Created("Success", serviceResult.Messenger);
            }
            else return NoContent();
        }

        [HttpDelete]
        public IActionResult Delete(TEntity entity)
        {
            var serviceResult = _baseBL.Delete(entity);
            if (serviceResult.MISACode == MISACode.NotValid)
            {
                return BadRequest(serviceResult.Data);
            }
            if (serviceResult.MISACode == MISACode.Success && (int)serviceResult.Data > 0)
            {
                return Created("Success", serviceResult.Messenger);
            }
            else return NoContent();
        }

    }
}
