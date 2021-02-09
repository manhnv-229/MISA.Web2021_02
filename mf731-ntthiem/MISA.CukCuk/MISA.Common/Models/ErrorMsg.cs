using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.Common.Models
{
    /// <summary>
    /// Thông báo lỗi
    /// CreatedBy: NTTHIEM
    /// CreatedDate: 07/02/2021
    /// </summary>
    public class ErrorMsg
    {
        /// <summary>
        /// Thông báo cho Lập trình viên
        /// </summary>
        public string DevMsg { get; set; }

        /// <summary>
        /// Thông báo cho người dùng
        /// </summary>
        public List<string> UserMsg { get; set; } = new List<string>();

        /// <summary>
        /// Thông báo code
        /// </summary>
        public string ErrorCode { get; set; }

        /// <summary>
        /// Thông tin thêm
        /// </summary>
        public string MoreInfo { get; set; }

        /// <summary>
        /// TraceId
        /// </summary>
        public string TraceId { get; set; }

    }
}
