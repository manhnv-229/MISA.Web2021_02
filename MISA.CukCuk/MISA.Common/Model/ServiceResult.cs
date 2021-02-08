using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Common.Model
{
    public class ServiceResult
    {
        /// <summary>
        /// Trạng thái Service (true - thành công; false - thất bại)
        /// </summary>
        public bool Success { get; set; } = true;

        /// <summary>
        /// Data trả về kèm theo
        /// </summary>
        public object Data { get; set; }

        /// <summary>
        /// MISACode
        /// </summary>
        public string MISACode { get; set; }
    }
}
