using Dapper;
using Microsoft.Extensions.Configuration;
using Misa.BL.Interface.IRepository;
using Misa.BL.Entity;
using System.Data;
using System.Collections.Generic;
using Misa.BL.Interface.IDBContext;

namespace Misa.DL.EmployeeRepository
{
    public class EmployeeRepository : BaseRepository<Employee>, IEmployeeRepository
    {
        IDBConnector _iDbConnector;
        public EmployeeRepository(IDBConnector iDbConnector) : base(iDbConnector)
        {
            _iDbConnector = iDbConnector;
        }

        #region delete entity
        public int DeleteEmployeeByEmployeeCode(string code)
        {
            var storeName = $"Proc_DeleteEmployeeByEmployeeCode";
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add($"@EmployeeCode", code);
            var connector = base.GetDBConnection();
            int affect = connector.Execute(storeName, dynamicParameters, commandType: CommandType.StoredProcedure);
            return affect;
        }
        #endregion

        #region get employee code max
        public string GetEmployeeCodeMax()
        {
            var storeName = $"Proc_GetEmployeeCodeMax";
            var connector = base.GetDBConnection();
            string employeeCodeMax = (string)connector.ExecuteScalar(storeName, commandType: CommandType.StoredProcedure);
            return employeeCodeMax;
        }
        #endregion
    }
}
