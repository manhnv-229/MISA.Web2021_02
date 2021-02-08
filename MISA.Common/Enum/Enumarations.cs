using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.Common.Models
{
    public enum EnumCodes
    {
        /// <summary>
        /// Lỗi dữ liệu
        /// </summary>
        BadRequest = 400,
        /// <summary>
        /// Thao tác dữ liệu thành công
        /// </summary>
        Success = 200,
        /// <summary>
        /// Thêm mới, sửa bản ghi thành công
        /// </summary>
        Created = 201,
        /// <summary>
        /// Lỗi ngoại lệ
        /// </summary>
        Exception = 500
    }
    public enum Gender
    {
        /// <summary>
        /// Nam
        /// </summary>
        Male = 1,
        /// <summary>
        /// Nữ
        /// </summary>
        Female = 0,
        /// <summary>
        /// Khác
        /// </summary>
        Other = 2
    }
}
