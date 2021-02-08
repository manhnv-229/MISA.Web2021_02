using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kimerce.Backend.Infrastructure.Repositories
{
    public interface IMisaRepository<T> where T : class
    {
        IQueryable<T> Query();
    }
}
