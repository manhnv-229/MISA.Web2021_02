using System;
using System.Collections.Generic;
using System.Text;
using MISA.Common.Models;

namespace MISA.Service
{
    public interface IBaseService<TEntity>
    {
        public IEnumerable<TEntity> GetAll();
        public TEntity GetById(Guid id);
        public ServiceResult Insert(TEntity entity);
        public ServiceResult Update(Guid id, TEntity entity);
        public ServiceResult Delete(Guid id);
    }
}
