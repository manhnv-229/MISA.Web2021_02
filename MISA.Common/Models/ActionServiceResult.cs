using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.DEMO.API.Models
{
    public class ActionServiceResult
    {
        /// <summary>
        /// Trả về trạng thái (true: thành công, false: lỗi)
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        /// Thông báo đi kèm
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Dữ liệu trả về
        /// </summary>
        public object Data { get; set; }

        /// <summary>
        /// Mã code trả về
        /// </summary>
        public int MISACode { get; set; }
    }
}

