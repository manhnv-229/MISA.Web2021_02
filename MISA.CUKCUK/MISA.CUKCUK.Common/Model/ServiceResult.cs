using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Common.Model
{
    public class ServiceResult
    {
        /// <summary>
        /// Mặc định Success là true
        /// CreatedBy VTThien 08/02/21
        /// </summary>
        public ServiceResult()
        {
            Success = true;
        }
         /// <summary>
         /// Trạng thái service/ true: thành công- fail- thất bại
         /// </summary>
        public bool Success { get; set; }
        /// <summary>
        /// Dữ liệu
        /// </summary>
        public object Data { get; set; }
        /// <summary>
        /// Mã MISA
        /// </summary>
        public string MISACode { get; set; }
    }
}
