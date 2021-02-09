using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MISA.Service;
using MISA.Service.Interface;

namespace MISA.CukCuk.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class BaseController<MisaEntity> : ControllerBase
    {
        IBaseService<MisaEntity> _baseService;
        public BaseController(IBaseService<MisaEntity> baseService)
        {
            _baseService = baseService;
        }
        /// <summary>
        /// Lấy danh sách khách hàng
        /// </summary>
        /// <returns>danh sách</returns>
        /// CreatedBy: LHPHONG (7/2/2021)
        [HttpGet]
        public IActionResult Get()
        {
            var serviceResult = _baseService.GetData();
            var entity = serviceResult.Data as List<MisaEntity>;
            if (entity.Count == 0)
                return StatusCode(204, serviceResult.Data);
            else
                return StatusCode(200, serviceResult.Data);
        }

        /// <summary>
        /// Thêm mới khách hàng
        /// </summary>
        /// <param name="customer">Khách hàng cần thêm mới</param>
        /// <returns>StatusCode</returns>
        /// CreatedBy: LHPHONG (7/2/2021)
        [HttpPost]
        public IActionResult Post(MisaEntity entity)
        {
            try
            {
                var res = _baseService.Insert(entity);

                if (res.Success == false)
                {
                    return StatusCode(400, res.Data);
                }
                else
                {
                    if ((int)res.Data > 0)
                    {
                        return StatusCode(201, res.Data);
                    }
                    else return StatusCode(200, res.Data);
                }
            }
            catch (Exception)
            {
                return StatusCode(500, "Có lỗi xảy ra, vui lòng liên hệ misa!");
            }
        }
    }
}
