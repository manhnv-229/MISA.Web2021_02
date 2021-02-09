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
        /// <param name="id"></param>
        /// <returns>Số lượng bản ghi thêm thành công</returns>
        /// CreatedBy: DMThanh (06/02/2021)
        public override int Delete(string id)
        {
            // Xóa khách hàng theo id khách hàng
            var sqlQuery = $"delete FROM Customer WHERE CustomerId = '{id}'";
            return _dbConnection.Execute(sqlQuery);
        }

        /// <summary>
        /// Kiểm tra trùng mã
        /// </summary>
        /// <param name="customerCode">Mã khách hàng</param>
        /// <returns>True = trùng mã, False = Không trùng</returns>
        /// CreatedBy: DMThanh (06/02/2021)
        public bool CheckDuplicatedCode(string code)
        {
            //Lấy mã khách hàng từ DB
            var sqlQuery = $"SELECT * FROM Customer WHERE CustomerCode = '{code}'";            
            var customer = _dbConnection.Query<Customer>(sqlQuery).FirstOrDefault();
            if(customer != null)
                return true;
            return false;
        }

        /// <summary>
        ///Check Duplicate ssố điện thoại
        /// </summary>
        /// <param name="customerCode">Mã khách hàng</param>
        /// <param name="phoneNumber">Số điện thoại</param>
        /// <returns>True = trùng mã, False = Không trùng</returns>
        /// CreatedBy: DMThanh (06/02/2021)
        public bool CheckDuplicatedPhoneNumber(string phoneNumber, string customerCode = null)
        {
            
            var sqlQuery = "";            
            if (customerCode == null)
                sqlQuery = $"SELECT * FROM Customer WHERE PhoneNumber = '{phoneNumber}'";
            else
                sqlQuery = $"SELECT * FROM Customer WHERE PhoneNumber = '{phoneNumber}' AND CustomerCode != '{customerCode}'";           
            var customer = _dbConnection.Query<Customer>(sqlQuery).FirstOrDefault();
            if (customer != null)
                return true;
            return false;
        }
    }
}
