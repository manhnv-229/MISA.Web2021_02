using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.Common.Model
{
    public class ServiceResult
    {
        public ServiceResult()
        {
            Success = true;
        }
        /// <summary>
        /// Trạng thái Service (true - thành công; falise - thất bại)
        /// </summary>
        public bool Success { get; set; }
        public object Data { get; set; }
        public string MISACode { get; set; }
    }
}
