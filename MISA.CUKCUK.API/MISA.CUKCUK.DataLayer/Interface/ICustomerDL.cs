using MISA.Common.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.DataLayer.Interface
{
    public interface ICustomerDL: IBaseDL<Customer>
    {
        bool CheckCustomerCodeExisted(string customerCode);

        bool CheckPhoneNumberExisted(string phoneNumber);
    }
}
