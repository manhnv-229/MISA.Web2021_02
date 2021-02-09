using CukCuk.DataLayer.Interfaces;
using Dapper;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace CukCuk.DataLayer.DataLayers
{
    /// <summary>
    /// Cơ sở dữ liệu V2
    /// </summary>
    /// <typeparam name="T">Object</typeparam>
    public class DbConnectorV2<T>:IDbConnector<T>
    {
        #region Declare
        // Khởi tạo chuỗi kết nối
        protected string _connectionString = "User Id=nvmanh;Host=103.124.92.43;" +
            "Database=MS1_40_DMTHANH_CukCuk;port=3306;password=12345678;Character Set=utf8";
        
        protected IDbConnection _dbConnection;
        #endregion

        #region Constructor
        
        public DbConnectorV2()
        {
            _dbConnection = new MySqlConnection(_connectionString);
        }
        #endregion

        #region Method
        /// <summary>
        /// Lấy dữ liệu
        /// </summary>
        /// <param name="sqlCommand">Câu lệnh </param>
        /// <param name="parameters">Tham số truyền vào</param>
        /// <param name="commandType"></param>
        /// <returns></returns>
        /// CreatedBy: DMThanh (06/02/2021)
        public IEnumerable<T> GetData(string sqlCommand = null, object parameters = null, CommandType commandType = CommandType.Text)
        {
            
            if (sqlCommand == null)
            {

                var tableName = typeof(T).Name;                
                sqlCommand = $"SELECT * FROM {tableName}";                
                var entities = _dbConnection.Query<T>(sqlCommand);
                return entities;
            }
            else
            {               
                var entities = _dbConnection.Query<T>(sqlCommand, param: parameters, commandType: commandType);
                return entities;
            }
        }

        /// <summary>
        /// Thêm mới bản ghi
        /// </summary>
        /// <param name="entity">Object</param>
        /// <returns>Số bản ghi thêm thành công</returns>
        /// CreatedBy: DMThanh (08/02/2021)
        public int Insert(T entity)
        {
            
            var tableName = typeof(T).Name;            
            var storeName = $"Proc_Insert{tableName}";            
            DynamicParameters dynamicParameters = new DynamicParameters();            
            var properties = typeof(T).GetProperties();            
            foreach (var property in properties)
            {
               
                var propertyName = property.Name;                
                var propertyValue = property.GetValue(entity);                
                dynamicParameters.Add($"@{propertyName}", propertyValue);
            }
            
            var affects = _dbConnection.Execute(storeName, dynamicParameters, commandType: CommandType.StoredProcedure);
            return affects;
        }

        /// <summary>
        /// Cập nhập thông tin khách hàng
        /// </summary>
        /// <param name="entity">Object</param>
        /// <returns>Số lượng bản ghi cập nhật thành công</returns>
        /// CreatedBy: DMThanh (08/02/2021)
        public int Update(T entity)
        {
            
            var tableName = typeof(T).Name;
            
            var storeName = $"Proc_Update{tableName}";
            
            DynamicParameters dynamicParameters = new DynamicParameters();
            
            var properties = typeof(T).GetProperties();
            
            foreach (var property in properties)
            {
               
                var propertyName = property.Name;                
                var propertyValue = property.GetValue(entity);                
                dynamicParameters.Add($"@{propertyName}", propertyValue);
            }
            
            var affects = _dbConnection.Execute(storeName, dynamicParameters, commandType: CommandType.StoredProcedure);
            return affects;
        }

        /// <summary>
        /// Xóa bản ghi
        /// </summary>
        /// <param name="id">Xoá theo Id</param>
        /// <returns>Số bản ghi xoá thành công</returns>
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
