using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Common.Model
{
    /// <summary>
    /// trạng thái Service (thành công: true - lỗi: false)
    /// </summary>
    public class ServiceResult
    {
        #region Contructor
        public ServiceResult()
        {
            Success = true;
        }
        #endregion

        #region DECLARE
        /// <summary>
        /// kết quả thành công hay có lỗi
        /// </summary>
        public Boolean Success { get; set; }
        /// <summary>
        /// hiển thị câu thông báo khi thành công hay lỗi
        /// </summary>
        public object Data { get; set; }
        public string MisaCode { get; set; }
        #endregion
    }
}
