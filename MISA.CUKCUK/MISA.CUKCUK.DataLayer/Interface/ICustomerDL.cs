using MISA.Common.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.DataLayer.Interface
{
    public interface ICustomerDL: IBaseDL<Customer>
    {
        //Check trùng ,ã khách hàng
        bool CheckCustomerCodeExisted(string customerCode);
        //Check trùng số điện thoại
        bool CheckPhoneNumberExisted(string phoneNumber);
    }
}
