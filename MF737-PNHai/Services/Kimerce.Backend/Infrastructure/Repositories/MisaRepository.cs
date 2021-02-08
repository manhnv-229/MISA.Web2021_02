using Kimerce.Backend.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kimerce.Backend.Infrastructure.Repositories
{
    /// <summary>
    /// Các phương thức tương tác với DataBase 2 qua Reposotory
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class MisaRepository<T> : IDisposable, IMisaRepository<T> where T : class
    {

        public MisaRepository(MisaDbContext context)
        {
            Context = context;
            DbSet = Context.Set<T>();
            _context = context;
        }

        protected MisaDbContext Context { get; }
        private readonly MisaDbContext _context;
        protected DbSet<T> DbSet { get; }


        public void Dispose()
        {
            
        }

        public virtual IQueryable<T> Query()
        {
            return DbSet;

        }
    }
}
