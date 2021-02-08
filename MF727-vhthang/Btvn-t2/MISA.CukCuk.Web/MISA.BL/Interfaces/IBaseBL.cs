using MISA.Common.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.BL.Interfaces
{
    public interface IBaseBL<TEntity>
    {
        public IEnumerable<TEntity> GetAll();
        public ServiceResult Insert(TEntity entity);
        public ServiceResult Update(TEntity entity);
        public ServiceResult Delete(TEntity entity);
    }
}
