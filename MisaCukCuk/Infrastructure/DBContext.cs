using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Infrastructure
{
    public class IDBContext<TEntity>:IDbContext<TEntity>
    {
        #region Declare
        protected string _connectionString = Common.Properties.Resources.MySqlConnectionString;
        IDbConnection _dbConnection;
        #endregion
        #region Constructor
        public IDBContext()
        {
            this._dbConnection = new MySqlConnection(_connectionString);
        }

        #endregion
        #region Method
        
        public int Delete(Guid id)
        {
            var propName = $"{typeof(TEntity).Name}Id";
            var procName = $"Proc_Delete{typeof(TEntity).Name}";
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add($"{propName}", id);
            
            int deleted = _dbConnection.Execute(procName, parameters, commandType: CommandType.StoredProcedure);
            return deleted;
        }
        public IEnumerable<TEntity> GetAll()
        {
            var procName = $"Proc_Get{typeof(TEntity).Name}s";
            
            var entities = _dbConnection.Query<TEntity>(procName,commandType: CommandType.StoredProcedure);
            return entities;
        }

        public TEntity GetById(Guid id)
        {
            var propName = $"{typeof(TEntity).Name}Id";
            var procName = $"Proc_Get{typeof(TEntity).Name}ById";
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add($"{propName}", id);
            
            TEntity entity = _dbConnection.Query<TEntity>(procName, parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            return entity;
        }

        public int Insert(TEntity entity)
        {
            var properties = typeof(TEntity).GetProperties();
            DynamicParameters parameters = new DynamicParameters();
            var procName = $"Proc_Insert{typeof(TEntity).Name}";

            foreach (var property in properties)
            {
                var propValue = property.GetValue(entity);
                var propName = property.Name;
                parameters.Add(propName, propValue);
            }
            int inserted = _dbConnection.Execute(procName, parameters, commandType: CommandType.StoredProcedure);

            return inserted;
        }

        public int Update(TEntity entity)
        {
            var properties = typeof(TEntity).GetProperties();
            DynamicParameters parameters = new DynamicParameters();
            var procName = $"Proc_Update{typeof(TEntity).Name}";

            foreach (var property in properties)
            {
                var propValue = property.GetValue(entity);
                var propName = property.Name;
                parameters.Add(propName, propValue);
            }
            int updated = _dbConnection.Execute(procName, parameters, commandType: CommandType.StoredProcedure);

            return updated;
        }
        public bool CheckExist(string propName, string propValue)
        {
            var tableName = $"{typeof(TEntity).Name}";
            var sql = $"SELECT * FROM {tableName} WHERE {propName} = '{propValue}'";
            var entity = _dbConnection.Query<TEntity>(sql).FirstOrDefault();
            return entity != null ? true : false;
        }
        #endregion
    }
}
