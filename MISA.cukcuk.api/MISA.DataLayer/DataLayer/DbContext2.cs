using Dapper;
using MISA.Common.Model;
using MISA.DataLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace MISA.DataLayer.InterMiLan
{
    public class DbContext2<MISAEntity>:IBaseData<MISAEntity>
    {
        protected string _connectionString = "" +
            "Host = 103.124.92.43;" +
            "Port = 3306;" +
            "Database = MF717_Hung_Nguyen_Huu;" +
            "User Id = nvmanh;" +
            "Password = 12345678;";
        protected IDbConnection _dbConnection;
        public DbContext2()
        {
            _dbConnection = new MySqlConnector.MySqlConnection(_connectionString);
        }
        public IEnumerable<MISAEntity> GetAll()
        {
            var className = typeof(MISAEntity).Name;

            var res = _dbConnection.Query<MISAEntity>($"select * from {className}", commandType: CommandType.Text);

            return res;
        }

        public int InsertObject(object entity)
        {
            return -9999;
        }
    }
}
