using Dapper;
using Microsoft.Extensions.Configuration;
using MISA.ApplicationCore.Entity;
using MISA.ApplicationCore.interfaces;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;

namespace MISA.Infrastructure
{
    public class EmployeeRepository : IEmployeeRepository
    {
        #region DECLARE
        IConfiguration _configuration;
        string _connectionString = string.Empty;
        IDbConnection _dbConnection;
        DbContext dbContext = new DbContext();
        #endregion

        #region Constructor
        public EmployeeRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("HieuConnectionString");
            _dbConnection = new MySqlConnection(_connectionString);
        }
        #endregion

        #region Method
        /// <summary>
        /// Thêm mới nhân viên
        /// </summary>
        /// <param name="employee"></param>
        /// <returns>Số bản ghi thêm thành công</returns>
        /// CreatedBy: BDHIEU (01/02/2021)
        public int AddEmployee(Employee employee)
        {
            var rowAffects = dbContext.InsertData("Proc_InsertEmployee", employee, commandType: CommandType.StoredProcedure);
            return rowAffects;
        }

        /// <summary>
        /// Xóa nhân viên
        /// </summary>
        /// <param name="employeeId"></param>
        /// <returns>Số bản ghi xóa thành công</returns>
        /// CreatedBy: BDHIEU (01/02/2021)
        public int DeleteEmployee(Guid employeeId)
        {
            var res = dbContext.DeleteData("Proc_DeleteEmployee", new { EmployeeId = employeeId.ToString() }, commandType: CommandType.StoredProcedure);
            return res;
        }

        /// <summary>
        /// Lấy danh sách nhân viên
        /// </summary>
        /// <returns>Danh sách nhân viên</returns>
        /// CreatedBy: BDHIEU (01/02/2021)
        public IEnumerable<Employee> GetEmployees()
        {
            var employees = dbContext.GetAll<Employee>();
            return employees;
        }

        /// <summary>
        /// Cập nhật thông tin nhân viên
        /// </summary>
        /// <param name="employee"></param>
        /// <returns>Số bản ghi cập nhật thành công</returns>
        /// CreatedBy: BDHIEU (01/02/2021)
        public int UpdateEmployee(Employee employee)
        {
            var rowAffects = dbContext.InsertData("Proc_UpdateEmployee", employee, commandType: CommandType.StoredProcedure);
            return rowAffects;
        }

        public DynamicParameters MappingDbType<T>(T entity)
        {
            var properties = entity.GetType().GetProperties();
            var parameters = new DynamicParameters();
            foreach (var property in properties)
            {
                var propertyName = property.Name;
                var propertyValue = property.GetValue(entity);
                var propertyType = property.PropertyType;
                if (propertyType == typeof(Guid) || propertyType == typeof(Guid?))
                {
                    parameters.Add($"@{propertyName}", propertyValue, DbType.String);
                }
                else
                {
                    parameters.Add($"@{propertyName}", propertyValue);
                }
            }
            return parameters;
        }

        /// <summary>
        /// Lấy thông tin nhân viên theo id
        /// </summary>
        /// <param name="employeeId"></param>
        /// <returns>Thông tin nhân viên theo id</returns>
        /// CreatedBy: BDHIEU (01/02/2021)
        public Employee GetEmployeeById(Guid employeeId)
        {
            //var employee = db.Query<Employee>("Proc_GetEmployeeById", new { EmployeeId = employeeId.ToString() }, commandType: CommandType.StoredProcedure).FirstOrDefault();
            var employee = dbContext.GetData<Employee>("Proc_GetEmployeeById", new { EmployeeId = employeeId.ToString() }, commandType: CommandType.StoredProcedure).FirstOrDefault();
            return employee;
        }

        /// <summary>
        /// Lấy mã nhân viên lớn nhất
        /// </summary>
        /// <returns>Mã nhân viên lớn nhất</returns>
        /// CreatedBy: BDHIEU (01/02/2021)
        public string GetMaxEmployeeCode()
        {
            IDbConnection db = new MySqlConnection("Host=103.124.92.43; User Id=nvmanh; password=12345678; Database=MS4_08_BDHieu_CukCuk; Character Set=utf8");
            var maxEmployeeCode = db.Query<string>("SELECT EmployeeCode FROM Employee e ORDER BY e.EmployeeCode DESC limit 1", commandType: CommandType.Text).FirstOrDefault();
            return maxEmployeeCode;
        }

        /// <summary>
        /// Lấy danh sách nhân viên nối với bảng vị trí và phòng ban
        /// </summary>
        /// <returns>Danh sách nhân viên nối với bảng vị trí và phòng ban</returns>
        /// CreatedBy: BDHIEU (01/02/2021)
        public IEnumerable<EmployeeInfo> GetEmployeeInfos()
        {
            var employeeInfos = dbContext.GetAll<EmployeeInfo>();
            return employeeInfos;
        }

        /// <summary>
        /// Lấy số lượng nhân viên
        /// </summary>
        /// <returns>Số lượng nhân viên</returns>
        /// CreatedBy: BDHIEU (01/02/2021)
        public int GetNumberOfEmployee()
        {
            IDbConnection db = new MySqlConnection("Host=103.124.92.43; User Id=nvmanh; password=12345678; Database=MS4_08_BDHieu_CukCuk; Character Set=utf8");
            var numberOfEmployee = db.Query<int>("Proc_GetNumberOfEmployee", commandType: CommandType.Text).FirstOrDefault();
            return numberOfEmployee;
        }

        /// <summary>
        /// Xóa nhiều nhân viên
        /// </summary>
        /// <param name="employeeIdStr"></param>
        /// CreatedBy: BDHIEU (01/02/2021)
        public void DeleteMultiesEmployee(Guid[] employeeIdStr)
        {
            IDbConnection db = new MySqlConnection("Host=103.124.92.43; User Id=nvmanh; password=12345678; Database=MS4_08_BDHieu_CukCuk; Character Set=utf8");
            for(int i = 0; i<employeeIdStr.Length; i++)
            {
                db.Execute("Proc_DeleteEmployee", new { EmployeeId = employeeIdStr[i].ToString() }, commandType: CommandType.StoredProcedure);
            }
        }

        /// <summary>
        /// Lấy danh sách nhân viên theo vị trí công việc
        /// </summary>
        /// <param name="positionId"></param>
        /// <returns>Danh sách nhân viên theo vị trí công việc</returns>
        /// CreatedBy: BDHIEU (01/02/2021)
        public IEnumerable<EmployeeInfo> GetEmployeeByPosition(int positionId)
        {
            var employeeInfos = dbContext.GetData<EmployeeInfo>("Proc_GetEmployeeByPosition", new { PositionId = positionId }, commandType: CommandType.StoredProcedure);
            return employeeInfos;
        }

        /// <summary>
        /// Lấy danh sách nhân viên theo phòng ban
        /// </summary>
        /// <param name="departmentId"></param>
        /// <returns>Danh sách nhân viên theo phòng ban</returns>
        /// CreatedBy: BDHIEU (01/02/2021)
        public IEnumerable<EmployeeInfo> GetEmployeeByDepartment(int departmentId)
        {
            var employeeInfos = dbContext.GetData<EmployeeInfo>("Proc_GetEmployeeByDepartment", new { DepartmentId = departmentId }, commandType: CommandType.StoredProcedure);
            return employeeInfos;
        }

        public IEnumerable<EmployeeInfo> GetEmployeeBySearchText(string searchText)
        {
            var employeeList = dbContext.GetData<EmployeeInfo>("Proc_SearchEmployeeByText", new { SearchText = searchText }, commandType: CommandType.StoredProcedure);
            return employeeList;
        }

        /// <summary>
        /// Lấy danh sách nhân viên theo vị trí và số lượng nhân viên
        /// </summary>
        /// <param name="positionStart"></param>
        /// <param name="offset"></param>
        /// <returns>Danh sách nhân viên theo vị trí và số lượng nhân viên</returns>
        /// CreatedBy: BDHIEU (04/02/2021)
        public IEnumerable<EmployeeInfo> GetEmployeeByIndexAndOffset(int positionStart, int offset)
        {
            var employeeList = dbContext.GetData<EmployeeInfo>("Proc_GetEmployeeByIndexAndOffset", new { positionStart = positionStart, offset = offset }, commandType: CommandType.StoredProcedure);
            return employeeList;
        }
        #endregion
    }
}
