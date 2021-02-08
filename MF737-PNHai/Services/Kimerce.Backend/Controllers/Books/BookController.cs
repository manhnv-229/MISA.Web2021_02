using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kimerce.Backend.Infrastructure.Services.Books;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Kimerce.Backend.Controllers.Books
{
    [Route("db2/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _service;
        /// <summary>
        /// Controller tương tác với book trong database thứ 2 
        /// </summary>
        /// <param name="service"></param>
        public BookController(IBookService service)
        {
            _service = service;
        }

        /// <summary>
        /// Lấy toàn bộ sách trong bảng book ra
        /// </summary>
        /// <returns></returns>
        [HttpGet("books")]
        public async Task<IActionResult> GetAll()
        {
            var res = _service.GetBookcs();
            return Ok(res);



    }
    }
   
}
