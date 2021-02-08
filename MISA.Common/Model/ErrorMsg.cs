using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Common.Model
{
    /// <summary>
    /// Tin nhắn thông báo lỗi
    /// </summary>
    /// Createdby: PNVĐ (04/02/2021)
    public class ErrorMsg
    {
        #region Properties
        /// <summary>
        /// thông báo cho dev
        /// </summary>
        public string DevMsg { get; set; }
        /// <summary>
        /// thông báo cho người dùng
        /// </summary>
        public List<string> UserMsg { get; set; } = new List<string>();
        /// <summary>
        /// hỗ trợ dev tìm hiểu thêm thông tin về lỗi
        /// </summary>
        public string MoreInfo { get; set; }
        /// <summary>
        /// Để tra cứu thông tin log
        /// </summary>
        public string TraceId { get; set; }
        #endregion

    }
}
