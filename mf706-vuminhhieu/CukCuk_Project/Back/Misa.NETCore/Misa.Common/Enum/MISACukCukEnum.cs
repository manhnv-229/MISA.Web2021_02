using System;
using System.Collections.Generic;
using System.Text;

namespace Misa.Common.Enum
{
     public enum MISACukCukServiceCode
    {
        /// <summary>
        /// Lỗi dữ liệu không hợp lệ
        /// </summary>
        BadRequest = 400,
        /// <summary>
        /// Thành công
        /// </summary>
        Success = 200,
        /// <summary>
        /// Lỗi ngoại lệ
        /// </summary>
        Exception = 500
    }
}
