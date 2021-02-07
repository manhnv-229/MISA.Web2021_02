using MISA.DataLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace MISA.DataLayer.DbContext2
{
    public class DbContextV2<TEntity> : IDbContext<TEntity>
    {

        public int Delete(string entityId)
        {
            return 0;
        }

        public IEnumerable<TEntity> GetAll(string query = null, object param = null, CommandType cmdType = CommandType.Text)
        {
            IEnumerable<TEntity> list = new List<TEntity>();
            return list;
        }

        public int Insert(TEntity entity)
        {
            return 1;
        }

        public int Put(TEntity entity)
        {
            return 1;
        }
    }
}
