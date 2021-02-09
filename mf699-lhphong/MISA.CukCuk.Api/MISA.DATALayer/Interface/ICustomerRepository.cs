using MISA.Common.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.DATALayer.Interface
{
    public interface ICustomerRepository: IDbContext<Customer> 
    {
        public bool checkCustomerCodeExits(string customerCode);
        public bool checkPhoneNumberExits(string phoneNumber);
    }
}
