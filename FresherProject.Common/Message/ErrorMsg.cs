using System;
using System.Collections.Generic;
using System.Text;

namespace FresherProject.Common.Message
{
    public class ErrorMsg
    {
        public string DevMsg { get; set; }
        public List<string> UserMsg { get; set; }
        public string ErrorCode { get; set; }
        public string MoreInfo { get; set; }
        public string TraceId { get; set; }
    }
}
