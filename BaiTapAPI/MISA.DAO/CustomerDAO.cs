using Dapper;
using MISA.Common;
using MISA.DAO.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MISA.DAO//lấy data
{
    public class CustomerDAO : DbConnector<Customer>,ICustomerDAO
    {
        /// <summary>
        /// Check trùng mã
        /// </summary>
        /// <param name="code"> Mã khách hàng</param>
        /// <returns>True nếu trùng, False nếu k trùng</returns>
        /// CreatedBy NDLuu (29/12/2020)
        public bool checkDublicateCustomerCode(string code)
        {
            var x = db.Query<Customer>($"Select * from Customer where CustomerCode = '{code}'").FirstOrDefault();
            if (x == null)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Kiểm tra mã có tồn tại (để cập nhật)
        /// </summary>
        /// <param name="code"></param>
        /// <returns>true nếu tồn tại, false nếu không tồn tại</returns>
        public bool checkExistCustomerCode(string code)
        {
            var x = db.Query<Customer>($"Select * from Customer where CustomerCode = '{code}'").FirstOrDefault();
            if (x == null)
            {
                return false;
            }
            return true;
        }


        /// <summary>
        /// Check trùng số điện thoại
        /// </summary>
        /// <param name="phoneNumber"></param>
        /// <param name="customerCode"></param>
        /// <returns>True nếu trùng, False nếu k trùng<</returns>
        public bool CheckDuplicatedPhoneNumber(string phoneNumber, string customerCode = null)
        {
            var sqlQuery = "";
            if (customerCode == null)
                sqlQuery = $"SELECT * FROM Customer WHERE PhoneNumber = '{phoneNumber}'";
            else
                sqlQuery = $"SELECT * FROM Customer WHERE PhoneNumber = '{phoneNumber}' AND CustomerCode != '{customerCode}'";
            var customer = db.Query<Customer>(sqlQuery).FirstOrDefault();

            if (customer != null)
                return true;
            return false;
        }

        /// <summary>
        /// Lấy tất cả các khách hàng
        /// </summary>
        /// <returns>Danh sách khách hàng</returns>
        /// CreatedBy NDLuu (29/12/2020)
        public IEnumerable<Customer> GetCustomers()
        {
            DbConnector<Customer> dbConnector = new DbConnector<Customer>();
            var affect = dbConnector.GetAllData();
            return affect;
        }

        /// <summary>
        /// Thêm mới khách hàng
        /// </summary>
        /// <param name="customer">Khách hàng</param>
        /// <returns>Số bản ghi được thêm mới</returns>
        /// CreatedBy NDLuu (29/12/2020)
        public int Insert(Customer customer)
        {
            DbConnector<Customer> dbConnector = new DbConnector<Customer>();
            var affect = dbConnector.Insert(customer);
            return affect;
        }

        public int InsertCustomer(Customer customer)
        {
            db.Query<Customer>("");
            
            return 0;
        }
    }
}
