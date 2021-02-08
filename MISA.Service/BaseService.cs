using MISA.Common.Models;
using MISA.Service.interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Service
{
    public class BaseService<T> : IBaseService<T>
    {
        public ServiceResult DeleteEntityById<T>(string id)
        {
            throw new NotImplementedException();
        }

        public ServiceResult GetAllData<T>()
        {
            throw new NotImplementedException();
        }

        public ServiceResult InsertEntity<T>(T entity)
        {
            throw new NotImplementedException();
        }

        public ServiceResult ModifiedEntity<T>(T entity, string Id)
        {
            throw new NotImplementedException();
        }
    }
}
