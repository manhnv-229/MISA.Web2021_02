using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.Service;
using MISA.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.CukCuk.Api.Controllers
{
    /// <summary>
    /// Base Class cho Controller các controller kế thừa có thể gọi lại các method từ base
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [Route("api/v1/[controller]")]
    [ApiController]
    public class BasesController<T> : ControllerBase
    {
        /// <summary>
        /// Khai báo interface tham chiếu đến BaseService
        /// </summary>
        IBaseService<T> _baseService;
        public BasesController(IBaseService<T> baseService)
        {
            _baseService = baseService;
        }
        /// <summary>
        /// Lấy toàn bộ dữ liệu đối tượng
        /// </summary>
        /// <returns>Danh sách dữ liệu dối tượng</returns>
        public IActionResult Get()
        {
            var res = _baseService.Get();
            var result = res.Data as List<T>;
            // Nếu có kết quả trả về result.Count > 0 thì trả về 200 nếu không trả về 204
            if (result.Count == 0)
                return StatusCode(204, res.Data);
            else
                return StatusCode(200, res.Data);
        }

        // POST api/<CustomersController>
        /// <summary>
        /// Thêm đối tượng
        /// </summary>
        /// <param name="entity">Thực thể</param>
        /// <returns>Responsive tương ứng cho Client (201- thành công, ...)</returns>
        /// CreatedBy: NMDAT (03/02/2021)
        [HttpPost]
        public IActionResult Post(T entity)
        {
            // Gọi đến hàm Insert thực hiện validate -> thêm
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


        // POST api/<CustomersController>
        /// <summary>
        /// Sửa đối tượng
        /// </summary>
        /// <param name="entity">Thực thể</param>
        /// <returns>Responsive tương ứng cho Client (201- thành công, ...)</returns>
        /// CreatedBy: NMDAT (03/02/2021)
        [HttpPut]
        public IActionResult Put(T entity)
        {
            // Gọi đến hàm Insert thực hiện validate -> Sửa
            var res = _baseService.Update(entity);

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

        // DELETE api/<ValuesController>/5
        [HttpDelete]
        public IActionResult Delete(T entity)
        {
            // Gọi đến hàm Insert thực hiện validate -> Sửa
            var res = _baseService.Delete(entity);

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
