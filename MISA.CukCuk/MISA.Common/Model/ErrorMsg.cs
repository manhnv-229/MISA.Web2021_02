using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Common.Model
{
    public class ErrorMsg
    {
        public string UserMsg { get; set; }
        public string DevMsg { get; set; }
        public string TraceId { get; set; }
        public string ErrorCode { get; set; }
        public string MoreInfo { get; set; }

    }
}
