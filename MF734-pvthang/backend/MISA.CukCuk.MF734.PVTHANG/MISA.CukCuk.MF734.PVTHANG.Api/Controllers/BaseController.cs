using Microsoft.AspNetCore.Mvc;
using MISA.CukCuk.MF734.PVTHANG.Common.Models;
using MISA.CukCuk.MF734.PVTHANG.DataLayer.Classes;
using MISA.CukCuk.MF734.PVTHANG.Service.Classes;
using MISA.CukCuk.MF734.PVTHANG.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MISA.CukCuk.MF734.PVTHANG.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class BaseController<TEntity> : ControllerBase
    {
        IBaseService<TEntity> _baseService;

        public BaseController(IBaseService<TEntity> baseService)
        {
            _baseService = baseService;
        }

        /// <summary>
        /// Lấy tất cả dữ liệu
        /// </summary>
        /// <returns></returns>
        /// CREATED BY: PHẠM VIỆT THẮNG
        [HttpGet]
        public virtual IActionResult Get()
        {
            var res = _baseService.GetAll();
            return StatusCode((int)res.Code, res);
        }

        /// <summary>
        /// Lấy dữ liệu theo id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// CREATED BY: PHẠM VIỆT THẮNG
        [HttpGet("{id}")]
        public virtual IActionResult Get(String id)
        {
            var res = _baseService.GetById(id);
            return StatusCode((int)res.Code, res);
        }

        /// <summary>
        /// Thêm dữ liệu
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        /// CREATED BY: PHẠM VIỆT THẮNG
        [HttpPost]
        public virtual IActionResult Post([FromBody] TEntity entity)
        {
            var res = _baseService.Insert(entity);
            return StatusCode((int)res.Code, res);
        }

        /// <summary>
        /// Sửa dữ liệu
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        /// CREATED BY: PHẠM VIỆT THẮNG
        [HttpPut]
        public virtual IActionResult Put([FromBody] TEntity entity)
        {
            var res = _baseService.Update(entity);
            return StatusCode((int)res.Code, res);
        }

        /// <summary>
        /// Xóa dữ liệu
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// CREATED BY: PHẠM VIỆT THẮNG
        [HttpDelete("{id}")]
        public virtual IActionResult Delete(String id)
        {
            var res = _baseService.Delete(id);
            return StatusCode((int)res.Code, res);
        }
    }
}
