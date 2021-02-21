using MISA.Common.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.DataLayer.Interface
{
    public interface ICustomerDL: IBaseDL<Customer>
    {
        /// <summary>
        /// Check trùng mã khách hàng
        /// </summary>
        /// <param name="customerCode"></param>
        /// <returns></returns>
        /// CreatedBy VTThien
        bool CheckCustomerCodeExisted(string customerCode);
        /// <summary>
        /// Check trùng số điện thoại
        /// </summary>
        /// <param name="phoneNumber"></param>
        /// <returns></returns>
        /// CreatedBy VTThien
        bool CheckPhoneNumberExisted(string phoneNumber);
    }
}
