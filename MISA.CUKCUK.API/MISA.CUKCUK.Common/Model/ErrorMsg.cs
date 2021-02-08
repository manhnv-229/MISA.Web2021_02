using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Common.Model
{
    public class ErrorMsg
    {
        /// <summary>
        /// Câu thông báo cho DEV
        /// </summary>
        /// CreatedBy VTThien 08/02/21
        public string DevMsg { get; set; }
        /// <summary>
        /// Câu thông báo cho người dùng
        /// </summary>
        public string UserMsg { get; set; }
        /// <summary>
        /// Mã lỗi
        /// </summary>
        public string errorCode { get; set; }
        /// <summary>
        /// Thông tin liên hệ
        /// </summary>
        public string MoreInfo { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string TraceId { get; set; }
    }
}
