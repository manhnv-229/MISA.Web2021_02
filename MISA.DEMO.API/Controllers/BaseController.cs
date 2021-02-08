using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.Service;
using MISA.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.DEMO.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController<MISAEntity> : ControllerBase
    {
        #region Declare
        IBaseService<MISAEntity> _baseService;
        #endregion

        #region Constructor
        public BaseController(IBaseService<MISAEntity> baseService)
        {
            _baseService = baseService;
        }
        #endregion

        #region Method
        /// <summary>
        /// Hàm lấy dữ liệu từ Service trả về
        /// </summary>
        /// <returns>Dữ liệu lấy được</returns>
        /// CreatedBy PVTRONG (8/2/2021)
        [HttpGet]
        public IActionResult Get()
        {
            var serviceResult = _baseService.GetData();
            var entities = serviceResult.Data as List<MISAEntity>;
            if (entities.Count() == 0)
                return StatusCode(204, serviceResult.Data);
            return StatusCode(200, serviceResult.Data);

        }

        /// <summary>
        /// PVTRONG 31/12/2020
        /// </summary>
        /// <param name="misaEntity">Đối tượng được thêm</param>
        /// <returns>Trả về tình trạng thêm</returns>
        /// CreatedBy PVTRONG (8/2/2021)
        [HttpPost]
        public IActionResult Post([FromBody] MISAEntity misaEntity)
        {

            var serviceResult = _baseService.Insert(misaEntity);
            if (serviceResult.Success == false)
            {
                return StatusCode(400, serviceResult.Data);
            }
            else if (serviceResult.Success == true && (int)serviceResult.Data > 0) return StatusCode(201, serviceResult.Data);
            else return StatusCode(200, serviceResult.Data);

        }

        /// <summary>
        /// Hàm chỉnh sửa dữ liệu đối tượng
        /// </summary>
        /// <param name="misaEntity">Đối tượng cần chỉnh sửa</param>
        /// <returns>Số bản ghi được chính sửa</returns>
        /// CreatedBy PVTRONG (08/02/2021)
        [HttpPut]
        public IActionResult Put([FromBody] MISAEntity misaEntity)
        {

            var serviceResult = _baseService.Update(misaEntity);
            if (serviceResult.Success == false)
            {
                return StatusCode(400, serviceResult.Data);
            }
            else if (serviceResult.Success == true && (int)serviceResult.Data > 0) return StatusCode(201, serviceResult.Data);
            else return StatusCode(200, serviceResult.Data);

        }
        #endregion
    }
}
