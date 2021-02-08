using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Common.Models
{
    public class ErrorMsg
    {
        /// <summary>
        /// Thông báo của dev
        /// </summary>
        public string DevMsg { get; set; }

        /// <summary>
        /// Thông báo cho người dùng
        /// </summary>
        public List<string> UserMsg { get; set; } = new List<string>();

        /// <summary>
        /// Mã code lỗi
        /// </summary>
        public string ErrorCode { get; set; }

        /// <summary>
        /// Thông tin thêm
        /// </summary>
        public string MoreInfo { get; set; }

        /// <summary>
        /// Truy vết Id
        /// </summary>
        public string TraceId { get; set; }
    }
}
