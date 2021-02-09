
using MISA.Common.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.Common.Models
{
    public class ServiceResult
    {
        /// <summary>
        /// Data
        /// </summary>
        public object Data { get; set; }
        /// <summary>
        /// Thông báo cho người dùng
        /// </summary>
        public List<string> userMsg { get; set; } = new List<string>();
        /// <summary>
        /// Thông báo cho Dev
        /// </summary>
        public List<string> devMsg { get; set; } = new List<string>();
        /// <summary>
        ///mã kết quả
        /// </summary>
        public EnumPattern Code { get; set; }
        /// <summary>
        /// Thông tin thêm về lỗi khi xảy ra
        /// </summary>
        public string moreInfo { get; set; }
        /// <summary>
        /// Id trong serve log khi muốn tra lỗi
        /// </summary>
        public string traceId { get; set; }
    }
}
