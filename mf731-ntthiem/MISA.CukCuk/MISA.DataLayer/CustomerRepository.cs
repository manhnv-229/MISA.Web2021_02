using System;
using System.Collections.Generic;
using System.Text;
using Dapper;
using System.Linq;
using MISA.Common.Models;
namespace MISA.DataLayer
{
    public class CustomerRepository: DbContext<Customer>
    {
        /// <summary>
        /// Lấy 10 KH đầu tiên
        /// </summary>
        /// <returns></returns>
        /// CreatedBy: NTTHIEM
        /// CreatedDate: 07/02/2021
        public IEnumerable<Customer> GetCustomerTop10()
        {
            return GetData("SELECT * FROM Customer LIMIT 10");
        }

        /// <summary>
        /// Kiểm tra mã khách hàng đã tồn tại chưa
        /// </summary>
        /// <param name="customerCode">Mã khách hàng cần kiểm tra</param>
        /// <returns>true: đã tồn tại; false: chưa tồn tại</returns>
        /// CreatedBy: NTTHIEM
        /// CreatedDate: 07/02/2021
        public bool CheckCustomerCodeExist(string customerCode)
        {
            var sql = $"SELECT CustomerCode FROM Customer WHERE CustomerCode = '{customerCode}'";
            var customerCodeExist = _dbConnection.Query<string>(sql).FirstOrDefault();
            if (customerCodeExist != null)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Kiểm tra số điện thoại đã tồn tại chưa
        /// </summary>
        /// <param name="phoneNumber">SĐT cần kiểm tra</param>
        /// <returns>true - đã tồn tại hoặc false - chưa tồn tại</returns>
        /// CreatedBy: NTTHIEM
        /// CreatedDate: 07/02/2021
        public bool CheckPhoneNumberExist(string phoneNumber)
        {
            var sql = $"SELECT PhoneNumber FROM Customer WHERE PhoneNumber = '{phoneNumber}'";
            var phoneNumberExist = _dbConnection.Query<string>(sql).FirstOrDefault();
            if (phoneNumberExist != null)
                return true;
            else
                return false;
        }
    }
}
