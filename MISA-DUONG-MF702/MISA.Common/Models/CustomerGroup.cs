using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Common.Models
{
    public class CustomerGroup 
    {
        public Guid CustomerGroupId { get; set; }
        public string CustomerGroupName { get; set; }
        public string Description { get; set; }
    }
}
