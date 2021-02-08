using FresherProject.Common.Result;
using System;
using System.Collections.Generic;
using System.Text;

namespace FresherProject.Service.Interfaces
{
    public interface IBaseService<T>
    {
        ServiceResult GetAllData();
        ServiceResult GetById(Guid id);
        ServiceResult Insert(T t);
        ServiceResult GetAllData(string cmText);
        ServiceResult Update(T entity);
        ServiceResult Delete(Guid id);
    }
}
