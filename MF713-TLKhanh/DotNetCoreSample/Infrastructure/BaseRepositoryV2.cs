using AplicationCore.Entities;
using AplicationCore.Interfaces;
using Dapper;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Infrastructure
{
    public class BaseRepositoryV2<T> : IBaseRepository<T>
    {
        #region Declare
        /// <summary>
        /// Biến config
        /// </summary>
        IConfiguration _configuration;
        /// <summary>
        /// Chuỗi kết nối
        /// </summary>
        string _connectionString;
        /// <summary>
        /// Đối tượng tương tác với database
        /// </summary>
        IDbConnection _dbConnection;
        string className;
        #endregion
        #region Constructor
        public BaseRepositoryV2(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("OtherConnection");
            _dbConnection = new MySqlConnection(_connectionString);
            className = typeof(T).Name;
        }
        #endregion
        #region Method
        public IEnumerable<T> Get(string sqlcommand = null, object parameters = null, CommandType commandType = CommandType.Text)
        {

            if (sqlcommand == null)
                return _dbConnection.Query<T>($"Select * from {className}");
            return _dbConnection.Query<T>(sqlcommand, parameters, commandType: commandType);

        }

        public int Insert(T entity)
        {
            var properties = entity.GetType().GetProperties();
            var propParam = "";
            var valueParam = "";
            foreach (var property in properties)
            {
                var propName = property.Name;
                propParam += $",{propName}";
                valueParam += $",@{propName}";
            }
            propParam.Remove(0, 1);
            valueParam.Remove(0, 1);
            var sqlCommand = $"INSERT INTO {className}({propParam}) VALUES ({valueParam})";
            var res = _dbConnection.Execute(
                sqlCommand,
                entity
                );
            return res;
        }

        public int Update(string id, T entity)
        {
            var res = _dbConnection.Execute(
                $"Proc_Update{className}ById",
                MappingParams(entity),
                commandType: CommandType.StoredProcedure
                );
            return res;
        }

        public int Delete(string id)
        {
            var _param = new DynamicParameters();
            _param.Add($"{className}Id", id);
            var res = _dbConnection.Execute(
                $"Proc_Delete{className}ById",
                _param,
                commandType: CommandType.StoredProcedure
                );
            return res;
        }

        /// <summary>
        /// Mapping các tham số truyền từ boby
        /// </summary>
        /// <param name="customer">Một Object</param>
        /// <returns>Các tham số theo định dạng của dapper</returns>
        /// CreatedBy: TLKHANH (6/2/2021)
        public DynamicParameters MappingParams(T entity)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            var properties = typeof(T).GetProperties();
            foreach (var property in properties)
            {
                var propName = property.Name;
                var propValue = property.GetValue(entity);
                dynamicParameters.Add($"@{propName}", propValue);
            }
            return dynamicParameters;
        }
        
        public T GetById(string id)
        {
            throw new NotImplementedException();
        }
        #endregion

    }
}
