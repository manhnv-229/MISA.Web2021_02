#region

using Kimerce.Backend.Domain.BaseEntities;
using Kimerce.Backend.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//using Vina.Core.Domain.Entities.BaseEntities;
//using Vina.Core.Repository.Repositories;


#endregion

namespace Kimerce.Backend.Infrastructure.Repositories
{

    public class Repository<T> : IDisposable, IRepository<T> where T : BaseEntity
    {
        public Repository(KimDbContext context)
        {
            Context = context;
            DbSet = Context.Set<T>();
            _context = context;
        }

        protected KimDbContext Context { get; }
        private readonly KimDbContext _context;
        protected DbSet<T> DbSet { get; }


        public void Add(T entity)
        {
            
            DbSet.Add(entity);
        }



        public void Update(T entity)
        {
            DbSet.Update(entity);
        }

        public void UpdateMany(IEnumerable<T> entity)
        {
            DbSet.UpdateRange(entity);
        }


        public void Delete(T entity)
        {
            DbSet.Remove(entity);
        }

        public IDbContextTransaction BeginTransaction()
        {
            return Context.Database.BeginTransaction();
        }

        public void SaveChange()
        {
            Context.SaveChanges();
        }


        public async Task<int> SaveChangeAsync()
        {
            return await Context.SaveChangesAsync();
        }

        public IQueryable<T> Query()
        {
            //var a = "string";
            return DbSet.Where(e => !e.IsDeleted);
            //return DbSet.FromSqlRaw($"SELECT * FROM EMPLOYEES WHERE FULLNAME = '{a}'" );
        }
        public bool Duplicate(string propertyName, string propertyValue, string tableName)
        {
            var a = DbSet.FromSqlRaw($"SELECT * FROM {tableName} WHERE {propertyName} = '{propertyValue}'").FirstOrDefault();
            if (a != null)
            {
                return true;
            }
            else return false;
        }

        public IQueryable<T> QueryAll()
        {
            return DbSet;
        }

        public void Remove(T entity)
        {
            DbSet.Remove(entity);
        }
        public virtual void InsertMany(IEnumerable<T> entities)
        {
            if (entities == null)
                throw new ArgumentNullException(nameof(entities));

            try
            {
                DbSet.AddRange(entities);
                _context.SaveChanges();
            }
            catch (DbUpdateException exception)
            {
                //ensure that the detailed error text is saved in the Log
                throw new Exception(GetFullErrorTextAndRollbackEntityChanges(exception), exception);
            }
        }
        public virtual async Task<int> InsertAsync(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));
            int rs = 0;
            try
            {
                DbSet.Add(entity);
                rs = await _context.SaveChangesAsync();
                return rs;
            }
            catch (DbUpdateException exception)
            {
            }
            return rs;
        }
        public virtual async Task<int> InsertAsync(IEnumerable<T> entities)
        {
            if (entities == null)
                throw new ArgumentNullException(nameof(entities));
            int rs = 0;
            try
            {
                DbSet.AddRange(entities);
                rs = await _context.SaveChangesAsync();
                return rs;
            }
            catch (DbUpdateException exception)
            {
            }
            return rs;
        }

        public virtual async Task<int> UpdateAsync(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));
            int rs = 0;
            try
            {
                DbSet.Update(entity);
                rs = await _context.SaveChangesAsync();
                return rs;
            }
            catch (DbUpdateException exception)
            {
            }
            return rs;
        }
        public virtual async Task<int> UpdateAsync(IEnumerable<T> entities)
        {
            if (entities == null)
                throw new ArgumentNullException(nameof(entities));
            int rs = 0;
            try
            {
                DbSet.UpdateRange(entities);
                rs = await _context.SaveChangesAsync();
                return rs;
            }
            catch (DbUpdateException exception)
            {
            }
            return rs;
        }
        public virtual void Delete(IEnumerable<T> entities)
        {
            if (entities == null)
                throw new ArgumentNullException(nameof(entities));

            try
            {
                foreach (var item in entities)
                {
                    item.IsDeleted = true;
                }
                DbSet.RemoveRange(entities);
                Context.SaveChanges();
            }
            catch (DbUpdateException exception)
            {
            }
        }

        public virtual T GetById(object id)
        {
            return DbSet.Find(id);
        }
        public virtual async Task<T> GetByIdAsync(object id)
        {
            return await DbSet.FindAsync(id);
        }
        public virtual async Task<int> InsertManyAsync(IEnumerable<T> entities)
        {
            if (entities == null)
                throw new ArgumentNullException(nameof(entities));

            try
            {
                DbSet.AddRange(entities);
                var rs = await _context.SaveChangesAsync();
                return rs;
            }
            catch (DbUpdateException exception)
            {
                //ensure that the detailed error text is saved in the Log
                throw new Exception(GetFullErrorTextAndRollbackEntityChanges(exception), exception);
            }
        }
        public virtual async Task<int> DeleteAsync(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));
            try
            {
                entity.IsDeleted = true;
                DbSet.Update(entity);
                var rs = await _context.SaveChangesAsync();
                return rs;
            }
            catch (DbUpdateException exception)
            {
                //ensure that the detailed error text is saved in the Log
                throw new Exception(GetFullErrorTextAndRollbackEntityChanges(exception), exception);
            }
        }

        private string GetFullErrorTextAndRollbackEntityChanges(DbUpdateException exception)
        {
            //rollback entity changes
            if (Context is DbContext dbContext)
            {
                var entries = dbContext.ChangeTracker.Entries()
                    .Where(e => e.State == EntityState.Added || e.State == EntityState.Modified).ToList();

                entries.ForEach(entry => entry.State = EntityState.Unchanged);
            }

            Context.SaveChanges();
            return exception.ToString();
        }
        public void Dispose()
        {

        }
    }
}