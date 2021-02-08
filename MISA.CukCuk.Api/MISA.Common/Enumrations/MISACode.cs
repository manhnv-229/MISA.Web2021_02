using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Common.Enumrations
{   
    /// <summary>
    /// Mã lỗi MISA
    /// </summary>
    /// CreatedBy: NQDAT (07/02/2021)
    public enum MISACode
    {
        /// <summary>
        /// Thành công
        /// </summary>
        Success = 200,

        /// <summary>
        /// Thêm bản ghi thành công
        /// </summary>
        Created = 201,

        /// <summary>
        /// Dữ liệu trả về rỗng
        /// </summary>
        NoContent = 204,

        /// <summary>
        /// Dữ liệu không hợp lệ
        /// </summary>
        BadRequest = 400,

        /// <summary>
        /// Không tìm thấy trang yêu cầu
        /// </summary>
        NotFound = 404,

        /// <summary>
        /// Lỗi server
        /// </summary>
        ServerError = 500
    }
}
