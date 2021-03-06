﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.Common.Model
{
    public class ErrorMsg
    {
        public string DevMsg { get; set; }
        public List<string> UserMsg { get; set; } = new List<string>();
        public string ErrorCode { get; set; }
        public string moreInfo { get; set; }
        public string traceId { get; set; }
    }
}
