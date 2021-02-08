using System;

namespace Misa.Common.Entities
{
    public class MisaAttribute: Attribute
    {
        /// <summary>
        /// Tên của property
        /// </summary>
        public  string PropertyName { get; set; }
        /// <summary>
        /// Câu cảnh báo tùy chỉnh
        /// </summary>
        public string ErrorMessenger { get; set; }

        public MisaAttribute(string propertyName, string errorMessenger = null)
        {
            this.PropertyName = propertyName;
            this.ErrorMessenger = errorMessenger;
        }
    }
    [AttributeUsage(AttributeTargets.Property)]
    public class Required : MisaAttribute
    {
        public Required(string propertyName=null, string errorMessenger = null) : base(propertyName, errorMessenger)
        {
            ;
        }
    }
    [AttributeUsage(AttributeTargets.Property)]
    public class MaxLength : MisaAttribute
    {
        /// <summary>
        /// Kích thước tối đa của property
        /// </summary>
        public int Length { get; set; }

        public MaxLength(int length, string propertyName = null,  string errorMessenger = null): base(propertyName, errorMessenger)
        {
            this.Length = length;
        }
    }

    public class FixLength : MisaAttribute
    {
        /// <summary>
        /// Kích thước cố định của property
        /// </summary>
        public int Length { get; set; }

        public FixLength(int length, string propertyName = null, string errorMessenger = null) : base(propertyName, errorMessenger)
        {
            this.Length = length;
        }
    }
}
