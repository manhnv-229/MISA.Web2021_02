using Kimerce.Backend.Domain.Books;
using Kimerce.Backend.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kimerce.Backend.Infrastructure.Services.Books
{
    public class BookService : IBookService
    {
        private readonly IMisaRepository<Book> repository;
        /// <summary>
        /// Class cung cấp phương thức để thao tác với database liên quan đến employees
        /// </summary>
        /// <param name="repository"></param>
        public BookService(IMisaRepository<Book> repository)
        {
            this.repository = repository;
        }
        /// <summary>
        /// Lấy danh sách quyển sách 
        /// </summary>
        /// <returns></returns>
        public List<Book> GetBookcs()
        {
            return repository.Query().ToList();
        }
    }
}
