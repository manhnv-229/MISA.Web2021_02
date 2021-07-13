using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.CukCuk.Core.Entities
{
    public static class MisaCode
    {
        /// <summary>
        /// Thành công
        /// </summary>
        public static int Success { get; set; } = 200;
        /// <summary>
        /// Không có dữ liệu trả về
        /// </summary>
        public static int NoContent { get; set; } = 204;
        /// <summary>
        /// bad request
        /// </summary>
        public static int BadRequest { get; set; } = 400;
        /// <summary>
        /// Không tìm thấy
        /// </summary>
        public static int NotFound { get; set; } = 404;
        /// <summary>
        /// Tạo mới một bản ghi
        /// </summary>
        public static int Created { get; set; } = 201;
        /// <summary>
        /// Lỗi server
        /// </summary>
        public static int ServerError { get; set; } = 500;
    }
}
