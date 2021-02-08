using Dapper;
using MISA.Common.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MISA.DL
{
    public class CustomerRepository: DbContext<Customer>
    {
        /// <summary>
        /// Kiểm tra mã khách hàng tồn tại chưa?
        /// </summary>
        /// <param name="customerCode"> Mã khách hàng</param>
        /// <returns>true: đã tồn tại. false: không tồn tại.</returns>
        public bool CheckCustomerCodeDuplicate(string customerCode)
        {
            var sqlQuerry = $"SELECT CustomerCode FROM Customer AS C WHERE C.CustomerCode ='{customerCode}'";
            var customerCodeDuplicate = _dbConnection.Query<string>(sqlQuerry).FirstOrDefault();
            if (customerCodeDuplicate != null)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Kiểm tra số điện thoại khách hàng tồn tại chưa?
        /// </summary>
        /// <param name="phoneNumber"> Số điện thoại khách hàng</param>
        /// <returns>true: đã tồn tại. false: không tồn tại.</returns>
        public bool CheckPhoneNumberDuplicate(string phoneNumber)
        {
            var sqlQuerry = $"SELECT PhoneNumber FROM Customer AS C WHERE C.PhoneNumber ='{phoneNumber}'";
            var phoneNumberDuplicate = _dbConnection.Query<string>(sqlQuerry).FirstOrDefault();
            if (phoneNumberDuplicate != null)
                return true;
            else
                return false;
        }
    }
}
