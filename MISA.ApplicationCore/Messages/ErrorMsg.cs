using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.ApplicationCore.Messages
{
    public class ErrorMsg
    {
        #region Property
        public List<string> devMsg { get; set; } = new List<string>();
        public List<string> userMsg { get; set; } = new List<string>();
        public string errorCode { get; set; }
        public string moreInfo { get; set; }
        public string traceId { get; set; }
        public bool success { get; set; }
        #endregion
    }
}
