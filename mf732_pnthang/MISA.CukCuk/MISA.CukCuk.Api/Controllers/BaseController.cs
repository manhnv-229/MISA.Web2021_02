using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MISA.Service.Interfaces;

namespace MISA.CukCuk.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class BaseController<MISAEntity> : ControllerBase
    {
        // Khởi tạo field kết nối để sử dụng Service
        IBaseService<MISAEntity> _baseService;
        /// <summary>
        /// Khởi tạo kết nối với BaseService bằng interface
        /// </summary>
        /// <param name="baseService">Biến lấy các phương thức từ interface</param>
        /// CreatedBy: PNTHANG (08/02/2021)
        public BaseController(IBaseService<MISAEntity> baseService)
        {
            _baseService = baseService;
        }

        /// <summary>
        /// Lấy dữ liệu với giao thức HttpGet
        /// </summary>
        /// <returns>(200 - lấy dữ liệu thành công hoặc 204 - không có dữ liệu) và dữ liệu lấy được</returns>
        /// CreatedBy: PNTHANG (08/02/2021)
        [HttpGet]
        public IActionResult Get()
        {
            var serviceResult = _baseService.GetData();
            var entities = serviceResult.Data as List<MISAEntity>;
            if (entities.Count == 0)
                return StatusCode(204, serviceResult.Data);
            else
                return StatusCode(200, serviceResult.Data);
        }
        /// <summary>
        /// Thêm mới dữ liệu với giao thức HttpPost
        /// </summary>
        /// <param name="entity">đối tượng cần thêm</param>
        /// <returns>
        /// 400 - thêm không thành công;
        /// 201 - thêm thành công;
        /// 200 - thêm thành công nhưng số bản ghi = 0;
        /// + trả về số bản ghi
        /// </returns>
        [HttpPost]
        public IActionResult Post(MISAEntity entity)
        {
            var res = _baseService.Insert(entity);
            if (res.Success == false)
            {
                return StatusCode(400, res.Data);
            }
            else if (res.Success == true && (int)res.Data > 0)
            {
                return StatusCode(201, res.Data);
            }
            else
            {
                return StatusCode(200, res.Data);
            }
        }
    }
}
