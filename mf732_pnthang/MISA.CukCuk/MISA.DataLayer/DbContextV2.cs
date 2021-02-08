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
    class DbContextV2<MISAEntity>
    {
        #region DECLARE
        protected string _connectionString = "" +
                "Host = 103.124.92.43;" +
                "Port = 3306;" +
                "Database = MISACukCuk_MF732_PNTHANG2;" +
                "User Id = nvmanh;" +
                "Password = 12345678";
        protected IDbConnection _dbConnection;
        #endregion

        // Hàm khởi tạo
        #region Constructor
        public DbContextV2()
        {
            _dbConnection = new MySqlConnector.MySqlConnection(_connectionString);
        }
        #endregion

        // Phương thức
        #region Method


        /// <summary>
        /// Lất tất cả danh sách dựa vào kiểu truyền vào
        /// </summary>
        /// <returns>các đối tượng lấy được</returns>
        /// CreatedBy: PNTHANG (08/02/2021)
        public IEnumerable<MISAEntity> GetAll()
        {
            var className = typeof(MISAEntity).Name;
            //Thực thi truy vấn dữ liệu
            var entities = _dbConnection.Query<MISAEntity>($"SELECT * FROM {className}", commandType: CommandType.Text);
            //Trả về kết quả cho Client
            return entities;
        }
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
        /// CreatedBy: PNTHANG (06/02/2021)
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
            var res = _dbConnection.Execute(sqlCommand, param: entity, commandType: CommandType.Text);
            return res;
        }


        #endregion
    }
}
