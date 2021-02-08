using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Dapper;
using MySql.Data.MySqlClient;

namespace MISA.DataLayer.Contexts
{
    public class DbContextV2<TEntity> : IDbContext<TEntity>
    {
        /// <summary>
        /// chuỗi kết nối đến DB: MF716_LVHOANG
        /// </summary>
        public string connectionString = "Host = 103.124.92.43;" +
            "Port= 3306;" +
            "Database =MF716_LVHOANG;" +
            "User Id = nvmanh;" +
            "Password = 12345678;" +
            "Character Set=utf8";

        protected IDbConnection _dbConnection;

        
        public DbContextV2()
        {
            _dbConnection = new MySqlConnection(connectionString);
        }
        
        public IEnumerable<TEntity> GetAll()
        {
            string className = typeof(TEntity).Name;

            var entities = _dbConnection.Query<TEntity>($"{className}_GetAll", commandType: CommandType.StoredProcedure);
            return entities;
        }

        public TEntity GetById(object id)
        {
            string className = typeof(TEntity).Name;
            var sql = $"SELECT * FROM {className} WHERE {className}Id = '{id.ToString()}'";
            return _dbConnection.Query<TEntity>(sql).FirstOrDefault();
        }

        public IEnumerable<TEntity> GetData(string commandText)
        {
            
            var sql = commandText;
            var entities = _dbConnection.Query<TEntity>(sql);
            return entities;
        }

        public int Insert(TEntity entity)
        {
            string className = typeof(TEntity).Name;

            var effectRows = _dbConnection.Execute($"{className}_Insert", entity, commandType: CommandType.StoredProcedure);
            return effectRows;
        }

        public int Update(TEntity entity, Guid id)
        {
            string className = typeof(TEntity).Name;
            var type = entity.GetType();
            var delegateProperty = type.GetProperty($"{className}Id");
            delegateProperty.SetValue(entity, id);

            var effectRows = _dbConnection.Execute($"{className}_Update", entity, commandType: CommandType.StoredProcedure);
            return effectRows;
        }

        public int Delete(object id)
        {
            throw new NotImplementedException();
        }
    }
}
