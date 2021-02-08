using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.CukCuk.MF734.PVTHANG.Common.Models
{
    public class Attribute
    {
    }

    [AttributeUsage(AttributeTargets.Property)]
    public class Required : System.Attribute
    {
        public String propertyName;
        public String errorMessage;
        public Required(String propertyName, String errorMessage = null)
        {
            this.propertyName = propertyName;
            this.errorMessage = errorMessage;
        }
    }

    [AttributeUsage(AttributeTargets.Property)]
    public class CheckDuplicate : System.Attribute
    {
        public String propertyName;
        public String errorMessage;
        public CheckDuplicate(String propertyName, String errorMessage = null)
        {
            this.propertyName = propertyName;
            this.errorMessage = errorMessage;
        }
    }
}
