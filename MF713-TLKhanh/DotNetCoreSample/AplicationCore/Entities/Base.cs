using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.CukCuk.core.Entities
{
    [AttributeUsage(AttributeTargets.Property)]
    public class Required : Attribute
    {

    }
    [AttributeUsage(AttributeTargets.Property)]
    public class Unique : Attribute
    {

    }
    public class Base
    {
    }
}
