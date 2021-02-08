using Kimerce.Backend.Infrastructure.Data.EntityMapping;
using Microsoft.EntityFrameworkCore;
using Kimerce.Backend.Infrastructure.Data.EntityMapping.EmployeeMap;
using Kimerce.Backend.Domain.Employees;

namespace Kimerce.Backend.Infrastructure.Data
{
    /// <summary>
    /// /DBContext 1 for employee api 
    /// </summary>
    public class KimDbContext : DbContext
    {
        public KimDbContext(DbContextOptions<KimDbContext> options)
            : base(options)
        {

        }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder
                .RegisterEntityMapping<Employee, EmployeeMap>();
        }
        

        

    }
}