using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Common
{
    /// <summary>
    /// Misacode để xác định trạng thái của dữ liệu:
    /// </summary>
    public enum MISACode
    {
        /// <summary>
        /// Dữ liệu hợp lệ
        /// </summary>
        IsValid = 100,

        /// <summary>
        /// Dữ liệu không hợp lệ
        /// </summary>
        NotValid = 900,

        /// <summary>
        /// Thành công
        /// </summary>
        Success = 200,

    }
}
