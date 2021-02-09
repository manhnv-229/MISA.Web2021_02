using MISA.Common.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Service.Interface
{
    public interface IBaseService<MisaEntity>
    {
        ServiceResult GetData();
        ServiceResult Insert(MisaEntity entity);
    }
}
