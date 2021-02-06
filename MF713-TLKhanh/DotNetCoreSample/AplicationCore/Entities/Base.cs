using System;
using System.Collections.Generic;
using System.Text;

namespace AplicationCore.Entities
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
