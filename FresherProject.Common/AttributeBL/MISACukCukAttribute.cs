using System;
using System.Collections.Generic;
using System.Text;

namespace FresherProject.Common.AttributeBL
{
    public class MISACukCukAttribute
    {
    }
    /// <summary>
    /// Attribute để xác định check bắt buộc nhập
    /// </summary>
    /// Created by: Ngọc (3/1/2021)
    [AttributeUsage(AttributeTargets.Property)]
    public class Required:Attribute
    {
        /// <summary>
        /// Tên của property
        /// </summary>
        public string PropertyName;
        /// <summary>
        /// Câu thông báo tùy chỉnh
        /// </summary>
        public string ErrorMessenger;
        public Required(string propertyName, string errorMessenger = null)
        {
            this.PropertyName = propertyName;
            this.ErrorMessenger = errorMessenger;
        }
    }
    /// <summary>
    /// Attribute để xác định check trùng
    /// </summary>
    /// Created by: Ngọc (3/1/2021)
    [AttributeUsage(AttributeTargets.Property)]
    public class CheckDuplicate : Attribute
    {
        /// <summary>
        /// Tên của property
        /// </summary>
        public string PropertyName;
        /// <summary>
        /// Câu thông báo tùy chỉnh
        /// </summary>
        public string ErrorMessenger;
        public CheckDuplicate(string propertyName, string errorMessenger = null)
        {
            this.PropertyName = propertyName;
            this.ErrorMessenger = errorMessenger;
        }
    }
    /// <summary>
    /// Attribute để giới hạn chiều dài của trường dữ liệu
    /// </summary>
    /// Created by: Ngọc (3/1/2021)
    [AttributeUsage(AttributeTargets.Property)]
    public class MaxLength : Attribute
    {
        /// <summary>
        /// Tên của property
        /// </summary>
        public string PropertyName;
        /// <summary>
        /// Câu thông báo tùy chỉnh
        /// </summary>
        public string ErrorMessenger;
        /// <summary>
        /// Độ dài tối đa được phép
        /// </summary>
        public int Length { get; set; }
        public MaxLength(string propertyName, int lenght, string errorMessenger = null)
        {
            this.PropertyName = propertyName;
            this.ErrorMessenger = errorMessenger;
            Length = lenght;
        }
    }
}
