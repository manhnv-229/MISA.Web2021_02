using Kimerce.Backend.Domain.Books;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kimerce.Backend.Infrastructure.Data
{
    /// <summary>
    /// DbContext 2 để test tên là MisaDbContext
    /// </summary>
    public class MisaDbContext : DbContext
    {
        public DbSet<Book> Book { get; }
        public MisaDbContext(DbContextOptions<MisaDbContext> options)
           : base(options)
        {

        }
    }
}
