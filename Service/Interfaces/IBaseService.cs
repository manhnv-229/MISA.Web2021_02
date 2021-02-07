using Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Service.Interfaces
{
    public interface IBaseService<TEntity>
    {
        public ServiceResult Get();
        public ServiceResult Post(TEntity entity);
        public ServiceResult Delete(string entityId);
        public ServiceResult Put(TEntity entity, string entityCode = null);

    }
}
