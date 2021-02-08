using Dapper;
using MISA.ApplicationCore.interfaces;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace MISA.Infrastructure
{
    public class DbContext : IDbContext
    {
        #region DECLARE
        string sqlConnector = "Host=103.124.92.43; User Id=nvmanh; password=12345678; Database=MS4_08_BDHieu_CukCuk; Character Set=utf8";
        IDbConnection db;
        #endregion

        #region CONSTRUCTOR
        public DbContext()
        {
            db = new MySqlConnection(sqlConnector);
        }
        #endregion

        #region METHOD
        /// <summary>
        /// Lấy toàn bộ danh sách
        /// </summary>
        /// <typeparam name="T">Tên bảng muốn lấy</typeparam>
        /// <param name="commandType"></param>
        /// <returns>Toàn bộ danh sách</returns>
        /// CreatedBy: BDHIEU (07/02/2021)
        public IEnumerable<T> GetAll<T>(CommandType commandType = CommandType.StoredProcedure)
        {
            var className = typeof(T).Name;
            var objectData = db.Query<T>($"Proc_Get{className}", commandType);
            return objectData;
        }

        /// <summary>
        /// Lấy thông tin theo tham số truyền vào
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sqlCommand"></param>
        /// <param name="parameters"></param>
        /// <param name="commandType"></param>
        /// <returns>Danh sách</returns>
        /// CreatedBy: BDHIEU (08/02/2021)
        public IEnumerable<T> GetData<T>(string sqlCommand, object parameters = null, CommandType commandType = CommandType.Text)
        {
            var data = db.Query<T>(sqlCommand, param: parameters, commandType: commandType);
            return data;
        }

        /// <summary>
        /// Tạo object gồm tên và giá trị
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <returns>Object gồm tên và giá trị</returns>
        /// CreatedBy: BDHIEU (08/02/2021)
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
        /// Thêm mới hoặc cập nhật
        /// </summary>
        /// <typeparam name="T">Tên class muốn cập nhật</typeparam>
        /// <param name="sqlCommand">Câu lệnh sql</param>
        /// <param name="entity">Class</param>
        /// <param name="commandType">Kiểu lệnh sql</param>
        /// <returns>Số bản ghi cập nhật thành công</returns>
        /// CreatedBy: BDHIEU (08/02/2021)
        public int InsertData<T>(string sqlCommand, T entity, CommandType commandType = CommandType.Text)
        {
            var parameters = MappingDbType(entity);
            var rowAffects = db.Execute(sqlCommand, param: parameters, commandType: commandType);
            return rowAffects;
        }

        /// <summary>
        /// Xóa dữ liệu
        /// </summary>
        /// <param name="sqlCommand"></param>
        /// <param name="parameters"></param>
        /// <param name="commandType"></param>
        /// <returns>Số bản ghi xóa thành công</returns>
        /// CreatedBy: BDHIEU (08/02/2021)
        public int DeleteData(string sqlCommand, object parameters = null, CommandType commandType = CommandType.Text)
        {
            var rowAffect = db.Execute(sqlCommand, param: parameters, commandType: commandType);
            return rowAffect;
        }
        #endregion
    }
}
