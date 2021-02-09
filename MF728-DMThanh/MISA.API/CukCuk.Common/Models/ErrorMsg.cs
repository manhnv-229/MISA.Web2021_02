using System;
using System.Collections.Generic;
using System.Text;

namespace CukCuk.Common.Models
{
    /// <summary>
    /// Thông báo lỗi
    /// </summary>
    public class ErrorMsg
    {
        /// <summary>
        /// Thông báo cho lập trình viên
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
        /// Mã theo dõi
        /// </summary>
        public string TraceId { get; set; }
    }
}
