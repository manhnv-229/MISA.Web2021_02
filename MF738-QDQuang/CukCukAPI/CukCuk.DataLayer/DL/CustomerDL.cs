using CukCuk.Common;
using CukCuk.Common.Models;
using CukCuk.DataLayer.DataLayers;
using CukCuk.DataLayer.Interfaces;
using Dapper;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CukCuk.DataLayer
{
    public class CustomerDL:DbConnector<Customer>, ICustomerDL
    {
        /// <summary>
        /// Xóa khách hàng
        /// </summary>
        /// <param name="customerCode">string</param>
        /// <returns>Int (Số lượng bản ghi tác động vào cơ sở dữ liệu)</returns>
        /// CreatedBy: QDQuang (07/02/2021)
        public override int Delete(string customerCode)
        {
            // Xóa khách hàng theo mã khách hàng (sử dụng QUERY STRING)
            var sqlQuery = $"DELETE FROM Customer WHERE CustomerCode = '{customerCode}'";

            return _dbConnection.Execute(sqlQuery);
        }

        /// <summary>
        /// Kiểm tra trùng mã khách hàng
        /// </summary>
        /// <param name="customerCode">Mã khách hàng</param>
        /// <returns>Bool (true - mã khách hàng bị trùng, false - mã khách hàng không bị trùng)</returns>
        /// CreatedBy: QDQuang (06/02/2021)
        public bool CheckDuplicatedCode(string customerCode)
        {
            // Kiểm tra trùng mã khách hàng (sử dụng QUERY STRING)
            var sqlQuery = $"SELECT * FROM Customer WHERE CustomerCode = '{customerCode}'";
            // Kết quả trả về (null - không bị trùng, !null - đã bị trùng)
            var customer = _dbConnection.Query<Customer>(sqlQuery).FirstOrDefault();

            if(customer != null)
                return true;
            return false;
        }

        /// <summary>
        /// Kiểm tra trùng số điện thoại khi update khách hàng
        /// </summary>
        /// <param name="customerCode">Mã khách hàng cần kiểm tra</param>
        /// <param name="phoneNumber">Số điện thoại</param>
        /// <returns>Bool (true - số điện thoại bị trùng, false - số điện thoại không bị trùng)</returns>
        /// CreatedBy: QDQuang (07/02/2021)
        public bool CheckDuplicatedPhoneNumber(string phoneNumber, string customerCode = null)
        {
            // Khởi tạo câu Query rỗng
            var sqlQuery = "";
            // Nếu customerCode là rỗng => đang thực hiện thêm mới nếu không thì đang thực hiện cập nhật
            if (customerCode == null)
                sqlQuery = $"SELECT * FROM Customer WHERE PhoneNumber = '{phoneNumber}'";
            else
                sqlQuery = $"SELECT * FROM Customer WHERE PhoneNumber = '{phoneNumber}' AND CustomerCode != '{customerCode}'";
            // Kết quả trả về (null - không bị trùng, !null - đã bị trùng)
            var customer = _dbConnection.Query<Customer>(sqlQuery).FirstOrDefault();

            if (customer != null)
                return true;
            return false;
        }
    }
}
