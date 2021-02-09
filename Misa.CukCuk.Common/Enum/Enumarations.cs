using System;
using System.Collections.Generic;
using System.Text;

namespace Misa.CukCuk.Common.Enum
{
    public class Enumarations
    {
        /// <summary>
        /// Mã code của Misa tự định nghĩa
        /// </summary>
        /// created by Trần Đức Toản
        public enum MisaCode
        {
            /// <summary>
            /// Thành công
            /// </summary>
            Success = 200,
            /// <summary>
            /// Lỗi bên client
            /// </summary>
            Validate = 400,
            /// <summary>
            /// Lỗi bên server 
            /// </summary>
            Error = 500,
            /// <summary>
            /// Lỗi ngoại lệ
            /// </summary>
            Exception = 1000,
        }
        /// <summary>
        /// Định nghĩa giới tính
        /// </summary>
        public enum Gender
        {
            Male = 1,
            Female = 0,
            Other = 2
        }
    }
}
