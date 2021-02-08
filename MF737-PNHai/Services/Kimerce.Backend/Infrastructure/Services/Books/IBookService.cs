using Kimerce.Backend.Domain.Books;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kimerce.Backend.Infrastructure.Services.Books
{
    /// <summary>
    /// Interface của Book Service 
    /// </summary>
    public interface IBookService
    {
        /// <summary>
        /// lấy danh sách sách trong db 
        /// </summary>
        /// <returns></returns>
        public List<Book> GetBookcs();
    }
}
