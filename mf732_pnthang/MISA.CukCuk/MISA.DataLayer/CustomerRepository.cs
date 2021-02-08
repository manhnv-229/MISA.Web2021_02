using System;
using System.Collections.Generic;
using System.Text;
using Dapper;
using System.Linq;
using MISA.Common.Models;
using MISA.DataLayer.Interfaces;

namespace MISA.DataLayer
{
    public class CustomerRepository: DbContext<Customer>
    {
       
        /// <summary>
        /// Kiểm tra mã khách hàng đã tồn tại chưa
        /// </summary>
        /// <param name="customerCode">Mã khách hàng cần kiểm tra</param>
        /// <returns>true: đã tồn tại; false: chưa tồn tại</returns>
        /// CreatedBy: PNTHANG (06/02/2021)
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
        /// <param name="phoneNumber">Số điện thoại cần kiểm tra</param>
        /// <returns>true: đã tồn tại; false: chưa tồn tại</returns>
        /// CreatedBy: PNTHANG (06/02/2021)
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
