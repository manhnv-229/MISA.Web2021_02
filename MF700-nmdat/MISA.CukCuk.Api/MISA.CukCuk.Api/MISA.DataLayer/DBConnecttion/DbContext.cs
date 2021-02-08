using Dapper;
using MISA.DataLayer.Interface;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace MISA.DataLayer
{
    /// <summary>
    /// Kết nôi thực hiện truy vấn với Database. 
    /// Thực hiện các thao tác Query :GET; Ex : POST,PUT,DELETE;
    /// </summary>
    /// CreatedBy: NMDAT (04/02/2021)
    public class DbContext<T> : IBaseDBConnection<T>
    {
        #region DECLARE
        // khai báo đường dẫn database
        protected string _connectionString = "User Id=nvmanh;Host=103.124.92.43; Port = 3306;Character Set=utf8; Database = MS1_700_NMDAT_CukCuk ; Password = 12345678";

        // Khởi tạo kết nối Database
        protected IDbConnection _dbConnection;
        #endregion

        #region Contructor
        /// <summary>
        /// Hàm khởi tạo DbContext.
        /// </summary>
        public DbContext()
        {
            // Kết nối với Database
            _dbConnection = new MySqlConnection(_connectionString);
        }
        #endregion

        #region Method
        /// <summary>
        /// Lấy dữ liệu theo tham số truyền vào nếu không truyền vào mặc định là lấy tất cả
        /// </summary>
        /// <typeparam name="T">Đối tượng cần lấy dữ liệu</typeparam>
        /// <param name="sqlCommand">Tên Store lấy dữ liệu</param>
        /// <param name="parameters">Dữ liệu truyền vào( lấy theo id,code,...)</param>
        /// <param name="commandType">Kiểu lấy dữ liệu</param>
        /// <returns>Trả về thông tin cần lấy</returns>
        public virtual IEnumerable<T> GetAll(string sqlCommand = null,object parameters = null , CommandType commandType = CommandType.Text)
        {
            if(sqlCommand == null)
            {
                var className = typeof(T).Name;
                sqlCommand = $"SELECT * FROM {className}";
            }
            // Thực thi truy vấn lấy dữ liệu
            var result = _dbConnection.Query<T>(sqlCommand,param:parameters, commandType:commandType);

            // Trả về danh sách dữ liệu
            return result;
        }

        /// <summary>
        /// Thêm mới object vào database
        /// </summary>
        /// <param name="entity">Đối tượng được thêm mới</param>
        /// <param name="commandType">Kiểu thêm mới</param>
        /// <returns>số dòng thêm thành công</returns>
        public int InsertObject(T entity , CommandType commandType = CommandType.Text)
        {
            // lấy ra các property của object
            var properties = typeof(T).GetProperties();

            // khởi tạo các biến string để lưu các giá trị property
            var sqlPropName = string.Empty;
            var className = typeof(T).Name;
            var sqlPropParam = string.Empty;

            var dynamicParameters = new DynamicParameters();

            // Duyệt tùng properties để lấy giá trị
            foreach(var property in properties)
            {
                var propName = property.Name;
                var propValue = property.GetValue(entity);

                // sinh id mới
                if ((property.PropertyType == typeof(Guid) || property.PropertyType == typeof(Guid?)) && propName.ToLower() == $"{className}Id".ToLower())
                    propValue = Guid.NewGuid();

                sqlPropName += $",{propName}";
                sqlPropParam += $",@{propName}";
                dynamicParameters.Add($"@{propName}", propValue);

            }
            // Xóa đi kí tự "," đầu câu 
            sqlPropName = sqlPropName.Remove(0, 1);
            sqlPropParam = sqlPropParam.Remove(0, 1);

            var sql = $"INSERT INTO {className} ({sqlPropName}) VALUE ({sqlPropParam})";
            var res = _dbConnection.Execute(sql, param: dynamicParameters, commandType: commandType);
            return res;
        }
        /// <summary>
        /// Suửa thông tin thực thể
        /// </summary>
        /// <param name="entity">Thực thể truyền vào</param>
        /// <param name="commandType">Kiểu sql</param>
        /// <returns>trả về dòng sửa thành công</returns>
        public int UpdateObject(T entity , CommandType commandType = CommandType.Text)
        {
            // lấy ra các properties của thực thể
            var properties = typeof(T).GetProperties();

            // khởi tạo câu lệnh set
            var sqlPropParam = string.Empty;

            // khởi tạo biến tạm thời lưu giá trị id cần sửa
            Guid sqlPropId = Guid.Empty;

            // lấy ra tên thực thể
            var className = typeof(T).Name;

            // dynamicparameter để truyền dữ liệu param
            DynamicParameters dynamicParameters = new DynamicParameters();

            // Duyệt từng property để tạo câu lệnh và gán param
            foreach(var property in properties)
            {
                var propName = property.Name;
                var propValue = property.GetValue(entity);
                if (propName.ToLower() == $"{className}Id".ToLower())
                    sqlPropId = (Guid)propValue;
                sqlPropParam += $",{propName} = @{propName}";
                dynamicParameters.Add($"@{propName}", propValue);
            }
            // xóa kí tự đầu
            sqlPropParam = sqlPropParam.Remove(0, 1);

            //khởi tạo câu lệnh
            var sqlCommand = $"UPDATE {className} SET {sqlPropParam} Where {className}Id = '{sqlPropId}' ";

            // dapper thực hiện lệnh 
            var res = _dbConnection.Execute(sqlCommand,param: dynamicParameters, commandType: commandType);
            return res;

        }

        /// <summary>
        /// Xóa dữ liệu thực thể
        /// </summary>
        /// <param name="entity">thự thể truyền vào</param>
        /// <param name="commandType">Kiểu Xóa</param>
        /// <returns>trả về số thực thể xóa đc</returns>
        public int DeleteObject(T entity , CommandType commandType = CommandType.Text)
        {
            // DELETE FROM Employee WHERE Employee.EmployeeID = employeeId;
            var className = typeof(T).Name;

            // lấy ra các property của thực thể
            var properties = typeof(T).GetProperties();

            // khởi tạo biến tạm thời lưu giá trị id cần sửa
            Guid sqlPropId = Guid.Empty;

            // Duyệt từng property để lấy ra id
            foreach (var property in properties)
            {
                var propName = property.Name;
                var propValue = property.GetValue(entity);
                if (propName.ToLower() == $"{className}Id".ToLower())
                    sqlPropId = (Guid)propValue;
            }
            var sqlCommand = $"SET FOREIGN_KEY_CHECKS=0; DELETE FROM {className} WHERE {className}Id = '{sqlPropId}'";
            var res = _dbConnection.Execute(sqlCommand,commandType:commandType);
            return res;

        }
        #endregion

        #region Other
        #endregion
    }
}
