using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.ApplicationCore.Messages
{
    public class ServiceResult
    {
        #region Property
        public bool Success { get; set; } = true;
        public object Data { get; set; }
        public string MISACode { get; set; }
        #endregion
    }
}
