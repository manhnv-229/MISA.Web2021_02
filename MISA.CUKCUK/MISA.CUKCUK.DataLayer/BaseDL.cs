using Dapper;
using MISA.DataLayer.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace MISA.DataLayer
{
    public class BaseDL<T>: IBaseDL<T> where T: class
    {
        private readonly IDbContext<T> _dbContext;

        public BaseDL(IDbContext<T> dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<T> GetAll()
        {
            var procName = "Proc_GetAll" + typeof(T).Name;
            var listEntity = _dbContext.Query(procName, commandType: CommandType.StoredProcedure);
            return listEntity;
        }

        public T GetById(Guid id)
        {
            var procName = "Proc_Get" + typeof(T).Name + "ById" ;
            var param = new
            {
                id = id.ToString()
            };
            var parameters = new DynamicParameters(param);
            var listEntity = _dbContext.QueryFirst(procName, parameters, commandType: CommandType.StoredProcedure);
            return listEntity;
        }

        public int Insert(T entity)
        {
            var procName = "Proc_Insert" + typeof(T).Name;
            var parameters = new DynamicParameters(entity);
            var result = _dbContext.Excute(procName, parameters, CommandType.StoredProcedure);
            return result;
        }

        public int Update(T entity)
        {
            var procName = "Proc_Update" + typeof(T).Name;
            var parameters = new DynamicParameters(entity);
            var result = _dbContext.Excute(procName, parameters, CommandType.StoredProcedure);
            return result;
        }

        public int Delete(Guid id)
        {
            var procName = "Proc_Delete" + typeof(T).Name;
            var parameters = new DynamicParameters(id);
            var result = _dbContext.Excute(procName, parameters, CommandType.StoredProcedure);
            return result;
        }
    }
}
