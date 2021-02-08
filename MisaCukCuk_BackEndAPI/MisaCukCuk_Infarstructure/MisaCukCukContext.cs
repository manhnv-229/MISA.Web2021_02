using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MisaCukCuk_Infarstructure
{
    public class MisaCukCukContext<T> : IMisaCukCukContext<T>
    {
        /// <summary>
        /// Khởi tạo chuôi kết nối connectString
        /// CreateBy: MinhHq(08/02/2021)
        /// </summary>
        protected string connectString;
        protected IDbConnection _db;
        public MisaCukCukContext()
        {
            connectString = "User Id=nvmanh;host=103.124.92.43;Database=MISACukCuk_MF736_MinhHq;port=3306;password=12345678;character Set=utf8";
            _db = new MySqlConnection(connectString);
        }
        /// <summary>
        /// Lấy tất cả bản ghi
        /// CreateBy: MinhHq(08/02/2021)
        /// </summary>
        /// <returns>Trả về danh sách truy vấn</returns>
        public virtual async Task<IEnumerable<T>> GetAllData()
        {
            var tableName = typeof(T).Name;
            var storeName = $"Proc_Get{tableName}s";
            var rs = _db.Query<T>(storeName, commandType:CommandType.StoredProcedure).ToList();
            return rs;
        }
        /// <summary>
        /// Lấy bản ghi theo ID
        /// CreateBy: MinhHq(08/02/2021)
        /// </summary>
        /// <param name="code"></param>
        /// <returns>Trả về bản ghi có Id truyền vào</returns>
        public async Task<IEnumerable<T>> GetByID(Guid code)
        {
            var tableName = typeof(T).Name;
            var storeName = $"Proc_Get{tableName}ById";

            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add($"@{tableName}Id", code);

            return _db.Query<T>(storeName, dynamicParameters, commandType: CommandType.StoredProcedure).ToList();
        }
        /// <summary>
        /// Thêm mới bản ghi
        /// CreateBy: MinhHq(08/02/2021)
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>Trả về: 1: thành công; 0: thất bại</returns>
        public async Task<int> Insert(T entity)
        {
            var tableName = typeof(T).Name;
            var storeName = $"Insert{tableName}";

            var porperties = typeof(T).GetProperties();

            DynamicParameters dynamicParameters = new DynamicParameters();

            foreach (var property in porperties)
            {
                var propertyName = property.Name;
                var propertyValue = property.GetValue(entity);
                dynamicParameters.Add($"@{propertyName}", propertyValue);
            }

            return _db.Execute(storeName, dynamicParameters, commandType: CommandType.StoredProcedure);
        }
        /// <summary>
        /// Chỉnh sửa bản ghi
        /// CreateBy: MinhHq(08/02/2021)
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>Trả về : 1: Chỉnh sửa thành công; 0: Chỉnh sửa thất bại</returns>
        public async Task<int> Update(T entity)
        {
            var tableName = typeof(T).Name;
            var storeName = $"Update{tableName}";

            DynamicParameters dynamicParameters = new DynamicParameters();
            var properties = typeof(T).GetProperties();

            foreach (var property in properties)
            {
                var propertyName = property.Name;
                var propertyValue = property.GetValue(entity);
                dynamicParameters.Add($"@{propertyName}", propertyValue);
            }

            return _db.Execute(storeName, dynamicParameters, commandType: CommandType.StoredProcedure);
        }
        /// <summary>
        /// Xóa bản ghi theo ID
        /// CreateBy: MinhHq(08/02/2021)
        /// </summary>
        /// <param name="code"></param>
        /// <returns>trả về: 1: xóa thành công; 2: xóa thất bại</returns>
        public async Task<int> DeleteById(Guid code)
        {
            var tableName = typeof(T).Name;
            var storeName = $"Delete{tableName}By{tableName}Id";

            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add($"@{tableName}Id", code);

            return _db.Execute(storeName,dynamicParameters, commandType: CommandType.StoredProcedure);
        }
        /// <summary>
        /// Check trùng mã Code
        /// CreateBy: MinhHq(08/02/2021)
        /// </summary>
        /// <param name="code"></param>
        /// <returns>true:không trùng mã; false: trùng mã</returns>
        public async Task<bool> CheckCodeExit(string code)
        {
            var tableName = typeof(T).Name;
            var sql = $"SELECT {tableName}Code FROM {tableName} WHERE {tableName}Code = '{code}'";
            var rs = _db.Query<string>(sql, commandType: CommandType.Text).FirstOrDefault();
            if (rs != null)
            {
                return false;
            }
            return true;
        }
        /// <summary>
        /// Check trùng số điện thoại
        /// CreateBy: MinhHq(08/02/2021)
        /// </summary>
        /// <param name="phoneNumber"></param>
        /// <returns>true: không trùng số điện thoại; false: trùng số điện thoại</returns>
        public async Task<bool> CheckPhoneNumberExit(string phoneNumber)
        {
            var tableName = typeof(T).Name;
            var sql = $"SELECT PhoneNumber FROM {tableName} WHERE PhoneNumber = '{phoneNumber}'";
            var rs = _db.Query<string>(sql, commandType: CommandType.Text).FirstOrDefault();
            if (rs != null)
            {
                return false;
            }
            return true;
        }
        /// <summary>
        /// Check trùng tên
        /// CreateBy: MinhHq(08/02/2021)
        /// </summary>
        /// <param name="name"></param>
        /// <returns>true: không trùng tên; false: trùng tên</returns>
        public async Task<bool> CheckNameExit(string name)
        {
            var tableName = typeof(T).Name;
            var sql = $"SELECT CustomerGroupName FROM {tableName} WHERE CustomerGroupName = N'{name}'";
            var rs = _db.Query<string>(sql, commandType: CommandType.Text).FirstOrDefault();
            if (rs != null)
            {
                return false;
            }
            return true;
        }
    }
}
