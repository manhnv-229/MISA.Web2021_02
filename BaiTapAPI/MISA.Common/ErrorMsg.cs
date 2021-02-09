using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Common
{
    public class ErrorMsg
    {
        public string DevMsg { get; set; }
        public string UserMsg { get; set; }
        public string ErrorCode { get; set; }
        public string MoreInfo { get; set; }
        public string TraceId { get; set; }
    }
}
