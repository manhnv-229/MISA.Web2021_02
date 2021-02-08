using Dapper;
using MISA.Common;
using MISA.Common.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace MISA.Infrastructure
{
    /// <summary>
    /// Viết câu lệnh sql để lấy dữ liệu từ database
    /// </summary>
    /// CreatedBy: PNVĐ (02/02/2021)
    public class DbConnector
    {
        #region DECLARE
        protected string connectionString = "User Id=nvmanh;Host=103.124.92.43;Database=MS4_22_PNVD_CukCuk;port=3306;password=12345678;Character Set=utf8";
        protected IDbConnection db;
        #endregion

        #region Contructor
        public DbConnector()
        {
            db = new MySqlConnector.MySqlConnection(connectionString);
        }
        #endregion

        #region Methods
        /// <summary>
        /// Lấy dữ liệu với mọi object
        /// </summary>
        /// <typeparam name="T">thuộc tính chung</typeparam>
        /// <param name="sqlCommand">Câu lệnh gọi sql, storeprocedure</param>
        /// <param name="parameter">tham số truyền vào câu lệnh sql, procedure</param>
        /// <param name="commandType">loại CommandType là text, procedure</param>
        /// <returns>danh sách dữ liệu cần lấy</returns>
        public IEnumerable<T> GetData<T>(string sqlCommand = null,object parameter = null,CommandType commandType = CommandType.Text)
        {
            var tableName = typeof(T).Name;
            if(sqlCommand == null)
            {
                sqlCommand = $"SELECT * from {tableName}";
            }
            var data = db.Query<T>(sqlCommand, param: parameter, commandType: commandType);
            return data;
        }


        /// <summary>
        /// Đếm số lượng dữ liệu thuộc tính T 
        /// </summary>
        /// <typeparam name="T">thuộc tính chung</typeparam>
        /// <returns></returns>
        public long GetCountData<T>()
        {
            var tableName = typeof(T).Name;
            var storeName = $"pro_GetCount{tableName}";

            var count = db.ExecuteScalar(storeName, commandType: CommandType.StoredProcedure);
            return (long)count;
        }
        /// <summary>
        /// thêm mới thuộc tính T
        /// </summary>
        /// <typeparam name="T">thuộc tính T</typeparam>
        /// <param name="entity">kiểu dữ liệu T</param>
        /// <returns></returns>
        public int Insert<T>(T entity)
        {
            var tableName = typeof(T).Name;
            var storeName = $"pro_Insert{tableName}";
            DynamicParameters dynamicParameters = new DynamicParameters();

            var properties = typeof(T).GetProperties();
            foreach (var property in properties)
            {
                var propertyName = property.Name;
                var propertyValue = property.GetValue(entity);
                var propertyType = property.PropertyType;
                if (propertyType == typeof(Guid))
                {
                    dynamicParameters.Add($"@{propertyName}", propertyValue.ToString());
                }
                else if(propertyType == typeof(DateTime) || propertyType == typeof(DateTime?))
                {
                    string dateTimeString = null;
                    if(propertyValue != null)
                    {
                        var dateTime = (DateTime)propertyValue;
                        dateTimeString = dateTime.ToString("yyyy-MM-dd hh-mm-ss");
                    }
                    
                    dynamicParameters.Add($"@{propertyName}", dateTimeString);
                }
                else
                {
                    dynamicParameters.Add($"@{propertyName}", propertyValue);
                }
            }
            var list = db.Execute(storeName, dynamicParameters, commandType: CommandType.StoredProcedure);
            return list;
        }
        /// <summary>
        /// Cập nhật dữ liệu T
        /// </summary>
        /// <typeparam name="T">Thuộc tính T</typeparam>
        /// <param name="entity">dữ liệu T</param>
        /// <returns></returns>
        public int Update<T>(T entity)
        {
            var tableName = typeof(T).Name;
            var storeName = $"pro_Update{tableName}";
            DynamicParameters dynamicParameters = new DynamicParameters();

            var properties = typeof(T).GetProperties();
            foreach (var property in properties)
            {
                var propertyName = property.Name;
                var propertyValue = property.GetValue(entity);
                var propertyType = property.PropertyType;
                if (propertyType == typeof(Guid))
                {
                    dynamicParameters.Add($"@{propertyName}", propertyValue.ToString());
                }
                else
                {
                    dynamicParameters.Add($"@{propertyName}", propertyValue);
                }
            }
            var list = db.Execute(storeName, dynamicParameters, commandType: CommandType.StoredProcedure);
            return list;
        }
        /// <summary>
        /// Xóa dữ liệu T
        /// </summary>
        /// <typeparam name="T">thuộc tính chung</typeparam>
        /// <param name="entity">dữ liệu chung</param>
        /// <returns></returns>
        public int delete<T>(T entity)
        {
            var tableName = typeof(T).Name;
            var storeName = $"pro_Delete{tableName}";
            DynamicParameters dynamicParameters = new DynamicParameters();

            var properties = typeof(T).GetProperties();
            foreach (var property in properties)
            {
                var propertyName = property.Name;
                var propertyValue = property.GetValue(entity);
                var propertyType = property.PropertyType;
                if (propertyType == typeof(Guid))
                {
                    dynamicParameters.Add($"@{propertyName}", propertyValue.ToString());
                }
                else
                {
                    dynamicParameters.Add($"@{propertyName}", propertyValue);
                }
            }
            var list = db.Execute(storeName, dynamicParameters, commandType: CommandType.StoredProcedure);
            return list;
        }
        #endregion
    }
}
