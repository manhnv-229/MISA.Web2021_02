using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.BTL.Common
{
    public class ErrorMsg
    {
        /// <summary>
        /// Lời nhắn cho lập trình viên
        /// </summary>
        public string DevMsg { get; set; }

        /// <summary>
        /// Lời nhắn cho người dùng
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
        public string TraceId { get; set; }
    }
}
