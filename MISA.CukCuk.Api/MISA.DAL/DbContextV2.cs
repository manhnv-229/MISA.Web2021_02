using Microsoft.Extensions.Configuration;
using MISA.Common.Interfaces;
using System.Collections.Generic;
using System.Data;
using Dapper;
using MySqlConnector;

namespace MISA.DAL
{
    public class DbContextV2<MISAEntity> : IDbContext<MISAEntity>
    {
        #region Declare
        IConfiguration _configuration;
        IDbConnection _dbConnection;
        string _connectionString;
        #endregion

        #region Constructor
        public DbContextV2(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("MISACukCukConnectionV2");
            _dbConnection = new MySqlConnection(_connectionString);
        }
        #endregion

        #region Method
        public IEnumerable<MISAEntity> Get(string sqlCommand, CommandType commandType)
        {
            return _dbConnection.Query<MISAEntity>(sqlCommand, commandType: commandType);
        }

        public int ExcuteNonQuery(string sqlCommand, DynamicParameters parameters, CommandType commandType)
        {
            return _dbConnection.Execute(sqlCommand, parameters, commandType: commandType);
        }
        #endregion
    }
}
