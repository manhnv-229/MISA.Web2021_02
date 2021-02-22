using Common;
using Dapper;
using MISA.DataLayer.Interfaces;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;  

namespace MISA.DataLayer.DbContext1
{
    public class DbContext<TEntity>:IDbContext<TEntity>
    {
        #region DECLARE
        string connectionString = "" +
                "Host = 47.241.69.179;" +
                "Port= 3306;" +
                "Database = MF707_TLMinh_CukCuk;" +
                "User Id = dev;" +
                "Password = 12345678";
        protected IDbConnection _dbConnection;
        #endregion

        #region CONTRUCTORS
        public DbContext()
        {
            _dbConnection = new MySqlConnector.MySqlConnection(connectionString);
        }
        #endregion

        #region METHODS

        /// <summary>
        /// Lấy toàn bộ dữ liệu theo các tiêu chí
        /// </summary>
        /// <typeparam name="TEntity">Dạng thực thể được convert từ dữ liệu database</typeparam>
        /// <param name="query">Câu lệnh hoặc stored truy vấn; Default: null</param>
        /// <param name="param">Các tiêu chí truy vấn; Dạng: object; Hỗ trợ: DynamicParameters; Default: null</param>
        /// <param name="cmdType">Loại truy vấn(Text,Stored....); Default: Text</param>
        /// <returns>Danh sách dứ liệu</returns>
        /// CreatedBy: TLMinh (05/02/2021)
        public IEnumerable<TEntity> GetAll(string query = null, object param = null, CommandType cmdType = CommandType.Text)
        {
            // Hàm không tham só sẽ lấy toàn bộ giữ liệu
            if (query == null)
            {
                query = $"Select * from {typeof(TEntity).Name}";
                return _dbConnection.Query<TEntity>(query);
            }

            //Hàm có tham số sẽ lấy dữ liệu theo các tiêu chí
            //- hàm không truyền param
            if (param == null)
            {
                return _dbConnection.Query<TEntity>(query, commandType: cmdType);
            }

            //hàm có truyền param
            DynamicParameters dyParam = new DynamicParameters();
            var properties = param.GetType().GetProperties();

            foreach (var property in properties)
            {
                dyParam.Add( $"@{property.Name}",property.GetValue(param));
            }
            
            return _dbConnection.Query<TEntity>(query,dyParam,commandType: cmdType);
        }

        /// <summary>
        /// Thêm dữ liệu vào database
        /// </summary>
        /// <param name="entity">thực thể cần thêm</param>
        /// <returns>Số bản ghi được thêm</returns>
        /// CreatedBy: TLMinh (03/02/2021)
        public int Insert(TEntity entity)
        {
            var tableName = typeof(TEntity).Name;
            Type t = entity.GetType();
            var properties = t.GetProperties();
            var propertiesNameString = "";
            var propertiesValueString = "";
            DynamicParameters dynamicParameters = new DynamicParameters();

            foreach (var property in properties)
            {
                var nameProp = property.Name;
                var valueProperty = property.GetValue(entity);
                propertiesNameString += $", {nameProp}";
                propertiesValueString += $", @{nameProp}";


                if (property.Name.ToLower() == $"{tableName}Id".ToLower())
                    valueProperty = Guid.NewGuid().ToString();

                dynamicParameters.Add($"@{nameProp}", valueProperty);
            }

            propertiesValueString = propertiesValueString.Remove(0, 1);
            propertiesNameString = propertiesNameString.Remove(0,1);

            var executeString = $"INSERT INTO {tableName} ({propertiesNameString}) VALUES ({propertiesValueString})";

            return _dbConnection.Execute(executeString,param: dynamicParameters,commandType: CommandType.Text);
        }

        /// <summary>
        /// Xóa 1 bản ghi theo Id
        /// </summary>
        /// <param name="entityId">Id của thực thể cần xóa</param>
        /// <param name="way">Id của khóa ngoại(nếu có)</param>
        /// <returns>Số bẳn ghi bị xóa</returns>
        /// CreatedBy: TLMinh(06/02/2021)
        public virtual int Delete(string entityId,int way = 1)
        {
            var tableName = typeof(TEntity).Name;
            string executeString = $"DELETE FROM {tableName} WHERE {tableName}Id = '{entityId}'";
            return _dbConnection.Execute(executeString);
        }

        /// <summary>
        /// Sửa thông tin nhân viên
        /// </summary>
        /// <param name="entity">Thực thể nhân viên cần cập nhật thông tin</param>
        /// <returns>Số bản ghi bị sửa đổi</returns>
        /// CreatedBy: TLMinh (03/02/2021)
        public int Put(TEntity entity)
        {
            var tableName = typeof(TEntity).Name;
            Type t = entity.GetType();
            var properties = t.GetProperties();
            var propertiesNewSetString = "";
            DynamicParameters dynamicParameters = new DynamicParameters();
         
            foreach (var property in properties)
            {
                var nameProp = property.Name;
                var valueProperty = property.GetValue(entity);
                propertiesNewSetString += $", {nameProp} = @{nameProp}";

                dynamicParameters.Add($"@{nameProp}", valueProperty);
            }

            propertiesNewSetString = propertiesNewSetString.Remove(0, 1);
            var executeString = $"UPDATE {tableName} SET {propertiesNewSetString} WHERE {tableName}Id = @{tableName}Id";

            return _dbConnection.Execute(executeString, param: dynamicParameters, commandType: CommandType.Text);
        }

        #endregion
    }
}
