using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using MySql.Data.MySqlClient;
namespace MISA.DataLayer.Base
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class, new()
    {
        public DbContext1 _context;

        public GenericRepository()
        {
            _context = new DbContext1();
        }

        public async Task<IEnumerable<TEntity>> GetData()
        {
            string className = typeof(TEntity).Name;
            var sql = $"SELECT * FROM {className}";
            var entities = await _context._dbConnection.QueryAsync<TEntity>(sql);
            return entities;
        }
        public async Task<IEnumerable<TEntity>> GetData(string sql)
        {
            //string className = typeof(TEntity).Name;
            //var sql = $"SELECT * FROM {className}";
            var entities = await _context._dbConnection.QueryAsync<TEntity>(sql);
            return entities;
        }

        //public IEnumerable<TEntity> GetData(string commandText)
        //{
        //    throw new NotImplementedException();
        //}

        //public async Task<int> Insert<TEntity>(TEntity entity)
        //{
        //    string className = typeof(TEntity).Name;
        //    var properties = typeof(TEntity).GetProperties();
        //    var parameters = new DynamicParameters();
        //    var sqlPropetyBuider = string.Empty;
        //    var sqlPropetyParamBuider = string.Empty;
        //    foreach (var propety in properties)
        //    {
        //        var propertyName = propety.Name;
        //        var propertyValue = propety.GetValue(entity);
        //        parameters.Add($"@{propertyName}", propertyValue);
        //        sqlPropetyBuider += $",{propertyName}";
        //        sqlPropetyParamBuider += $",@{propertyName}";
        //    }
        //    var sql = $"INSERT INTO {className}({sqlPropetyBuider.Substring(1)}) VALUE ({sqlPropetyParamBuider.Substring(1)})";
        //    var effectRows = await _context._dbConnection.ExecuteAsync(sql, parameters);
        //    return effectRows;
        //}
    }
}
