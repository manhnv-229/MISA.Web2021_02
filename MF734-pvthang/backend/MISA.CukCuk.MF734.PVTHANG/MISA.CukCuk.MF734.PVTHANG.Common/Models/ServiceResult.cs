using MISA.CukCuk.MF734.PVTHANG.Common.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.CukCuk.MF734.PVTHANG.Common.Models
{
    public class ServiceResult
    {
        public Object Data { get; set; }
        public String Message { get; set; }
        public ResultCode Code { get; set; }
    }
}
