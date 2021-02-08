using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.Service;
using MISA.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.CukCuk.Api.Controllers
{
    /// <summary>
    /// base chung cho controlelr
    /// </summary>
    /// <typeparam name="Entity"></typeparam>
    /// CreatedBy: TQAnh (08/02/2021)

    [Route("api/[controller]")]
    [ApiController]
    public class BaseController<Entity> : ControllerBase
    {

        #region DECLARE
        IBaseService<Entity> _baseService;
        #endregion

        #region Constructor
        public BaseController(IBaseService<Entity> baseService )
        {
            _baseService = baseService;
        }
        #endregion

        #region Method
        /// <summary>
        /// Lấy danh sách các  đối tượng
        /// </summary>
        /// <returns> trả về danh sách các  đối tượng </returns>
        /// CreatedBy: TQAnh (08/02/2021)
        [HttpGet]
        public IActionResult Get()
        {

           
            var serviceResult = _baseService.GetData();
            var entity = serviceResult.Data as List<Entity>;
            if (entity.Count == 0)
                return StatusCode(204, serviceResult.Data);
            else return StatusCode(200, serviceResult.Data);
        }


        /// <summary>
        /// Thêm mới một đối tượng
        /// </summary>
        /// <param name="entity"> thực thể đối tượng cần thêm mới </param>
        /// <returns> trả về số dòng được thay đổi </returns>
        ///  CreatedBy: TQAnh (08/02/2021)
        [HttpPost]
        public IActionResult Post(Entity entity)
        {

          
            var res = _baseService.Insert(entity);
            if (res.Success == false)
                return StatusCode(400, res.Data);
            else if (res.Success == true && (int)res.Data > 0)
                return StatusCode(201, res.Data);
            else return StatusCode(200, res.Data);
        }

        /// <summary>
        /// Chỉnh sửa một đối tượng
        /// </summary>
        /// <param name="id">khóa chính của đối tượng</param>
        /// <param name="entity"> đối tượng cần thay đổi </param>
        /// <returns>Số dòng được thay đổi </returns>
        ///  CreatedBy: TQAnh (08/02/2021)
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] Entity entity)
        {


            var res = _baseService.Update(id,entity);
            return StatusCode(200, res.Data);
        }

        /// <summary>
        /// Xóa đối tượng
        /// </summary>
        /// <param name="id">khóa chính đối tượng cần xóa </param>
        /// <returns>trả về số dòng được thay đổi </returns>
        ///  CreatedBy: TQAnh (08/02/2021)
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {

            var res = _baseService.Delete(id);
            return StatusCode(200, res.Data);
        }

        #endregion

    }
}
