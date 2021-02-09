using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.Common.Models
{
    /// <summary>
    /// Mẫu dữ liệu trả về
    /// </summary>
    public class ActionServiceResult
    {
        public ActionServiceResult(){
            Success = true;
        }
        /// <summary>
        /// Trạng thái trả về (true: thành công; false: thất bại)
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        /// Thông báo trả về
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Mã Code trả về
        /// </summary>
        public EnumCodes MISACode { get; set; }

        /// <summary>
        /// Dữ liệu trả về
        /// </summary>
        public object Data { get; set; }
    }
}
