using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Common.Model
{
    /// <summary>
    /// MisaCode convention
    /// </summary>
    /// CreatedBy: NMDAT(09/02/2021)
    public enum MISACode
    {
        /// <summary>
        /// Thành công
        /// </summary>
        Success = 200,
        /// <summary>
        /// Validate không có lỗi
        /// </summary>
        IsValid = 100,
        /// <summary>
        /// Validate thất bại
        /// </summary>
        NotValid = 900

    }
}
