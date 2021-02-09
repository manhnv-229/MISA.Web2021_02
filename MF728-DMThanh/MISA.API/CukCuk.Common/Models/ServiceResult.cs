using System;
using System.Collections.Generic;
using System.Text;

namespace CukCuk.Common.Models
{
    public class ServiceResult
    {
        /// <summary>
        /// Khởi tạo trạng thái Success 
        /// </summary>
        public ServiceResult()
        {
            Success = true;
        }
        /// <summary>
        /// Trạng thái của Service (true = thành công, false = thất bại)
        /// </summary>
        public bool Success { get; set; }
        /// <summary>
        /// Dữ liệu
        /// </summary>
        public object Data { get; set; }
        /// <summary>
        /// Mã Code
        /// </summary>
        public string MISACode { get; set; }

    }
}
