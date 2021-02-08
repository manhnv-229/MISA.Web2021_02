using System;
using System.Collections.Generic;
using System.Text;

namespace MisaCukCuk_Entity.Common
{
    public class ErrorMsg
    {
        /// <summary>
        /// Thông báo cho Dev
        /// </summary>
        public string DevMsg { get; set; }
        /// <summary>
        /// Thông báo co người dùng
        /// </summary>
        public List<string> UserMsg { get; set; } = new List<string>();
        /// <summary>
        /// Mã lỗi
        /// </summary>
        public string ErrorCode { get; set; }
        public string MoreInfo { get; set; }
        public string TraceId { get; set; }
    }
}
