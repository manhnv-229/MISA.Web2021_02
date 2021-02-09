using MISA.Common.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Service.Interfaces
{
    public interface IBaseService<MISAEntity>
    {
        ServiceResult GetData();
        ServiceResult Insert(MISAEntity entity);
    }
}
