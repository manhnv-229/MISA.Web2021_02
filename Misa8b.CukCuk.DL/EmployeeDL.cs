using Dapper;
using Misa.CukCuk.Common;
using Misa8b.CukCuk.DL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Misa8b.CukCuk.DL
{
    /// <summary>
    /// kết nối với db
    /// </summary>
    public class EmployeeDL: BaseDL<Employee>, IEmployeeDL
    {
        /// <summary>
        /// lấy nhân viên bằng code, tên và số điện thoại
        /// </summary>
        /// <param name="employeecode"></param>
        /// <param name="fullname"></param>
        /// <param name="phonenumber"></param>
        /// <returns></returns>
        public List<Employee> GetEmployeeByOthers(string employeecode, string fullname, string phonenumber)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add($"@EmployeeCodeContaints", employeecode);
            dynamicParameters.Add($"@FullNameContaints", fullname);
            dynamicParameters.Add($"@PhoneNumberContaints", phonenumber);
            return dbConnection.Query<Employee>($"Proc_GetEmployeeByOthers", dynamicParameters, commandType: CommandType.StoredProcedure).ToList();
        }
        /// <summary>
        /// lấy nhân viên bằng phòng ban và vị trí
        /// </summary>
        /// <param name="dep"></param>
        /// <param name="posi"></param>
        /// <returns>danh sách nhân viên</returns>
        public List<Employee> GetEmployeeByDepAndPosi (string dep, string posi)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add($"@DepartmentName", dep);
            dynamicParameters.Add($"@PositionName", posi);
            return dbConnection.Query<Employee>($"Proc_GetEmployeeByDepAndPosi", dynamicParameters, commandType: CommandType.StoredProcedure).ToList();
        }
        /// <summary>
        /// lấy nhân viên bằng vị trí
        /// </summary>
        /// <param name="posi"></param>
        /// <returns></returns>
        public List<Employee> GetEmployeeByPosi(string posi)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add($"@PositionName", posi);
            return dbConnection.Query<Employee>($"Proc_GetEmployeeByPossition", dynamicParameters, commandType: CommandType.StoredProcedure).ToList();
        }
        /// <summary>
        /// lấy nhân viên bằng phòng ban
        /// </summary>
        /// <param name="dep"></param>
        /// <returns></returns>
        public List<Employee> GetEmployeeByDep(string dep)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add($"@DepartmentName", dep);
            return dbConnection.Query<Employee>($"Proc_GetEmployeeByDep", dynamicParameters, commandType: CommandType.StoredProcedure).ToList();
        }
    }
}
