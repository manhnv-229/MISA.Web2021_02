using System;
using System.Collections.Generic;
using System.Text;

namespace Misa.Common.Requests.Employee
{
    public class PageRequest :PageRequestBase
    {
        public string KeyWord { get; set; }
        public string DepartmentId { get; set; }
        public string PositionId { get; set; }

        public PageRequest() : base()
        {
            ;
        }
    }
}
