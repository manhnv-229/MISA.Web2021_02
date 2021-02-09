using System;
using System.Collections.Generic;
using System.Text;
using MISA.Common.Model;
using MISA.DATALayer;
using MISA.DATALayer.Interface;
using MISA.Service.Interface;

namespace MISA.Service
{
    public class CustomerGroupService: BaseService<CustomerGroup>
    {
        public CustomerGroupService(IDbContext<CustomerGroup> _cutomerGroup): base(_cutomerGroup)
        {

        }
        protected override bool validateData(CustomerGroup entity, ErrorMsg errorMsg = null)
        {
            return true;
        }
    }
}
