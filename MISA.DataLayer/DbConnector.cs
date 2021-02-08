using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.DataLayer
{
    
    public class DbConnector : DbConnection , IDbConnector
    {
        
        public DbConnector()
        {
        }
        /// <summary>
        /// Lấy danh sách nhân viên
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public IEnumerable<T> GetAllData<T>()
        {
            var tableName = typeof(T).Name;
            var storeName = $"Proc_Get{tableName}s";
            return _dbConnection.Query<T>(storeName, commandType: CommandType.StoredProcedure);
        }
        /// <summary>
        /// Lấy danh sách phòng ban
        /// </summary>
        /// <typeparam name="Department"></typeparam>
        /// <returns></returns>
        public IEnumerable<Department> GetAllDepartment<Department>()
        {
            var storeName = $"Proc_GetAllDepartment";
            return _dbConnection.Query<Department>(storeName, commandType: CommandType.StoredProcedure);
        }
        /// <summary>
        /// Lấy danh sách vị trí/ chức vụ
        /// </summary>
        /// <typeparam name="Position"></typeparam>
        /// <returns></returns>
        public IEnumerable<Position> GetAllPosition<Position>()
        {
            var storeName = $"Proc_GetAllPosition";
            return _dbConnection.Query<Position>(storeName, commandType: CommandType.StoredProcedure);
        }
        /// <summary>
        /// Lấy danh sách nhân viên theo trang
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="PageNumber"> vị trí trang</param>
        /// <param name="Limit">Số lượng giới hạn</param>
        /// <returns>Danh sách nhân viên theo trang</returns>
        public IEnumerable<T> GetAllData<T>(int PageNumber, int Limit)
        {
            var tableName = typeof(T).Name;
            var storeName = $"Proc_Get{tableName}Paging";
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add($"@{tableName}PageNumber", PageNumber);
            dynamicParameters.Add($"@{tableName}LimitParam", Limit);
            return _dbConnection.Query<T>(storeName,dynamicParameters, commandType: CommandType.StoredProcedure);
        } 
        /// <summary>
        /// Lấy danh sách nhân viên theo vị trí
        /// </summary>
        /// <typeparam name="T">Kiểu dữ liệu trả về</typeparam>
        /// <param name="position">tên vị trí/ chức vụ</param>
        /// <returns>Danh sách nhân viên theo vị trí/chức vụ</returns>
        public IEnumerable<T> GetAllEmployeeByPosition<T>(string position)
        {
            var tableName = typeof(T).Name;
            var storeName = $"Proc_Get{tableName}WithPositionName";
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add($"@{tableName}PositionName", position);
            return _dbConnection.Query<T>(storeName,dynamicParameters, commandType: CommandType.StoredProcedure);
        }
        /// <summary>
        /// Lấy danh sách nhân viên theo phòng ban
        /// </summary>
        /// <typeparam name="T">Kiểu dữ liệu trả về</typeparam>
        /// <param name="department">Tên phòng ban</param>
        /// <returns>Danh sách nhân viên theo phòng ban</returns>
        public IEnumerable<T> GetAllEmployeeByDepartment<T>(string department)
        {
            var tableName = typeof(T).Name;
            var storeName = $"Proc_Get{tableName}WithDepartmentName";
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add($"@{tableName}DepartmentName", department);
            return _dbConnection.Query<T>(storeName,dynamicParameters, commandType: CommandType.StoredProcedure);
        }
        /// <summary>
        /// Tìm kiếm nhân viên theo keywords
        /// </summary>
        /// <typeparam name="T">Kiểu dữ liệu trả về</typeparam>
        /// <param name="searchText">keyword: Mã nhân viên, Tên nhân viên, Số điện thoại</param>
        /// <returns>Trả về danh sách theo keyword</returns>
        public IEnumerable<T> SearchOther<T>(string searchText, Guid? DepartmentId = null, Guid? PositionId = null)
        {
            var tableName = typeof(T).Name;
            var storeName = $"Proc_Get{tableName}ByOthers";
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add($"@{tableName}SearchText", (searchText!=null?searchText:String.Empty));
            dynamicParameters.Add($"@{tableName}DepartmentId", DepartmentId, DbType.String);
            dynamicParameters.Add($"@{tableName}PositionId", PositionId, DbType.String);
            return _dbConnection.Query<T>(storeName, dynamicParameters, commandType: CommandType.StoredProcedure);
        } 
        /// <summary>
        /// Tìm kiếm danh sách nhân viên theo phòng ban và vị trí/ chức vụ
        /// </summary>
        /// <typeparam name="T">Kiểu dữ liệu trả về</typeparam>
        /// <param name="PositionSearch">Tên vị trí/chức vụ</param>
        /// <param name="DepartmentSearch">Tên phòng ban</param>
        /// <returns>Trả về danh sách theo yêu cầu</returns>
        public IEnumerable<T> SearchOther<T>( string PositionSearch, string DepartmentSearch)
        {
            var tableName = typeof(T).Name;
            var storeName = $"Proc_Search{tableName}Other";
            DynamicParameters dynamicParameters = new DynamicParameters();         
            dynamicParameters.Add($"@{tableName}DepartmentSearch", DepartmentSearch);
            dynamicParameters.Add($"@{tableName}PositionSearch", PositionSearch);
            return _dbConnection.Query<T>(storeName, dynamicParameters, commandType: CommandType.StoredProcedure);
        }
        /// <summary>
        /// Lấy mã nhân viên hiện tại lớn nhất
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns>Trả về Mã nhân viên lớn nhất</returns>
        public IEnumerable<T> GetMaxCode<T>()
        {
            var tableName = typeof(T).Name; 
             var storeName = $"Proc_GetCode{tableName}Max";
            return _dbConnection.Query<T>(storeName, commandType: CommandType.StoredProcedure);
        }
        /// <summary>
        /// lấy dữ liệu dựa vào commandtext
        /// </summary>
        /// <typeparam name="T">Kiểu object</typeparam>
        /// <param name="commandText">mã SQL</param>
        /// <return> số dòng trùng</returns>
        public IEnumerable<T> GetAllData<T>(string commandText)
        {
            var tableName = typeof(T).Name;
            var sql = commandText;
            var effRows = _dbConnection.Query<T>(sql);
            return effRows;
        }
            
        /// <summary>
        /// lay thong tin 1 nguoi dung
        /// </summary>
        /// <typeparam name="T">kieu du lieu cua nguoi dung</typeparam>
        /// <param name="id">id cua nguoi can tim</param>
        /// <returns>tra ve thong tin nguoi dung</returns>
        public T GetById<T>(object id)
        {
            var tableName = typeof(T).Name;
            var storeName = $"Proc_Get{tableName}ById";
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add($"@{tableName}Id", id);// CustomerGroupId = id;
            return _dbConnection.Query<T>(storeName, dynamicParameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
        }
        /// <summary>
        /// Thêm đối tượng vào danh sách
        /// </summary>
        /// <typeparam name="T">kiểu dữ liệu truyền vào</typeparam>
        /// <param name="entity">đối tượng truyền vào</param>
        /// <returns>trả về số dòng thay đổi</returns>
        public int Insert<T>(T entity)
        {
            var tableName = typeof(T).Name;
            DynamicParameters dynamicParameters = new DynamicParameters();
            var storeName = $"Proc_Insert{tableName}";
            var properties = typeof(T).GetProperties();
            foreach (var property in properties)
            {
                var propertyName = property.Name;
                var propertyValue = property.GetValue(entity);
                if (propertyName == "EmployeePositionId" || propertyName == "EmployeeDepartmentId" || propertyName == "EmployeeDepartmentId")
                {
                    propertyValue = propertyValue.ToString();
                }
                dynamicParameters.Add($"@{propertyName}", propertyValue);
            }
            var effrows = _dbConnection.Execute(storeName, dynamicParameters, commandType: CommandType.StoredProcedure);
            return effrows;
        }
        /// <summary>
        /// xóa nhân viên dựa vào Id
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id">Id nhân viên </param>
        /// <returns>trả về số dòng thay đổi</returns>
        public int DeleteById<T>(object id)
        {
            var tableName = typeof(T).Name;
            var storeName = $"Proc_Delete{tableName}";
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add($"@{tableName}Id", id);// CustomerGroupId = id;
            _dbConnection.Query<T>(storeName, dynamicParameters, commandType: CommandType.StoredProcedure);
            return 0;
        }
        /// <summary>
        /// Sửa thông tin nhân viên
        /// </summary>
        /// <typeparam name="T">Kiểu dữ liệu đối tượng</typeparam>
        /// <param name="entity">Đối tượng cần sửa </param>
        /// <returns>Trả về số dòng chỉnh sửa</returns>
        public int  ModifiedEntity<T>(T entity)
        {
            var tableName = typeof(T).Name;
            DynamicParameters dynamicParameters = new DynamicParameters();
            var storeName = $"Proc_Modify{tableName}";
            var properties = typeof(T).GetProperties();
            foreach (var property in properties)
            {
                var propertyName = property.Name;
                var propertyValue = property.GetValue(entity);
                if (propertyName == "EmployeePositionId" || propertyName == "EmployeeDepartmentId")
                {
                    propertyValue = propertyValue.ToString();
                }
                dynamicParameters.Add($"@{propertyName}", propertyValue);
            }
            var effrows = _dbConnection.Query<T>(storeName, dynamicParameters, commandType: CommandType.StoredProcedure);
          
            return 0;
        }
    }
}
