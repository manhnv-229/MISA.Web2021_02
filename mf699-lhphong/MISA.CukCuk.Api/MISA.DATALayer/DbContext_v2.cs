using MISA.DATALayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Dapper;
using MySql.Data.MySqlClient;

namespace MISA.DATALayer
{
    public class DbContext_v2<MisaEntity>: IDbContext<MisaEntity>
    {
        #region DECLARE
        protected string _connectionString = "" +
                "Host = 103.124.92.43;" +
                "Port = 3306;" +
                "Database = MS1_22_NDLuu_CukCuk;" +
                "User Id = nvmanh;" +
                "Password = 12345678;";
        protected IDbConnection _dbConnection;
        #endregion

        #region Constructor
        public DbContext_v2()
        {
            _dbConnection = new MySqlConnection(_connectionString);
        }
        #endregion

        #region Method
        public IEnumerable<MisaEntity> GetAll()
        {
            var className = typeof(MisaEntity).Name;
            //thực thi truy vấn dữ liệu
            var entities = _dbConnection.Query<MisaEntity>($"SELECT * FROM {className}", commandType: CommandType.Text);

            //Trả về dữ liệu khách hàng
            return entities;
        }

        public IEnumerable<MisaEntity> GetAll(string sqlCommand, CommandType commandType = CommandType.Text)
        {
            var entities = _dbConnection.Query<MisaEntity>(sqlCommand, commandType: commandType);

            //Trả về dữ liệu khách hàng
            return entities;
        }

        public IEnumerable<MisaEntity> GetData(string sqlCommand, object parameters = null, CommandType commandType = CommandType.Text)
        {
            var data = _dbConnection.Query<MisaEntity>(sqlCommand, parameters, commandType: commandType);
            return data;
        }


        /// <summary>
        /// Thêm mới
        /// </summary>
        /// <param name="entity">đối tượng thêm mới</param>
        /// <returns>Status Code</returns>
        /// CreatedBy : LHPHONG (8/1/2021)
        public int InsertObject(MisaEntity entity)
        {
            var sqlPropName = string.Empty;
            var sqlPropValue = string.Empty;
            var sqlPropParam = string.Empty;
            var className = typeof(MisaEntity).Name;
            var sqlCommand = string.Empty;

            var properties = typeof(MisaEntity).GetProperties();

            foreach (var property in properties)
            {
                var propName = property.Name;
                var propValue = property.GetValue(entity);

                if ((property.PropertyType == typeof(Guid) || property.PropertyType == typeof(Guid?)) && propName.ToLower() == $"{className}Id".ToLower())
                {
                    property.SetValue(entity, Guid.NewGuid());
                }

                sqlPropName = sqlPropName + $", {propName}";
                sqlPropParam = sqlPropParam + $", @{propName}";
            }

            sqlPropName = sqlPropName.Remove(0, 1);
            sqlPropValue = sqlPropValue.Remove(0, 1);
            sqlCommand = $"INSERT INTO {className}({sqlPropName}) VALUE({sqlPropParam})";

            var res = _dbConnection.Execute(sqlCommand, param: entity, commandType: CommandType.Text);
            return res;
        }

        #endregion
    }
}
