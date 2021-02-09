using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;

namespace MISA.DataLayer
{
    public class DBConnectorV2<TEntity> : IDBConnector<TEntity>
    {
        #region DECLARE
        IConfiguration _configuration;
        IDbConnection _db;
        string _connectionString;
        //string _connectionString = "Host=103.124.92.43;Port=3306; User Id=nvmanh;Password=12345678;Database=MS2_30_Trinh_CukCuk;Character Set=utf8";
        #endregion

        #region Constructor
        //protected IDbConnection _db;
        //public DBConnector()
        //{
        //    _db = new MySqlConnection(_connectionString);
        //}
        public DBConnectorV2(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("TXTConnectionV2");
            _db = new MySqlConnection(_connectionString);
        }
        #endregion

        #region Method
        /// <summary>
        /// Lấy danh sách
        /// </summary>
        /// <typeparam name="TEntity">Kiểu của object</typeparam>
        /// <returns>List các object lấy đc</returns>
        /// CreatedBy: TXTrinh (02/02/2021)
        public IEnumerable<TEntity> GetAll()
        {
            string className = typeof(TEntity).Name;
            string proc = $"Proc_Get{className}s";
            var entities = _db.Query<TEntity>(proc, commandType: CommandType.StoredProcedure);
            return entities;
        }
        #endregion
    }
}
