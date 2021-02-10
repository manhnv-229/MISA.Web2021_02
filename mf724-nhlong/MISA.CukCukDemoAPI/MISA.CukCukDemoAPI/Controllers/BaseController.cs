using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using MISA.Service.Interfaces;
using System.Net.Mail;
using System.Data;
using MySql.Data.MySqlClient;
using MISA.Service.Entities;
using Dapper;

namespace DemoApi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class BaseController<TEntity> : ControllerBase
    {
        #region Declare Field
        // Service mà Controller gọi tới
        IBaseService<TEntity>  _baseService;
        #endregion

        #region Constructor
        /// <summary>
        /// Hàm khởi tạo cho Controller. Gắn Service cho Controller gọi tới
        /// </summary>
        /// <param name="baseService"></param>
        public BaseController(IBaseService<TEntity>  baseService)
        {
            _baseService = baseService;
        }
        #endregion

        #region Methods
        // GET: api/<EmployeeController>
        /// <summary>
        /// Controller tiếp nhận request lấy danh sách thực thể
        /// </summary>
        /// <param name="offset"> số thứ tự của trang hiện tại</param>
        /// <returns>List các thực thể theo số trang</returns>
        /// Created By : NHLong (06/02/2021)
        [HttpGet]
        public IActionResult GetEntities([FromQuery] int offset)
        {

                var entities =  _baseService.GetEntities();
            if (entities != null)
                return Ok(new
                {
                    Success = entities.Success,
                    Message = "Thành công",
                    Data = entities.Data
                });
                else 
                    return Ok(new
                    {
                        Success = entities.Success,
                        Message = "That Bai",
                        Data = "Khong ton tai ban ghi nao"
                    });
        }

        // GET api/<EmployeeController>/5
        /// <summary>
        /// Controller nhận request lấy thực thể theo Guid theo phương thức GET
        /// </summary>
        /// <param name="id">Guid của thực thể</param>
        /// <returns>Trả về thực thể nếu tồn tại</returns>
        /// Created By : NHLong (07/02/2021)
        [HttpGet("{id}")]
        public IActionResult GetEntityByID(Guid id)
        {
            try 
            {
                var employees = _baseService.GetEntityByID(id);
                return Ok(new
                {
                    Success = employees.Success,
                    Message = "Thành công",
                    Data = employees.Data
                });
            }
            catch
            {
                return BadRequest(new
                {
                    Success = false,
                    Message = "Không lấy được mã nhân viên mới nhất",
                });
            }
        }

        // GET api/GetEmployeeByDepartmentID/<DepartmentID>
        /// <summary>
        /// Lấy đối tượng theo mã
        /// </summary>
        /// <param type="string" name="code">Mã Đối Tượng</param>
        /// <returns>Trả về  object đối tượng</returns>
        
        [Route("GetEntityByCode/{code}")]
        [HttpGet()]
        public IActionResult GetEntityByCode( string code)
        {
            // try 
            // {
                var employees = _baseService.GetEntityByCode(code);
                return Ok(new
                {
                    Success = employees.Success,
                    Message = "Thành công",
                    Data = employees.Data
                });
            // }
            // catch
            // {
            //     return BadRequest(new
            //     {
            //         Success = false,
            //         Message = "Không lấy được mã nhân viên mới nhất",
            //     });
            // }
        }

        /// <summary>
        /// Controller thực hiện nhận request POST để thêm mới thực thể
        /// </summary>
        /// <param name="entity">Đối tượng thực thể lấy từ body</param>
        /// <returns></returns>
        /// Created By : NHLong (07/02/2021)
        [HttpPost()]
        public IActionResult AddEntity([FromBody] TEntity entity)
        {
            // try {
            // Goi den Service de check nghiep vu va them moi 
            var serviceResult = _baseService.AddEntity(entity);
            
            if (serviceResult.Success == true){
                return StatusCode(200,serviceResult.Data);
            }
            else
                return StatusCode(400,serviceResult.Data);
            // }
            // catch
            // {
            //     return BadRequest(new{
            //         Success = false,
            //         Message = "Có ngoại lệ xảy ra trong lúc thêm đối tượng. Vui lòng liên hệ MISA để biết thêm chi tiết !"
            //     });
            // }
        }

        /// <summary>
        /// Controller thực hiện nhận request PUT để thực hiện sửa thông tin thực thể
        /// </summary>
        /// <param name="entity">Đối tượng thực thể nhận từ body của request</param>
        /// <returns></returns>
        /// Created By : NHLong (07/02/2021)
        // PUT api/<EmployeeController>/5
        [HttpPut()]
        public virtual IActionResult UpdateEntity( [FromBody] TEntity entity)
        {
            try
            {
                var effecRows = _baseService.UpdateEntity(entity);
                return Ok(new
                {
                    Success = effecRows.Success,
                    Message = "Thành Công",
                    Data = effecRows.Data
                });
            }
            catch
            {
                return BadRequest(new{
                    Success = false,
                    Message = "Có ngoại lệ xảy ra trong lúc sửa đối tượng. Vui lòng liên hệ MISA để biết thêm chi tiết !"
                });
            }
        }

        /// <summary>
        /// Controller nhận request DELETE nhằm xóa thực thể dựa trên danh sách mã GUID
        /// </summary>
        /// <param name="id">List các mã GUID</param>
        /// <returns></returns>
        /// Created By : NHLong (07/02/2021)
        // DELETE api/<EmployeeController>/5
        [HttpDelete()]
        public IActionResult DeleteEntity([FromBody] List<Guid> id)
        {
            //try
            //{
                var rowAffecteds = _baseService.DeleteEntity(id);
                return Ok(new
                {
                    Success = rowAffecteds.Success,
                    Message = "Xóa Thành Công",
                    Data = rowAffecteds.Data
                });
            //}
            //catch
            //{
            //    return BadRequest(new
            //    {
            //        Success = false,
            //        Message = "Có ngoại lệ xảy ra trong lúc xóa đối tượng. Vui lòng liên hệ MISA để biết thêm chi tiết !"
            //    });
            //}  
        }
        #endregion
    }
    
}
