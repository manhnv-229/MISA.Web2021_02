using System;
using System.Collections.Generic;
using System.Text;

namespace AplicationCore.Entities
{
    public class ServiceResult
    {
        /// <summary>
        /// Trạng thái của service True = thành công , false = thất bại
        /// </summary>
        public bool Success { get; set; }
        /// <summary>
        /// Dữ liệu trả về cho client
        /// </summary>
        public object Data { get; set; }
        /// <summary>
        /// Mã code nội bộ
        /// </summary>
        public string Misacode { get; set; }
    }
}
