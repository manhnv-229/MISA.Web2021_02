using Misa.CukCuk.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Misa8b.CukCuk.DL.Interfaces
{
    public interface ICustomerDL:IBaseDL<Customer>
    {
        public List<Customer> GetCustomerByOthers(string customercode, string fullname, string phonenumber);
    }
}
