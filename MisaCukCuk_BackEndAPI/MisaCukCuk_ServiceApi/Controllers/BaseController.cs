using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MisaCukCuk_ApplicationCore.BaseApplicationCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MisaCukCuk_ServiceApi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class BaseController<T> : ControllerBase
    {
        IBaseApplicationCore<T> _code;
        public BaseController(IBaseApplicationCore<T> baseApplicationCore)
        {
            _code = baseApplicationCore;
        }
        /// <summary>
        /// Lấy tất cả dữ liệu
        /// CreateBy: MinhHq(08/02/2021)
        /// </summary>
        /// <returns>Danh sách truy vấn</returns>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var rs = await _code.GetData();
            var res = rs.Data as List<T>;
            if (rs.Success == true)
            {
                if (res.Count == 0)
                {
                    return StatusCode(204, rs.Data);
                }
                return StatusCode(200, rs.Data);
            }
            return StatusCode(200, rs.Data);
        }
        /// <summary>
        /// Lấy dữ liệu của Id
        /// CreateBy: MinhHq(08/02/2021)
        /// </summary>
        /// <param name="code"></param>
        /// <returns>Danh sách truy vấn</returns>
        [HttpGet("{code}")]
        public async Task<IActionResult> GetByID(Guid code)
        {
            var rs = await _code.GetById(code);
            var res = rs.Data as List<T>;
            if (rs.Success == true)
            {
                if (res.Count == 0)
                {
                    return StatusCode(204, rs.Data);
                }
                return StatusCode(200, rs.Data);
            }
            return StatusCode(200, rs.Data);
        }
        /// <summary>
        /// Xóa dữ liệu bản ghi
        /// CreateBy: MinhHq(08/02/2021)
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        [HttpDelete("{code}")]
        public async Task<IActionResult> Delete(Guid code)
        {
            var rs = await _code.DeleteData(code);
            if ((int)rs.Data > 0)
            {
                rs.Data = MisaCukCuk_Entity.Properties.Resources.DeleteSuccess;
                return StatusCode(200, rs.Data);
            }
            return StatusCode(400, rs.Data);
        }
        /// <summary>
        /// Thêm mới bản ghi
        /// CreateBy: MinhHq(08/02/2021)
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Insert([FromBody]T entity)
        {
            var rs = await _code.Insert(entity);
            if (rs.Success == false)
            {
                return StatusCode(400, rs.Data);
            }
            return StatusCode(201, rs.Data);

        }
        [HttpPut]
        public async Task<IActionResult> Put([FromBody]T entity)
        {
            var rs = await _code.Update(entity);
            if (rs.Success == false)
            {
                return StatusCode(400, rs.Data);
            }
            return StatusCode(201, rs.Data);
        }
    }
}
