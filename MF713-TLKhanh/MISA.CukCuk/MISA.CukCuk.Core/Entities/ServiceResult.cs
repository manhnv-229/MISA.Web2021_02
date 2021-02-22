using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.CukCuk.Core.Entities
{
    public class ServiceResult
    {
        /// <summary>
        /// Dữ liệu trả về cho client
        /// </summary>
        public object Data { get; set; }
        /// <summary>
        /// ma trang thai tra ve cho client
        /// </summary>
        public int StatusCode { get; set; }
    }
}
