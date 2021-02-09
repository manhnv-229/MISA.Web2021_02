using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static MISA.Common.Model.Enumarations;

namespace MISA.Common.Model
{
    public class ActionServiceResult
    {
        /// <summary>
        /// Trạng thái Service
        /// </summary>
        public bool Success { get; set; } = true;
        public string Message { get; set; }
        public MISACode MISACode { get; set; }
        public object data { get; set; }
    }
}
