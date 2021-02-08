using MISA.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Service.Interface
{
    public interface IBaseService<MISAEntity>
    {
        ServiceResult GetData(object param = null);
        ServiceResult Insert(MISAEntity misaEntity);
        ServiceResult Update(MISAEntity entity);
    }
}
