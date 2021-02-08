using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace MISA.DataLayer
{
    public class DbConnection
    {
        #region Declare
        protected IDbConnection _dbConnection;
        public static string _connectionString;
        #endregion

        #region Constuctor
        public DbConnection()
        {
            _dbConnection = new MySqlConnection(_connectionString);
        }
        #endregion
    }
}
