using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.DataLayer
{
    public interface IDbContext<TEntity>
    {
        public IEnumerable<TEntity> GetAll();
        public IEnumerable<TEntity> GetData(string commandText);
        public TEntity GetById(object id);
        public int Insert(TEntity entity);
        public int Update(TEntity entity,Guid id);

        public int Delete(object id);
    }
}
