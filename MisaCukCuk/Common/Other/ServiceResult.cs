using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Other
{
    /// <summary>
    /// Kết quả trả về của tàng nghiệp vụ
    /// </summary>
    public class ServiceResult
    {
        #region Constructor
        public ServiceResult() {
            Success = true;
            StatusCode = Properties.Resources.SuccessedCode;
        }
        #endregion
        #region Property
        /// <summary>
        /// Trạng thái xử lý
        /// </summary>
        public bool Success { get; set; }
        /// <summary>
        /// Dữ liệu/ Thông báo lỗi trả về
        /// </summary>
        public object Data { get; set; }
        /// <summary>
        /// HTTP Status Code
        /// </summary>
        public string StatusCode { get; set; }
        #endregion
    }
}
