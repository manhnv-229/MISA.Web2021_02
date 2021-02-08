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
        IBaseService<MISAEntity> _baseService;
        /// <summary>
        /// Khởi tạo kết nối với BaseService bằng Interface
        /// </summary>
        /// <param name="baseService"> Lấy các phương thức từ Interface </param>
        /// CreatedBy: NTTHIEM
        /// CreatedDate: 08/02/2021
        public BaseController(IBaseService<MISAEntity> baseService)
        {
            _baseService = baseService;
        }

        /// <summary>
        /// Lấy dữ liệu với HttpGet
        /// </summary>
        /// <returns> (200 - lấy dữ liệu thành công hoặc 204 - không có dữ liệu) và dữ liệu lấy được </returns>
        /// CreatedBy: NTTHIEM
        /// CreatedDate: 08/02/2021
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
        /// Thêm mới dữ liệu với HttpPost
        /// </summary>
        /// <param name="entity">Đối tượng cần thêm</param>
        /// <returns>
        /// 400 - Không thành công;
        /// 201 - Thành công;
        /// 200 - Thành công;
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
