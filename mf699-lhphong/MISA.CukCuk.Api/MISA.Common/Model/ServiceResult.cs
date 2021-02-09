using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Common.Model
{
    public class ServiceResult
    {
        public bool Success { get; set; }
        public object Data { get; set; }
        public string MisaCode { get; set; }
    }
}
