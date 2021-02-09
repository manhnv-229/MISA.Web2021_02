using System;
using System.Collections.Generic;
using System.Text;
using Dapper;
using MySqlConnector;
using System.Data;
using System.Linq;
using MISA.Common.Models;

namespace MISA.DataLayer
{
    
    public class DbContext<MISAEntity>
    {
        /// Các biến
        #region DECLARE
        protected string _connectionString = "" +
                "Host = 103.124.92.43;" +
                "Port = 3306;" +
                "Database = MISACukCuk_MF731_NTTHIEM;" +
                "User Id = nvmanh;" +
                "Password = 12345678";
        protected IDbConnection _dbConnection;
        #endregion
        
        // Hàm khởi tạo
        #region Constructor
        public DbContext()
        {
            _dbConnection = new MySqlConnector.MySqlConnection(_connectionString);
        }
        #endregion

        // Phương thức
        #region Method


        /// <summary>
        /// Lất tất cả danh sách dựa vào kiểu truyền vào
        /// </summary>
        /// <returns>Các đối tượng lấy được</returns>
        /// CreatedBy: NTTHIEM
        /// CreatedDate: 08/02/2021
        public IEnumerable<MISAEntity> GetAll()
        {
            var className = typeof(MISAEntity).Name;
            //Truy vấn dữ liệu
            var entities = _dbConnection.Query<MISAEntity>($"SELECT * FROM {className}", commandType: CommandType.Text);
            //Trả về kết quả cho Client
            return entities;
        }

        /// <summary>
        /// Lấy dữ liệu
        /// </summary>
        /// <typeparam name="MISAEntity"></typeparam>
        /// <param name="sqlCommand">Truy vấn hoặc store</param>
        /// <param name="commandType">Mặc định là CommandType.Text</param>
        /// <returns>entities</returns>
        /// CreatedBy: NTTHIEM
        /// CreatedDate: 08/02/2021
        public IEnumerable<MISAEntity> GetAll(string sqlCommand, CommandType commandType = CommandType.Text)
        {
            //Thực thi truy vấn dữ liệu
            var entities = _dbConnection.Query<MISAEntity>(sqlCommand, commandType: commandType);
            //Trả về kết quả cho Client
            return entities;
        }

        /// <summary>
        /// Lấy dữ liệu theo nhiều tiêu chí khác nhau
        /// </summary>
        /// <typeparam name="MISAEntity">Type của đối tượng</typeparam>
        /// <param name="sqlCommand">Tên store hoặc câu truy vấn</param>
        /// <param name="parameters">Tham số đối tượng chứa thông tin tham số của store (tùy chọn)</param>
        /// <param name="commandType">Mặc định là CommandType.Text</param>
        /// <returns>Dữ liệu cần lấy</returns>
        /// CreatedBy: NTTHIEM
        /// CreatedDate: 06/02/2021
        public IEnumerable<MISAEntity> GetData(string sqlCommand, object parameters = null, CommandType commandType = CommandType.Text)
        {
            // Thực thi lấy dữ liệu:
            var data = _dbConnection.Query<MISAEntity>(sqlCommand, param: parameters, commandType: commandType);
            return data;
        }

        /// <summary>
        /// Thực hiện thêm mới object vào Database
        /// </summary>
        /// <param name="entity">object cần thêm mới</param>
        /// <returns>Số lượng bản ghi thêm được vào database</returns>
        /// CreatedBy: NTTHIEM
        /// CreatedDate: 07/02/2021
        public int InsertObject(MISAEntity entity)
        {
            var sqlPropName = string.Empty;
            var sqlPropValue = string.Empty;
            var sqlPropParam = string.Empty;
            var className = typeof(MISAEntity).Name;
            var sqlCommand = string.Empty;
            // Lấy ra các property của object
            var properties = typeof(MISAEntity).GetProperties();
            //DynamicParameters dynamicParameters = new DynamicParameters();
            foreach (var property in properties)
            {
                var propName = property.Name;
                var propValue = property.GetValue(entity);
                // Khi thêm mới thì sinh giá trị Guild mới cho khóa chính:
                if ((property.PropertyType == typeof(Guid) || property.PropertyType == typeof(Guid?)) && propName.ToLower() == $"{className}Id".ToLower())
                    // Tạo mới Guid
                    property.SetValue(entity, Guid.NewGuid());

                sqlPropName = sqlPropName + $",{propName}";
                sqlPropParam = sqlPropParam + $",@{propName}";
            }
            sqlPropName = sqlPropName.Remove(0, 1);
            sqlPropParam = sqlPropParam.Remove(0, 1);

            // Truy vấn
            sqlCommand = $"INSERT INTO {className}({sqlPropName}) VALUES ({sqlPropParam})";
            
            // Thực thi truy vấn
            var res = _dbConnection.Execute(sqlCommand,param: entity, commandType: CommandType.Text);
            return res;
        }

        
        #endregion
    }
}
