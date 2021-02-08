using Microsoft.EntityFrameworkCore.Storage;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kimerce.Backend.Infrastructure.Repositories
{

    public interface IRepository<T> where T : class
    {
        IQueryable<T> Query();
        IQueryable<T> QueryAll();
        bool Duplicate(string propertyName, string propertyValue, string tableName);
        void Add(T entity);
        void Update(T entity);
        void UpdateMany(IEnumerable<T> entity);
        void Delete(T entity);
        IDbContextTransaction BeginTransaction();
        void SaveChange();
        Task<int> SaveChangeAsync();
        void Remove(T entity);
        Task<int> InsertAsync(T entity);
        Task<int> InsertAsync(IEnumerable<T> entities);
        Task<int> UpdateAsync(T entity);
        Task<int> UpdateAsync(IEnumerable<T> entities);
        void Delete(IEnumerable<T> entities);
        T GetById(object id);
        Task<T> GetByIdAsync(object id);
        void InsertMany(IEnumerable<T> entities);
        Task<int> InsertManyAsync(IEnumerable<T> entity);
        Task<int> DeleteAsync(T entity);
    }

}

