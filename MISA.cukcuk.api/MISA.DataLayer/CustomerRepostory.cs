using Dapper;
using MISA.Common.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MISA.DataLayer
{
    public class CustomerRepostory:DbContext<Customer>
    {
        /// <summary>
        /// Lấy 100 khách hàng đầu tiên
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Customer> GetCustomerTop100()
        {
            return GetData("Select * from Customer limit 1");
        }
        /// <summary>
        /// Kiểm tra mã khách hàng xem đã tồn tại hay chưa
        /// </summary>
        /// <param name="customerCode">Mã cần kiểm tra</param>
        /// <returns>true: đã tồn tại, false: chưa tồn tại</returns>
        public bool checkCustomerCodeExists(string customerCode)
        {
            var sql = $"SELECT CustomerCode From Customer AS C where C.CustomerCode = '{customerCode}'";
            var customerCodeExists = _dbConnection.Query<string>(sql).FirstOrDefault();
            if (customerCodeExists != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Kiểm tra số điện thoại của khách hàng xem đã tồn tại hay chưa
        /// </summary>
        /// <param name="customerCode">Số cần kiểm tra</param>
        /// <returns>true: đã tồn tại, false: chưa tồn tại</returns>
        public bool checkCustomerPhoneNumberExists(string phoneNumber)
        {
            var sqlSelectPhoneNumber = $"SELECT PhoneNumber From Customer AS C where C.PhoneNumber = '{phoneNumber}'";
            var phoneNumberExists = _dbConnection.Query<string>(sqlSelectPhoneNumber).FirstOrDefault();
            if (phoneNumberExists != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
