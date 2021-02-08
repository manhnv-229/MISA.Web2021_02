using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Other
{
    /// <summary>
    /// 
    /// </summary>
    public class ErrMsg
    {
        #region Constructor
        public ErrMsg()
        {
             UserMsg = new List<string>();
        }
        #endregion
        #region Property
       /// <summary>
       /// Thông báo cho Dev
       /// </summary>
       public string DevMsg { get; set; }
        /// <summary>
        /// Thông báo cho người dùng cuối
        /// </summary>
        public List<string> UserMsg { get; set; }
        /// <summary>
        /// Mã lỗi nội bộ
        /// </summary>
        public string ErrorCode { get; set; }
        /// <summary>
        /// Thêm thông tin về lỗi
        /// </summary>
        public string MoreInfo { get; set; }
        /// <summary>
        /// TraceId
        /// </summary>
        public string TraceId { get; set; }
        #endregion
    }
}
