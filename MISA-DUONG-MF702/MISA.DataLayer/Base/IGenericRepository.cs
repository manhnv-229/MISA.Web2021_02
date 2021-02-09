using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MISA.DataLayer.Base
{
    public interface IGenericRepository<TEntity>
    {
        //public IEnumerable<TEntity> GetData();
        //public IEnumerable<TEntity> GetData(string commandText);
        //public async Task<int> Insert(TEntity entity);
        public Task<IEnumerable<TEntity>> GetData();
        public Task<IEnumerable<TEntity>> GetData(string sql);
    }
}
