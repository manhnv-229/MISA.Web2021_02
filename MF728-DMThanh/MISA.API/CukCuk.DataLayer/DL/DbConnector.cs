using CukCuk.DataLayer.Interfaces;
using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace CukCuk.DataLayer
{
    /// <summary>
    ///Truy vấn dữ liệu từ SQL
    /// </summary>
    /// <typeparam name="T">Object</typeparam>
    public class DbConnector<T>:IDbConnector<T>
    {
        #region Declare
        // Khởi tạo chuỗi kết nối
        protected string _connectionString = "User Id=dmthanh;Host=168.138.40.128;" +
            "Database=MISACukCuk_MF728_DMThanh;port=3306;password=minhthanh;Character Set=utf8";
        // Khởi tạo kết nối
        protected IDbConnection _dbConnection;
        #endregion

        #region Constructor
       
        public DbConnector()
        {
            _dbConnection = new MySqlConnection(_connectionString);
        }
        #endregion

        #region Method
        /// <summary>
        /// Lấy dữ liệu 
        /// </summary>
        /// <param name="sqlCommand"></param>
        /// <param name="parameters">Các tham số truyền vào</param>
        /// <param name="commandType">>Loại truy vấn </param>
        /// <returns>Danh sách đối tượng</returns>
        /// CreatedBy: DMThanh (06/02/2021)
        public IEnumerable<T> GetData(string sqlCommand = null, object parameters = null, CommandType commandType = CommandType.Text)
        {
            
            if(sqlCommand == null)
            {
                var tableName = typeof(T).Name;
                var storeName = $"Proc_Get{tableName}s";
                var entity = _dbConnection.Query<T>(storeName, commandType: CommandType.StoredProcedure);
                return entity;
            } else
            {
                
                var entities = _dbConnection.Query<T>(sqlCommand, param: parameters, commandType: commandType);
                return entities;
            }
        }

        /// <summary>
        /// Thêm mới bản ghi
        /// </summary>
        /// <param name="entity">Object</param>
        /// <returns>Bản nghi được thêm thành công</returns>
        /// CreatedBy: DMThanh (06/02/2021)
        public int Insert(T entity)
        {
            
            var tableName = typeof(T).Name;            
            var storeName = $"Proc_Insert{tableName}";            
            var entities = _dbConnection.Execute(storeName, entity, commandType: CommandType.StoredProcedure);
            return entities;
        }

        /// <summary>
        /// Cập nhập thông tin khách hàng
        /// </summary>
        /// <param name="entity">Object</param>
        /// <returns>Bản ghi được sửa thành công</returns>
        /// CreatedBy: DMThanh (06/02/2021)
        public int Update(T entity)
        {
            
            var tableName = typeof(T).Name;            
            var storeName = $"Proc_Update{tableName}";            
            var affects = _dbConnection.Execute(storeName, entity, commandType: CommandType.StoredProcedure);
            return affects;
        }

        /// <summary>
        /// Xóa bản ghi
        /// </summary>
        /// <param name="id">Xoá bản ghi bằng Id</param>
        /// <returns></returns>
        /// CreatedBy: DMThanh (06/02/2021)
        public virtual int Delete(string id)
        {
            
            var tableName = typeof(T).Name;            
            var storeName = $"Proc_Delete{tableName}";            
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add($"@{tableName}Id", id);           
            var affects = _dbConnection.Execute(storeName, dynamicParameters, commandType: CommandType.StoredProcedure);
            return affects;
        }
        #endregion
    }
}
