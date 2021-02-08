using System;
using System.Linq;

namespace Kimerce.Backend.Infrastructure.Helpers
{
    public static class EnumHelper
    {
        public static string GetDescription(this Enum value)
        {
            if (value != null)
            {
                // get attributes  
                var field = value.GetType().GetField(value.ToString());
                if (field == null) return value + "Không có mô tả";
                var attributes = field.GetCustomAttributes(false);

                // Description is in a hidden Attribute class called DisplayAttribute
                // Not to be confused with DisplayNameAttribute
                dynamic displayAttribute = null;

                var enumerable = attributes as Attribute[] ?? attributes.ToArray();
                if (enumerable.Any())
                {
                    displayAttribute = enumerable.ElementAt(0);
                }

                // return description
                return displayAttribute?.Description ?? "Không có mô tả";
            }
            return "";
        }



    }
}
