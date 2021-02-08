using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace MISA.DL.Interfaces
{
    public interface IDbContext<TEntity>
    {
        public IEnumerable<TEntity> GetData(string sqlCommand = null, object parameters = null, CommandType commandType = CommandType.Text);
        public int Insert(TEntity entity);
        public IEnumerable<TEntity> GetAll();
        public int Update(TEntity entity);
        public int Delete(TEntity entity);
    }
}
