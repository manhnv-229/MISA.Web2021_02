using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.Common.Enum
{
    public enum EnumPattern
    {
        /// <summary>
        /// Lỗi dữ liệu không hợp lệ
        /// </summary>
        BadRequest = 400,
        /// <summary>
        /// request dữ liệu thành công
        /// </summary>
        Success = 200,
        /// <summary>
        /// Có lỗi xảy ra phía máy chủ
        /// </summary>
        Exception = 500,
        /// <summary>
        /// Tạo dữ liệu thành công
        /// </summary>
        Created =  200,
        /// <summary>
        /// Hệ thống chưa được ủy quyền
        /// </summary>
        UnAuthorzed = 401,
        /// <summary>
        /// Máy chủ từ chối yêu cầu 
        /// </summary>
        Forbidden = 403,

    }
    
    /// <summary>
    /// Định dạnh giới tính 0: Nam, 1 Nữ , 2 : Khác
    /// </summary>
    public enum Gender // 
    {
        Male = 0,
        Female = 1,
        Other = 2
    }
}
