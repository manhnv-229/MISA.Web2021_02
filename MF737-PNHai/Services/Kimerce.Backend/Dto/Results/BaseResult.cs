using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Kimerce.Backend.Dto.Results
{
    public class BaseResult
    {
        /// <summary>
        /// Kết quả
        /// </summary>
        public Result Result { get; set; } = Result.Success;

        /// <summary>
        /// Thông điệp
        /// </summary>
        public string Message { get; set; } = "";

    }

    public enum Result
    {
        [Description("Thành công")]
        Success = 1,
        [Description("Thất bại")]
        Failed = 2,
        [Description("Lỗi hệ thống")]
        SystemError = 3
    }
}
