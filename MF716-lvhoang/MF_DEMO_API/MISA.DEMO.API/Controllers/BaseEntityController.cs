using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using MISA.DataLayer;
using MISA.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection;
using MISA.Common.Enum;

namespace MISA.DEMO.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseEntityController<TEntity> : ControllerBase
    {
        
        IBaseService<TEntity> _baseService;
        public BaseEntityController(IBaseService<TEntity> baseService)
        {
           
                
                _baseService = baseService;
            

        }


        /// <summary>
        /// Lấy toàn bộ dữ liệu
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public virtual IActionResult Get()
        {
            var entities = _baseService.GetAll();
            return Ok(entities);
        }



        /// <summary>
        /// Lấy dữ liệu theo Id
        /// </summary>
        /// <param name="Id">Id của đối tượng cần lấy</param>
        /// <returns></returns>
        /// CreatedBy: LVHOANG
        [HttpGet("{id}")]
        public virtual IActionResult Get(Guid id)
        {
            var entity = _baseService.GetById(id);
            return Ok(entity);
        }

        /// <summary>
        /// Thêm mới dữ liệu
        /// </summary>
        /// <param name="entity">object thêm mới</param>
        /// <returns></returns>
        /// CreatedBy: LVHOANG
        [HttpPost]
        public virtual IActionResult Post([FromBody] TEntity entity)
        {
            //employee.EmployeeId = Guid.NewGuid();

            var res = _baseService.Insert(entity);
            switch (res.MISACode)
            {
                case MISAServiceCode.BadRequest:
                    return BadRequest(res);
                case MISAServiceCode.Success:
                    return Ok(res);
                case MISAServiceCode.Exception:
                    return StatusCode(500);
                default:
                    return Ok();
            }

        }

        /// <summary>
        /// Sửa đối tượng 
        /// </summary>
        /// <param name="id">Id của đối tượng cần sửa</param>
        /// <param name="entity">đối tượng sau khi sửa</param>
        /// <returns></returns>
        /// CreatedBy: LVHOANG
        [HttpPut("{id}")]
        public virtual IActionResult Put(Guid id, [FromBody] TEntity entity)
        {

            var res = _baseService.Update(id, entity);
            switch (res.MISACode)
            {
                case MISAServiceCode.BadRequest:
                    return BadRequest(res);
                case MISAServiceCode.Success:
                    return Ok(res);
                case MISAServiceCode.Exception:
                    return StatusCode(500);
                default:
                    return Ok();
            }

        }

        /// <summary>
        /// Xóa đối tượng 
        /// </summary>
        /// <param name="id">Id của đối tượng cần xóa</param>
        /// <returns></returns>
        /// CreatedBy: LVHOANG
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var effectRows = _baseService.Delete(id);
            return Ok(effectRows);
        }
    }

}
