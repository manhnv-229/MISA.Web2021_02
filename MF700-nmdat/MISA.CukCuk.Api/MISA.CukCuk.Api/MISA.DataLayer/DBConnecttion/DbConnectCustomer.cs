using Dapper;
using MISA.Common.Model;
using MISA.DataLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MISA.DataLayer
{
    /// <summary>
    /// Kết nối với Database bảng Customer
    /// </summary>
    /// CreatedBy: NMDAT (02/04/2021)
    public class DbConnectCustomer : DbContext<Customer>, ICustomerDBConnecttion
    {

        /// <summary>
        /// Kiểm tra mã khách hàng đã tồn tại hay chưa
        /// </summary>
        /// <param name="customerCode">mã khách hàng</param>
        /// <returns>true là tồn tại - false là chưa tồn tại</returns>
       public bool CheckCustomerCodeExits(string customerCode)
        {
            // sql truy vấn mã khách hàng
            var sql = $"SELECT * FROM Customer AS c WHERE c.CustomerCode = '{customerCode}'";

            // dapper thực hiện truy vấn nếu null là không tồn tại - != null là tồn tại
            var customerCodeExits = _dbConnection.Query<Customer>(sql).FirstOrDefault();
            if(customerCodeExits != null)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Kiểm tra số điện thoại đã tồn tại hay chưa
        /// </summary>
        /// <param name="phoneNumber">Số điện thoại</param>
        /// <returns>true là tồn tại - false là chưa tồn tại</returns>
        public bool CheckPhoneNumberExits(string phoneNumber)
        {
            // sql truy vấn mã khách hàng
            var sql = $"SELECT * FROM Customer AS c WHERE c.PhoneNumber = '{phoneNumber}'";

            // dapper thực hiện truy vấn nếu null là không tồn tại - != null là tồn tại
            var phoneNumberExits = _dbConnection.Query<Customer>(sql).FirstOrDefault();
            if (phoneNumberExits != null)
                return true;
            else
                return false;
        }

    }
}
