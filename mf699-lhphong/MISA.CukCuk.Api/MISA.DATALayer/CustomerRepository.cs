using System;
using System.Collections.Generic;
using System.Text;
using Dapper;
using System.Linq;
using MISA.Common.Model;
using MISA.DATALayer.Interface;

namespace MISA.DATALayer
{
    public class CustomerRepository: DbContext<Customer>, ICustomerRepository
    {
        /// <summary>
        /// Kiểm tra mã khách hàng đã tồn tại hay chưa
        /// </summary>
        /// <param name="customerCode">Mã khách hàng cần kiểm tra</param>
        /// <returns>true: đã tồn tại; false: chưa tồn tại</returns>
        /// CreatedBy: LHPHONG (8/1/2021)
        public bool checkCustomerCodeExits(string customerCode)
        {
            var sql = $"SELECT * FROM Customer AS C WHERE C.CustomerCode = '{customerCode}'";
            var customerCodeExits = _dbConnection.Query<string>(sql).FirstOrDefault();

            if (customerCodeExits != null)
            {
                return true;
            }
            else return false;
        }

        /// <summary>
        /// Kiểm tra số điện thoại đã tồn tại chưa
        /// </summary>
        /// <param name="phoneNumber">số điện thoại cần kiểm tra</param>
        /// <returns>true: đã tồn tại; false: chưa tồn tại</returns>
        /// CreatedBy: LHPHONG (8/1/2021)
        public bool checkPhoneNumberExits(string phoneNumber)
        {
            var sql = $"SELECT * FROM Customer AS C WHERE C.PhoneNumber = '{phoneNumber}'";
            var customerCodeExits = _dbConnection.Query<string>(sql).FirstOrDefault();

            if (customerCodeExits != null)
            {
                return true;
            }
            else return false;
        }
    }
}
