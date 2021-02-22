using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.CukCuk.core.Entities
{
    public static class MisaCode
    {
        /// <summary>
        /// Thanh cong
        /// </summary>
        public static int Success { get; set; } = 200;
        /// <summary>
        /// khong co du lieu
        /// </summary>
        public static int NoContent { get; set; } = 204;
        /// <summary>
        /// bad request
        /// </summary>
        public static int BadRequest { get; set; } = 400;
        /// <summary>
        /// khong tim thay
        /// </summary>
        public static int NotFound { get; set; } = 404;
        /// <summary>
        /// tao moi
        /// </summary>
        public static int Created { get; set; } = 201;
        /// <summary>
        /// loi server
        /// </summary>
        public static int ServerError { get; set; } = 500;
    }
}
