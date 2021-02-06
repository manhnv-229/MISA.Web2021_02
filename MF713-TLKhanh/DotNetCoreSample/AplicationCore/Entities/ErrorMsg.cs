using System;
using System.Collections.Generic;
using System.Text;

namespace AplicationCore.Entities
{
    public class ErrorMsg
    {
        /// <summary>
        /// Thông báo cho dev
        /// </summary>
        public string DevMsg { get; set; }
        /// <summary>
        /// Thông báo cho người dùng
        /// </summary>
        public List<string> UserMsg { get; set; } = new List<string>();
        /// <summary>
        /// Mã lỗi
        /// </summary>
        public string ErrorCode { get; set; }
        /// <summary>
        /// Thông tin thêm
        /// </summary>
        public string MoreInfo { get; set; }
        /// <summary>
        /// Trace id
        /// </summary>
        public string TraceId { get; set; }
    }
}
