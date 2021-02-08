using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.Common.Model
{
    public class ErroMsg
    {
        public string DevMsg { get; set; }
        public string UserMsg { get; set; }
        public string ErrorCode { get; set; }
        public string MoreInfo { get; set; }
        public string TraceId { get; set; }

    }
}
