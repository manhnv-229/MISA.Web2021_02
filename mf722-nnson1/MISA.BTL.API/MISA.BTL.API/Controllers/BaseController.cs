using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.BTL.Business;
using MISA.BTL.Business.Interfaces;

namespace MISA.BTL.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class BaseController<T> : ControllerBase
    {
        IBaseBusiness<T> _baseBusiness;
        /// <summary>
        /// Hàm khởi tạo
        /// </summary>
        /// <param name="baseBusiness"></param>
        /// CreatdBy: NNSON (08/02/2021)
        public BaseController(IBaseBusiness<T> baseBusiness)
        {
            _baseBusiness = baseBusiness;
        }

        /// <summary>
        /// Lấy dữ liệu
        /// </summary>
        /// <returns>204: NoContent; 200: Success</returns>
        [HttpGet]
        public IActionResult Get()
        {
            var res = _baseBusiness.GetData();
            var customers = res.Data as List<T>;
            if (customers.Count == 0)
            {
                return StatusCode(204, res.Data);
            }
            else
            {
                return StatusCode(200, res.Data);
            }
        }

        /// <summary>
        /// Thêm dữ liệu
        /// </summary>
        /// <param name="entity">object cần thêm mới</param>
        /// <returns>400: BadRequest; 201: Thêm thành công</returns>
        [HttpPost]
        public IActionResult Post([FromBody] T entity)
        {
            var res = _baseBusiness.Insert(entity);
            switch (res.Success)
            {
                case false:
                    return StatusCode(400, res.Data);
                case true:
                    return StatusCode(201, res.Data);
            }
        }

        /// <summary>
        /// Sửa thông tin
        /// </summary>
        /// <param name="entity">object đã sửa</param>
        /// <returns>400: BadRequest; 201: Sửa thành công</returns>
        [HttpPut]
        public IActionResult Put([FromBody] T entity)
        {
            var res = _baseBusiness.Update(entity);
            switch (res.Success)
            {
                case false:
                    return StatusCode(400, res.Data);
                case true:
                    return StatusCode(201, res.Data);
            }
        }

        /// <summary>
        /// Xóa thông tin
        /// </summary>
        /// <param name="id">id của object cần xóa</param>
        /// <returns>400: BadRequest; 200: Success</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            var res = _baseBusiness.Delete(id);
            switch (res.Success)
            {
                case false:
                    return StatusCode(400, res.Data);
                case true:
                    return StatusCode(200, res.Data);
            }
        }
    }
}
