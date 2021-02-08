using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MISA.Common.Model;

namespace MISA.DataLayer
{
    public class CustomerRepository:DbContext<Customer>
    {
        /// <summary>
        /// Lấy 100 khách hàng đầu tiên
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Customer> GetCustomerTop100()
        {
            return GetData("SELECT * FROM Customer LIMIT 100");
        }

        /// <summary>
        /// Kiểm tra mã khách hàng đã tồn tại hay chưa
        /// </summary>
        /// <param name="customerCode">Mã khách hàng cần kiểm tra</param>
        /// <returns>true: đã tồn tại; false: không tồn tại </returns>
        /// CreatedBy: Đào Đức Thao (03/02/2021)
        public bool CheckCustomerCodeExits(string customerCode)
        {

            var sql = $"SELECT CustomerCode FROM Customer AS C WHERE C.CustomerCode = '{customerCode}'";
            var customerCodeExits = _dbConnection.Query<string>(sql).FirstOrDefault();
            if (customerCodeExits != null)
                return true;
            else
                return false;

        }

        /// <summary>
        /// Kiểm tra số điện thoại đã tồn tại hay chưa
        /// </summary>
        /// <param name="customerCode">Số điện thoại cần kiểm tra</param>
        /// <returns>true: đã tồn tại; false: không tồn tại </returns>
        /// CreatedBy: Đào Đức Thao (03/02/2021)
        public bool CheckCustomerPhoneNumberExits(string phoneNumber)
        {

            var sqlSelectPhoneNumber = $"SELECT PhoneNumber FROM Customer AS C WHERE C.PhoneNumber = '{phoneNumber}'";
            var phoneNumberExits = _dbConnection.Query<string>(sqlSelectPhoneNumber).FirstOrDefault();
            if (phoneNumberExits != null)
                return true;
            else
                return false;

        }
    }
}
