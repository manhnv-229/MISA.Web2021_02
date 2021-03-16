using System;
using System.Collections.Generic;
using System.Text;

namespace Common
{
    public class ErrorMessenger
    {
        public string  DevMsg { get; set; }
        public List<string> UserMsg { get; set; } = new List<String>();
        public string  ErrorCode { get; set; }
        public string MoreInfo { get; set; }
        public string TraceId { get; set; }
    }
}
