using Dapper;
using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.DataLayer
{
    public class DbContext2
    {
        public static string connectionString;

        public IDbConnection _dbConnection;

        public DbContext2()
        {
            _dbConnection = new MySqlConnection(connectionString);
        }
        public async Task<IEnumerable<TEntity>> GetData<TEntity>()
        {
            string className = typeof(TEntity).Name;
            var sql = $"SELECT * FROM {className}";
            var entities = await _dbConnection.QueryAsync<TEntity>(sql);
            return entities;
        }

        public IEnumerable<TEntity> GetData<TEntity>(string commandText)
        {
            string className = typeof(TEntity).Name;
            var sql = commandText;
            var entities = _dbConnection.Query<TEntity>(sql);
            return entities;
        }
        public TEntity GetById<TEntity>(object id)
        {
            string className = typeof(TEntity).Name;
            var sql = $"SELECT * FROM {className} WHERE {className}Id = '{id.ToString()}'";
            return _dbConnection.Query<TEntity>(sql).FirstOrDefault();
        }
        public async Task<int> Insert<TEntity>(TEntity entity)
        {
            string className = typeof(TEntity).Name;
            var properties = typeof(TEntity).GetProperties();
            var parameters = new DynamicParameters();
            var sqlPropetyBuider = string.Empty;
            var sqlPropetyParamBuider = string.Empty;
            foreach (var propety in properties)
            {
                var propertyName = propety.Name;
                var propertyValue = propety.GetValue(entity);
                parameters.Add($"@{propertyName}", propertyValue);
                sqlPropetyBuider += $",{propertyName}";
                sqlPropetyParamBuider += $",@{propertyName}";
            }
            var sql = $"INSERT INTO {className}({sqlPropetyBuider.Substring(1)}) VALUE ({sqlPropetyParamBuider.Substring(1)})";
            var effectRows = await _dbConnection.ExecuteAsync(sql, parameters);
            return effectRows;
        }
        /// <summary>
        /// Lấy danh sách 
        /// </summary>
        /// <typeparam name="TEntity">kiểu của đối tượng cần lấy về</typeparam>
        /// <returns>Trả về danh sách các object</returns>
        /// CreatedBy: NVMANH (12/12/2020)

    }
}
