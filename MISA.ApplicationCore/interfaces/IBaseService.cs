using MISA.ApplicationCore.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.ApplicationCore.interfaces
{
    public interface IBaseService
    {
        ServiceResult GetData<T>();
    }
}
