using System;
using System.Collections.Generic;
using System.Text;
using MISA.BTL.Common;

namespace MISA.BTL.Business.Interfaces
{
    public interface IBaseBusiness<T>
    {
        ServiceResult Insert(T entity);
        ServiceResult GetData();
        ServiceResult Update(T entity);
        ServiceResult Delete(string id);
    }
}
