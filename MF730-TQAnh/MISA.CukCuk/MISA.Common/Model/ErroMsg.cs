using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.Common.Model
{
    /// <summary>
    /// thông tin lỗi 
    /// CreatedBy: TQAnh (07/02/2021)
    /// </summary>

    public class ErroMsg
    {
        /// <summary>
        /// tin nhắn thông báo cho lập trình viên
        /// </summary>
        public string DevMsg { get; set; }

        /// <summary>
        /// tin nhắn thông báo cho người dùng
        /// </summary>
        public List<string> UserMsg { get; set; } = new List<string>();

        /// <summary>
        /// mã lỗi
        /// </summary>
        public string ErrorCode { get; set; }

        public string MoreInfo { get; set; }
        public string TraceId { get; set; }
    }
}
