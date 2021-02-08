using MISA.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.DL.Interfaces
{
    public interface ICustomerDL
    {

        public IEnumerable<Customer> CheckDuplicate(string name, string value);
        
    }
}
