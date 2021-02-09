using Misa.Common.Enum;
using Misa.Common.Results;
using System.Collections.Generic;

namespace Misa.Common
{
    public class ServiceResult
    {
        /// <summary>
        /// dữ liệu trả về
        /// </summary>
        public object Data { get; set; }
        /// <summary>
        /// thông tin lỗi
        /// </summary>
        public List<ErrorResult> Error { get; set; }

        /// <summary>
        /// Mã kết quả
        /// </summary>
        public MISACukCukServiceCode MISACukCukCode { get; set; }
        public ServiceResult()
        {
            Error = new List<ErrorResult>();
        }
    }
}
