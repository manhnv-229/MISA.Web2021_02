using MISA.CukCuk.MF734.PVTHANG.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.CukCuk.MF734.PVTHANG.Service.Interfaces
{
    public interface IBaseService<TEntity>
    {
        ServiceResult GetAll();
        ServiceResult GetById(String id);
        ServiceResult Insert(TEntity entity);
        public ServiceResult Update(TEntity entity);
        public ServiceResult Delete(String id);
    }
}
