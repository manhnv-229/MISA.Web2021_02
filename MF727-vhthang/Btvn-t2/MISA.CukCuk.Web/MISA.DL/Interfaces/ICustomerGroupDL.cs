using MISA.CukCuk.Web.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.DL.Interfaces
{
    public interface ICustomerGroupDL
    {
        public IEnumerable<CustomerGroup> CheckDuplicate(string name, string value);
    }
}
