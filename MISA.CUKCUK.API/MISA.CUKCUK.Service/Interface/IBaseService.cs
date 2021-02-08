using MISA.Common.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Service.Interface
{
    public interface IBaseService<T>
    {
        ServiceResult GetAll();

        ServiceResult GetById(Guid id);
    }
}
