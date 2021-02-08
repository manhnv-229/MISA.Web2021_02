using FresherProject.Common.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace FresherProject.Common.Result
{
    public class ServiceResult
    {
        /// <summary>
        /// Dữ liệu được trả về
        /// </summary>
        public object Data { get; set; }
        /// <summary>
        /// Danh sách thông báo
        /// </summary>
        public List<string> Messenger { get; set; } = new List<string>();
        /// <summary>
        /// Mã kết quả
        /// </summary>
        public MISACukCukServiceCode MISACukCukCode { get; set; }
    }
}
