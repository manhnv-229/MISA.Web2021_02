using Common.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Infrastructure
{
    public class DBContextV2<TEntity> : IDbContext<TEntity>
    {
        #region Declare
        protected string _connectionString = Common.Properties.Resources.MariaDBConnectionString;
        IDbConnection _dbConnection;
        #endregion
        #region Constructor
        public DBContextV2()
        {
            this._dbConnection = new MySqlConnection(_connectionString);
        }

        #endregion
        #region Method
        public bool CheckExist(string propName, string propValue)
        {
            throw new NotImplementedException();
        }

        public int Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TEntity> GetAll()
        {
            throw new NotImplementedException();
        }

        public TEntity GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public int Insert(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public int Update(TEntity entity)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
