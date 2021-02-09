using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.Common.Models
{
    #region Constructor
    public class AttributeDefine
    {
    }
    #endregion
    #region Class
    /// <summary>
    /// Attribute check bắt buộc nhập
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class Required : Attribute
    {
        /// <summary>
        /// tên của property 
        /// </summary>
        public string PropertyName;
        /// <summary>
        /// thông báo lỗi khi chưa nhập property bắt buộc
        /// </summary>
        public string ErrorMessenger;
        public Required(string propertyName, string errorMessenger = null)
        {
            this.PropertyName = propertyName;
            this.ErrorMessenger = errorMessenger;
        }
    }
    /// <summary>
    /// kiểm tra lỗi khi dữ liệu bị trùng
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class CheckDuplicate : Attribute
    {
        /// <summary>
        /// tên của property 
        /// </summary>
        public string PropertyName;
        /// <summary>
        /// thông báo lỗi khi bị trùng data
        /// </summary>
        public string ErrorMessenger;
        public CheckDuplicate(string propertyName, string errorMessenger = null)
        {
            this.PropertyName = propertyName;
            this.ErrorMessenger = errorMessenger;
        }
    }
    [AttributeUsage(AttributeTargets.Property)]
    public class MaxLength : Attribute
    {
        /// <summary>
        /// tên của property 
        /// </summary>
        public string PropertyName;
        /// <summary>
        /// thông báo lỗi khi bị trùng data
        /// </summary>
        public string ErrorMessenger;
        /// <summary>
        /// Độ dài tối đa
        /// </summary>
        public int Length;
        public MaxLength(string propertyName,int maxLength, string errorMessenger = null)
        {
            this.PropertyName = propertyName;
            this.ErrorMessenger = errorMessenger;
            this.Length = maxLength;
        }
    }
    #endregion
}
