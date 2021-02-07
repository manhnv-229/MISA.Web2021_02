using System;
using System.Collections.Generic;
using System.Text;

namespace Common
{
    public class ServiceResult
    {
        /// <summary>
        /// thực hiện thành công/thất bại
        /// </summary>
        /// <return>true: thực hiện thành công; false: thực hiện thất bại</return>
        public bool Success { get; set; }

        /// <summary>
        /// dữ liệu trả về đi kèm với từng trạng thái thực hiện code
        /// </summary>
        public object Data { get; set; }

        public string MisaCode { get; set; }
    }
}
