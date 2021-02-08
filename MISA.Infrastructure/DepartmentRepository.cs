using Dapper;
using MISA.ApplicationCore.Entity;
using MISA.ApplicationCore.interfaces;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace MISA.Infrastructure
{
    public class DepartmentRepository : IDepartmentRepository
    {
        #region DECLARE
        DbContext dbContext = new DbContext();
        #endregion

        #region METHOD
        /// <summary>
        /// Lấy thông tin phòng ban theo id
        /// </summary>
        /// <param name="departmentId"></param>
        /// <returns>Thông tin phòng ban theo id</returns>
        /// CreatedBy: BDHIEU (01/02/2021)
        public string GetDepartmentById(int departmentId)
        {
            /*            var DepartmentName = db.Query<string>("Proc_GetDepartmentById", new { DepartmentId = departmentId }, commandType: CommandType.StoredProcedure).FirstOrDefault();
            */
            var DepartmentName = dbContext.GetData<string>("Proc_GetDepartmentById", new { DepartmentId = departmentId }, commandType: CommandType.StoredProcedure).FirstOrDefault();
            return DepartmentName;
        }

        /// <summary>
        /// Lấy danh sách phòng ban
        /// </summary>
        /// <returns>Danh sách phòng ban</returns>
        /// CreatedBy: BDHIEU (01/02/2021)
        public IEnumerable<EmployeeDepartment> GetDepartments()
        {
            var employeeDepartments = dbContext.GetAll<EmployeeDepartment>();
            return employeeDepartments;
        }
        #endregion
    }
}
