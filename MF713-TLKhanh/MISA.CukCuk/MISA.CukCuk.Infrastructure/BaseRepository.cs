using Dapper;
using Microsoft.Extensions.Configuration;
using MISA.CukCuk.Core.Interfaces;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace MISA.CukCuk.Infrastructure
{
    public class BaseRepository<T> : IBaseRepository<T>
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
        protected IDbConnection _dbConnection;
        protected string _className;
        #endregion
        #region Constructor
        public BaseRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("DevConnection");
            _dbConnection = new MySqlConnection(_connectionString);
            _className = typeof(T).Name;
        }
        #endregion

        #region Method
        public IEnumerable<T> Get(string sqlcommand = null, object parameters = null, CommandType commandType = CommandType.Text)
        {

            if (sqlcommand == null)
                return _dbConnection.Query<T>($"Select * from {_className}");
            return _dbConnection.Query<T>(sqlcommand, parameters, commandType: commandType);

        }

        public T GetById(string id)
        {
            var _params = new DynamicParameters();
            _params.Add($"{_className}Id", id);
            return _dbConnection.Query<T>($"Select * from {_className} Where {_className}Id = @{_className}Id", _params).FirstOrDefault();
        }

        public int Insert(T entity)
        {
            var res = _dbConnection.Execute(
                $"Proc_Insert{_className}",
                MappingParams(entity),
                commandType: CommandType.StoredProcedure
                );
            return res;
        }

        public int Update(string id, T entity)
        {
            var _params = MappingParams(entity);
            _params.Add($"@{_className}Id", id);
            var res = _dbConnection.Execute(
                $"Proc_Update{_className}",
                _params,
                commandType: CommandType.StoredProcedure
                );
            return res;
        }

        public int Delete(string id)
        {
            var _param = new DynamicParameters();
            _param.Add($"{_className}Id", id);
            var res = _dbConnection.Execute(
                $"Proc_Delete{_className}",
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
        #endregion

    }
}
