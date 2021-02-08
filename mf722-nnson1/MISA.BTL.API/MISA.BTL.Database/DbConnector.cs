using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using MISA.BTL.Database.Interfaces;
using MySql.Data.MySqlClient;

namespace MISA.BTL.Database
{
    public class DbConnector<T>:IDbConnector<T>
    {
        #region Declare
        protected string _connectionString = "User Id=nvmanh; Host=103.124.92.43; Database=MS4_14_NNSon_CukCuk; port=3306; password=12345678; Character Set=utf8;";
        protected IDbConnection dbConnection;
        #endregion

        #region Constructor
        /// <summary>
        /// Hàm khởi tạo
        /// </summary>
        /// CreatedBy: NNSON (07/02/2021)
        public DbConnector()
        {
            dbConnection = new MySqlConnector.MySqlConnection(_connectionString);
        }
        #endregion

        #region Method
        /// <summary>
        /// Lấy toàn bộ sữ liệu
        /// </summary>
        /// <returns>Collection object</returns>
        /// CreatedBy: NNSON (07/02/2021)
        public virtual IEnumerable<T> GetData()
        {
            var tableName = typeof(T).Name;
            var storeName = $"Proc_Get{tableName}s";
            // Thực hiện truy vấn lấy dữ liệu
            var entity = dbConnection.Query<T>(storeName, commandType: CommandType.StoredProcedure);

            // Trả về kết quả cho client
            return entity;
        }

        /// <summary>
        /// Lấy dữ liệu theo nhiều tiêu chí khác nhau
        /// </summary>
        /// <param name="sqlCommand">Tên StroeProcedure</param>
        /// <param name="parameters">Đối tượng chứa thông tin của tham số của Store</param>
        /// <param name="commandType"></param>
        /// <returns></returns>
        /// CreatedBy: NNSON (07/02/2021)
        public IEnumerable<T> GetData(string sqlCommand = null, object parameters = null, CommandType commandType = CommandType.Text)
        {
            var tableName = typeof(T).Name;
            if (sqlCommand == null)
            {
                sqlCommand = $"Proc_Get{tableName}s";
            }

            //Thực thi truy vấn lấy dữ liệu
            var entity = dbConnection.Query<T>(sqlCommand, param: parameters, commandType: commandType);

            // Trả về kết quả cho client
            return entity;
        }

        /// <summary>
        /// Thêm dữ liệu
        /// </summary>
        /// <param name="entity">object</param>
        /// <returns></returns>
        /// CreatedBy: NNSON (07/02/2021)
        public int Insert(T entity)
        {
            var tableName = typeof(T).Name;
            var storeName = $"Proc_Insert{tableName}";
            
            var affectRows = dbConnection.Execute(storeName, entity, commandType: CommandType.StoredProcedure);
            return affectRows;
        }

        /// <summary>
        /// Sửa dữ liệu
        /// </summary>
        /// <param name="entity">object</param>
        /// <returns></returns>
        /// CreatedBy: NNSON (08/02/2021)
        public int Update(T entity)
        {
            var tableName = typeof(T).Name;
            var storeName = $"Proc_Update{tableName}";
            
            var affectRows = dbConnection.Execute(storeName, entity, commandType: CommandType.StoredProcedure);
            return affectRows;
        }

        /// <summary>
        /// Xóa dữ liệu
        /// </summary>
        /// <param name="id">id của object cần xóa</param>
        /// <returns></returns>
        /// CreatedBy: NNSON (08/02/2021)
        public int Delete(string id)
        {
            var tableName = typeof(T).Name;
            var storeName = $"Proc_Delete{tableName}";
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add($"@Id", id);
            var affectRows = dbConnection.Execute(storeName, dynamicParameters, commandType: CommandType.StoredProcedure);
            return affectRows;
        }

        /// <summary>
        /// Kiểm tra id nhóm khách hàng tồn tại không
        /// </summary>
        /// <param name="id">id cần kiểm tra</param>
        /// <returns>true: đã tồn tại; false: chưa tồn tại</returns>
        /// CreatedBy: NNSON (08/02/2021)
        public bool CheckCustomerGroupIdExist(string id)
        {
            var entity = dbConnection.Query($"SELECT * FROM CustomerGroup WHERE CustomerGroupId = '{id}'");
            if (entity != null)
            {
                foreach (var obj in entity)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Kiểm tra tên nhóm khách hàng đã tồn tại chưa
        /// </summary>
        /// <param name="name">tên nhóm khách hàng cần kiểm tra</param>
        /// <returns>true: đã tồn tại; false: chưa tồn tại</returns>
        /// CreatedBy: NNSON (08/02/2021)
        public bool CheckCustomerGroupNameExist(string name)
        {
            var entity = dbConnection.Query($"SELECT * FROM CustomerGroup WHERE CustomerGroupName = '{name}'");
            if (entity != null)
            {
                foreach (var obj in entity)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Kiểm tra trường tên nhóm khách hàng có để trống hay không
        /// </summary>
        /// <param name="customerGroupName">giá trị trường tên nhóm khách hàng</param>
        /// <returns>true: để trống; false: đã có giá trị</returns>
        /// CreatedBy: NNSON (08/02/2021)
        public bool CheckEmptyCustomerGroupName(string customerGroupName)
        {
            if (customerGroupName == string.Empty)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Kiểm tra id khách hàng có tồn tại không
        /// </summary>
        /// <param name="id">id cần kiểm tra</param>
        /// <returns>true: đã tồn tại; false: không tồn tại</returns>
        /// CreatedBy: NNSon (07/02/2021)
        public bool CheckCustomerIdExist(string id)
        {
            var entity = dbConnection.Query($"SELECT * FROM Customer WHERE CustomerId = '{id}'");
            if (entity != null)
            {
                foreach (var obj in entity)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Kiểm tra mã khách hàng đã tồn tại hay không
        /// </summary>
        /// <param name="code">mã khách hàng cần kiểm tra</param>
        /// <returns>true: đã tồn tại; false: không tồn tại</returns>
        /// CreatedBy: NNSon (07/02/2021)
        public bool CheckCustomerCodeExist(string code)
        {
            var entity = dbConnection.Query($"SELECT * FROM Customer WHERE CustomerCode = '{code}'");
            if (entity != null)
            {
                foreach (var obj in entity)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Kiểm tra số điện thoại đã tồn tại hay không
        /// </summary>
        /// <param name="phoneNumber">số điện thoại cần kiểm tra</param>
        /// <returns>true: đã tồn tại; false: không tồn tại</returns>
        /// CreatedBy: NNSon (07/02/2021)
        public bool CheckPhoneNumberExist(string phoneNumber)
        {
            var entity = dbConnection.Query($"SELECT * FROM Customer WHERE PhoneNumber = '{phoneNumber}'");
            if (entity != null)
            {
                foreach (var obj in entity)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Kiểm tra trường họ và tên có để trống không
        /// </summary>
        /// <param name="fullName">giá trị của trường họ và tên</param>
        /// <returns>true: để trống; false: đã có giá trị</returns>
        /// CreatedBy: NNSon (07/02/2021)
        public bool CheckEmptyFullName(string fullName)
        {
            if (fullName == string.Empty)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Kiểm tra trường số điện thoại có để trống không
        /// </summary>
        /// <param name="phoneNumber">giá trị trường số điện thoại</param>
        /// <returns>true: để trống; false: đã có giá trị</returns>
        /// CreatedBy: NNSon (07/02/2021)
        public bool CheckEmptyPhoneNumber(string phoneNumber)
        {
            if (phoneNumber == string.Empty)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Kiểm tra trường Email có để trống không
        /// </summary>
        /// <param name="email">giá trị trường Email</param>
        /// <returns>true: để trống; false: đã có giá trị</returns>
        /// CreatedBy: NNSon (07/02/2021)
        public bool CheckEmptyEmail(string email)
        {
            if (email == string.Empty)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Kiểm tra trường mã khách hàng có để trống không
        /// </summary>
        /// <param name="code">giá trị trường mã khách hàng</param>
        /// <returns>true: để trống; false: đã có giá trị</returns>
        /// CreatedBy: NNSon (07/02/2021)
        public bool CheckEmptyCustomerCode(string code)
        {
            if (code == string.Empty)
            {
                return true;
            }
            return false;
        }

        #endregion
    }
}
