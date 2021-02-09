using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.Common.Models
{
    public class MISAAttribute
    {
    }
    /// <summary>
    /// Attribute bắt buộc nhập
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class Required:Attribute
    {
        /// <summary>
        /// Tên property
        /// </summary>
        public string PropertyName;
        /// <summary>
        /// Thông báo gặp lỗi
        /// </summary>
        public string ErrorMsg;
        public Required(string propertyName, string errorMsg = null)
        {
            this.PropertyName = propertyName;
            this.ErrorMsg = errorMsg;
        }
    }
    /// <summary>
    /// Attribute kiểm tra trùng dữ liệu
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class CheckDuplicate : Attribute
    {
        /// <summary>
        /// Tên property
        /// </summary>
        public string PropertyName;

        /// <summary>
        /// Thông báo gặp lỗi
        /// </summary>
        public string ErrorMsg;

        /// <summary>
        /// Kiểm tra trùng dữ liệu
        /// </summary>
        /// <param name="propertyName">Tên thuộc tính cần kiểm tra</param>
        /// <param name="errorMsg">Nội dung thông báo lỗi</param>
        /// CreatedBy: TXTrinh (02/02/2021)
        public CheckDuplicate(string propertyName, string errorMsg = null)
        {
            this.PropertyName = propertyName;
            this.ErrorMsg = errorMsg;
        }
    }

    /// <summary>
    /// Attribute kiểm tra độ dài dữ liệu
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class MaxLength : Attribute
    {
        /// <summary>
        /// Tên property
        /// </summary>
        public string PropertyName;

        /// <summary>
        /// Thong báo gặp lỗi
        /// </summary>
        public string ErrorMsg;

        /// <summary>
        /// Độ dài tối đa
        /// </summary>
        public int Length { get; set; }

        /// <summary>
        /// Kiểm tra độ dài tối đa
        /// </summary>
        /// <param name="propertyName">Tên thuộc tính cần kiểm tra</param>
        /// <param name="length">Độ dài tiêu chuẩn</param>
        /// <param name="errorMsg">Nội dung thông báo lỗi</param>
        /// CreatedBy: TXTrinh (02/02/2021)
        public MaxLength(string propertyName, int length, string errorMsg = null)
        {
            this.PropertyName = propertyName;
            this.ErrorMsg = errorMsg;
            Length = length;
        }
    }
}
