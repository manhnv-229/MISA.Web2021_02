using System;

namespace Common.Other
{


    /// <summary>
    /// Attribute để xác định kiểm tra bắt buộc nhập
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class Required : Attribute
    {
        /// <summary>
        /// Tên của property
        /// </summary>
        public string PropertyName;

        /// <summary>
        /// Câu cảnh báo tùy chỉnh
        /// </summary>
        public string ErrorMessenger;
        public Required(string propertyName, string errorMessenger = null)
        {
            this.PropertyName = propertyName;
            this.ErrorMessenger = errorMessenger;
        }
    }

    /// <summary>
    /// Attribute để xác định kiểm tra trùng lặp
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class CheckExist : Attribute
    {
        /// <summary>
        /// Tên của property
        /// </summary>
        public string PropertyName;

        /// <summary>
        /// Câu cảnh báo tùy chỉnh
        /// </summary>
        public string ErrorMessenger;
        public CheckExist(string propertyName, string errorMessenger = null)
        {
            this.PropertyName = propertyName;
            this.ErrorMessenger = errorMessenger;
        }
    }
    
    /// <summary>
    /// Attribute để xác định kiểm tra định dạng số ( Số điện thoại, Số chứng minh thư nhân dân )
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class CheckNumberFormat : Attribute
    {
        /// <summary>
        /// Tên của property
        /// </summary>
        public string PropertyName;

        /// <summary>
        /// Câu cảnh báo tùy chỉnh
        /// </summary>
        public string ErrorMessenger;
        public CheckNumberFormat(string propertyName, string errorMessenger = null)
        {
            this.PropertyName = propertyName;
            this.ErrorMessenger = errorMessenger;
        }
    }
    /// <summary>
    /// Attribute để xác định kiểm tra định dạng Email
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class CheckEmailFormat : Attribute
    {
        /// <summary>
        /// Tên của property
        /// </summary>
        public string PropertyName;

        /// <summary>
        /// Câu cảnh báo tùy chỉnh
        /// </summary>
        public string ErrorMessenger;
        public CheckEmailFormat(string propertyName, string errorMessenger = null)
        {
            this.PropertyName = propertyName;
            this.ErrorMessenger = errorMessenger;
        }
    }
}
