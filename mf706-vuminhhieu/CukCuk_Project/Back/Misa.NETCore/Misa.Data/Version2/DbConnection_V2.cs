using Dapper;
using Misa.Common.Requests;
using Misa.Data.Interfaces;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Misa.Data.Version2
{
    // Database của Nguyễn Huy Long - thanks!
    public class DbConnection_V2<T> : IBaseData<T>
    {
        private string ConnectionString = "User Id = nvmanh; password=12345678;Database=MS2_42_NguyenHuyLong_CukCuk;Host=103.124.92.43;port=3306;Character Set = utf8";
        public IDbConnection dbConnection;
        public DbConnection_V2()
        {
            dbConnection = new MySqlConnection(ConnectionString);
        }

        /// <summary>
        /// Lấy danh sách theo chuỗi sql
        /// </summary>
        /// <param name="commandText">chuỗi sql</param>
        /// <param name="parameters">tham sô truyền vào</param>
        /// <param name="commandType">kiểu truy vấn</param>
        /// <returns>danh sách đối tượng</returns>
        /// create: 7/2/2021
        public async Task<IEnumerable<T>> GetData(string commandText = null, object parameters = null, CommandType commandType = CommandType.Text)
        {
            if (commandText == null)
            {
                string className = typeof(T).Name;
                var queryString = $"SELECT * FROM {className}";
                return await dbConnection.QueryAsync<T>(queryString);
            }
            if (parameters != null)
            {
                
                return await dbConnection.QueryAsync<T>(commandText, param: parameters, commandType: commandType);
            }
            return await dbConnection.QueryAsync<T>(commandText, commandType: commandType);

        }

        // <summary>
        /// Lấy danh sách theo chuỗi sql chỉ định đầu ra cụ thể
        /// </summary>
        /// <param name="commandText">chuỗi sql</param>
        /// <param name="parameters">tham sô truyền vào</param>
        /// <param name="commandType">kiểu truy vấn</param>
        /// <returns>danh sách đối tượng</returns>
        /// create: 8/2/2021
        public async Task<IEnumerable<T2>> GetData<T2>(string commandText = null, object parameters = null, CommandType commandType = CommandType.Text)
        {
            if (commandText == null)
            {
                string className = typeof(T2).Name;
                var queryString = $"SELECT * FROM {className}";
                return await dbConnection.QueryAsync<T2>(queryString);
            }
            if (parameters != null)
            {
                return await dbConnection.QueryAsync<T2>(commandText, param: parameters, commandType: commandType);
            }
            return await dbConnection.QueryAsync<T2>(commandText, commandType: commandType);

        }

        /// <summary>
        /// Lấy danh sách thuộc tính theo số trang và kích thước trang
        /// </summary>
        /// <param name="pageRequestBase">số trang và kích thước trang</param>
        /// <returns>danh sách thuộc tính</returns>
        /// create: 7/2/2021
        public async Task<IEnumerable<T>> GetData(PageRequestBase pageRequestBase)
        {
            int indexStart = (pageRequestBase.PageIndex - 1) * pageRequestBase.PageSize;
            string className = typeof(T).Name;
            var queryString = $"SELECT * FROM {className} LIMIT {indexStart.ToString()}, {pageRequestBase.PageSize.ToString()}";
            return await dbConnection.QueryAsync<T>(queryString);
        }

        /// <summary>
        /// Lấy đối tượng theo id 
        /// </summary>
        /// <param name="id">Id của đối tượng</param>
        /// <returns>Một đối tượng</returns>
        /// create: 7/2/2021
        public async Task<T> GetById(object id)
        {
            string className = typeof(T).Name;
            var queryString = $"SELECT * FROM {className} WHERE {className}Id ='{id.ToString()}'";
            var entites = await dbConnection.QueryAsync<T>(queryString);
            return entites.FirstOrDefault();
        }


        /// <summary>
        ///  Lấy đối tượng theo id 
        /// </summary>
        /// <param name="id1">Id của đối tượng</param>
        /// <param name="id2"Id của đối tượng></param>
        /// <returns>Một đối tượng</returns>
        /// create: 7/2/2021
        public Task<T> GetById(object id1, object id2)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Thêm mới đối tượng
        /// </summary>
        /// <param name="entiry">Thông tin đối tượng</param>
        /// <returns>Số bản ghi bị ảnh hưởng</returns>
        /// create: 7/2/2021
        public async Task<int> Insert(T entiry)
        {
            string className = typeof(T).Name;
            var properties = typeof(T).GetProperties();
            var parameters = new DynamicParameters();
            string sqlPropertyBuider = string.Empty;
            string sqlPropertyParamBuilder = string.Empty;

            foreach (var property in properties)
            {
                var propertyName = property.Name;
                var propertyValue = property.GetValue(entiry);
                parameters.Add($"@{propertyName}", propertyValue);
                sqlPropertyBuider += $", {propertyName}";
                sqlPropertyParamBuilder += $", @{propertyName}";


            }
            var query = $"INSERT INTO {className}({sqlPropertyBuider.Substring(1)}) VALUES ({sqlPropertyParamBuilder.Substring(1)})";
            return await dbConnection.ExecuteAsync(query, parameters);

        }

        /// <summary>
        /// Cập nhật đối tượng
        /// </summary>
        /// <param name="entiry">Thông tin đối tượng</param>
        /// <returns>Số bản ghi bị ảnh hưởng</returns>
        /// create: 7/2/2021   
        public async Task<int> Update(T entiry)
        {
            string className = typeof(T).Name;
            string proceduceName = $"Proc_Update{className}";
            var properties = typeof(T).GetProperties();
            var parameters = new DynamicParameters();

            foreach (var property in properties)
            {
                var propertyName = property.Name;
                var propertyValue = property.GetValue(entiry);
                var propertyType = property.PropertyType;
                //nên chuyển thành string trước khi thêm
                if (propertyType == typeof(Guid) || propertyType == typeof(Guid?))
                {
                    propertyValue = propertyValue.ToString();
                }
                parameters.Add($"@{propertyName}", propertyValue);

            }

            return await dbConnection.ExecuteAsync(proceduceName, parameters, commandType: CommandType.StoredProcedure);

        }

        /// <summary>
        /// Xóa đối tượng
        /// </summary>
        /// <param name="id">id của đối tượng:</param>
        /// <returns>số dòng bị ảnh hưởng</returns>
        /// create: 7/2/2021        
        public async Task<int> Delete(string id)
        {
            string className = typeof(T).Name;
            var query = $"Proc_Delete{className}";
            var parameters = new DynamicParameters();
            parameters.Add($"@{className}Id", id);
            return await dbConnection.ExecuteAsync(query, parameters, commandType: CommandType.StoredProcedure);
        }
        // hàm hủy kết nối
        public void Dispose()
        {
            dbConnection.Dispose();
        }
    }
}
