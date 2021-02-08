using System;
using System.Collections.Generic;
using System.Text;

namespace CukCuk.Common.Models
{
    public class ServiceResult
    {
        /// <summary>
        /// Khởi tạo trạng thái success luôn bằng true
        /// </summary>
        public ServiceResult()
        {
            Success = true;
        }

        /// <summary>
        /// Trạng thái của Service (true - thành công, false - thất bại)
        /// </summary>
        public bool Success { get; set; }
        public object Data { get; set; }
        public string MISACode { get; set; }

    }
}
