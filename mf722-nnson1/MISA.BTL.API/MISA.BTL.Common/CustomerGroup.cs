using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.BTL.Common
{
    public class CustomerGroup
    {
        //Id nhóm khách hàng
        public Guid CustomerGroupId { get; set; }
        public string Id { get { return CustomerGroupId.ToString(); } }

        //Tên nhóm khách hàng
        public string CustomerGroupName { get; set; }

        //Mô tả
        public string Description { get; set; }
    }
}
