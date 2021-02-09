using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace MISA.DataLayer
{
    public class DbConnectorV2 : DbConnection, IDbConnector
    {
        public DbConnectorV2() { }

        public int DeleteById<T>(object id)
        {
            var tableName = typeof(T).Name;
            var storeName = $"Proc_Delete{tableName}";
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add($"@{tableName}Id", id);// CustomerGroupId = id;
            _dbConnection.Query<T>(storeName, dynamicParameters, commandType: CommandType.StoredProcedure);
            return 0;
        }
       

        public IEnumerable<T> GetAllData<T>()
        {
            var tableName = typeof(T).Name;
            var storeName = $"Proc_Get{tableName}s";
            return _dbConnection.Query<T>(storeName, commandType: CommandType.StoredProcedure);
        }

        public IEnumerable<T> GetAllData<T>(int PageNumber, int Limit)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetAllData<T>(string commandText)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Department> GetAllDepartment<Department>()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetAllEmployeeByDepartment<T>(string department)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetAllEmployeeByPosition<T>(string position)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Position> GetAllPosition<Position>()
        {
            throw new NotImplementedException();
        }

        public T GetById<T>(object id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetMaxCode<T>()
        {
            throw new NotImplementedException();
        }

        public int Insert<T>(T entity)
        {
            throw new NotImplementedException();
        }

        public int ModifiedEntity<T>(T entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> SearchOther<T>(string searchText, Guid? DepartmentId = null, Guid? PositionId = null)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> SearchOther<T>(string PositionSearch, string DepartmentSearch)
        {
            throw new NotImplementedException();
        }
    }
}
