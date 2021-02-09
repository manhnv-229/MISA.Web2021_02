using System;
using System.Collections.Generic;
using System.Text;
using static Misa.CukCuk.Common.Enum.Enumarations;

namespace Misa8b.CukCuk.BL.Result
{
    /// <summary>
    /// Định nghĩa kết quả trả về của tầng service
    /// </summary>
    public class ActionServiceResult
    {
        /// <summary>
        /// Check xem kết quả có lỗi hay không ?
        /// </summary>
        public bool Success { get; set; }
        /// <summary>
        /// Chi tiết lỗi hoặc trạng thái
        /// </summary>
        public string Message { get; set; }
        /// <summary>
        /// Mã code được quy chuẩn
        /// </summary>
        public MisaCode MisaCode { get; set; }
        /// <summary>
        /// Dữ liệu kết quả trả về
        /// </summary>
        public object Data { get; set; }
    }
}
