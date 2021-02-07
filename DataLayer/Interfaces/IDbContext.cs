using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace MISA.DataLayer.Interfaces
{
    public interface IDbContext<TEntity>
    {
        public IEnumerable<TEntity> GetAll(string query = null, object param = null, CommandType cmdType = CommandType.Text);
        public int Insert(TEntity entity);
        public int Delete(string entityId);
        public int Put(TEntity entity);
    }
}
