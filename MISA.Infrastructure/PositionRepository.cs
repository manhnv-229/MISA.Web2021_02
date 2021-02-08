using Dapper;
using MISA.ApplicationCore.Entity;
using MISA.ApplicationCore.interfaces;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace MISA.Infrastructure
{
    public class PositionRepository : IPositionRepository
    {
        #region DECLARE
        DbContext dbContext = new DbContext();
        #endregion

        #region CONSTRUCTOR
        #endregion

        #region METHOD
        /// <summary>
        /// Lấy danh sách vị trí công việc
        /// </summary>
        /// <returns>Danh sách vị trí công việc</returns>
        /// CreatedBy: BDHIEU (01/02/2021)
        public IEnumerable<EmployeePosition> GetPositions()
        {
            var employeePositions = dbContext.GetAll<EmployeePosition>();
            return employeePositions;
        }
        #endregion
    }
}
