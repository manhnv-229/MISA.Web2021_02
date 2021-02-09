using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.Common.Model
{
    /// <summary>
    /// Lưu trữ thông tin lỗi
    /// </summary>
    /// CreatedBy :NMDAT (03/02/2021)
    public class ErrorMsg
    {
        /// <summary>
        /// Thông tin lỗi gửi cho dev
        /// </summary>
        public string  DevMsg { get; set; }
        /// <summary>
        /// Thông tin lỗi gửi cho Người dùng lưu dưới dạng list để có thể lưu cùng lúc nhiều câu thông báo
        /// </summary>
        public List<string> UserMsg { get; set; } = new List<string>();
        /// <summary>
        /// Thông tin lỗi do team quy định
        /// </summary>
        public string ErrorCode { get; set; }
        /// <summary>
        /// Các thông tin lỗi khác
        /// </summary>
        public string MoreInfo { get; set; }
        /// <summary>
        /// TraceId
        /// </summary>
        public string TraceId { get; set; }
    }
}
