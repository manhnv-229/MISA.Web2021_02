using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Common.Model
{
    public class CustomerGroup
    {
        public Guid CustomerGroupId { get; set; }
        public string CustomerGroupName { get; set; }
        public string Description { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
    }
}
