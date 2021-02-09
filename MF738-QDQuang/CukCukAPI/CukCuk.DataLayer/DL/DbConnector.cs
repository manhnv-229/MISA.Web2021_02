using CukCuk.DataLayer.Interfaces;
using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace CukCuk.DataLayer
{
    /// <summary>
    /// Cơ sở dữ liệu 1: QUÁCH ĐÌNH QUANG
    /// </summary>
    /// <typeparam name="TEntity">Object</typeparam>
    public class DbConnector<TEntity>:IDbConnector<TEntity>
    {
        #region DECLARE
        // Khởi tạo chuỗi kết nối
        protected string _connectionString = "User Id=nvmanh;Host=103.124.92.43;" +
            "Database=MISACukCuk_MF738_QDQuang;port=3306;password=12345678;Character Set=utf8";
        // Khởi tạo kết nối
        protected IDbConnection _dbConnection;
        #endregion

        #region CONSTRUCTOR
        // Hàm khởi tạo
        public DbConnector()
        {
            _dbConnection = new MySqlConnection(_connectionString);
        }
        #endregion

        #region METHODS
        /// <summary>
        /// Lấy dữ liệu theo tiêu chí khác nhau
        /// </summary>
        /// <param name="sqlCommand">Câu lệnh Query (mặc định = null)</param>
        /// <param name="parameters">Các tham số truyền vào trong câu query (mặc định = null)</param>
        /// <param name="commandType">Loại command (mặc định = Text)</param>
        /// <returns>Entities</returns>
        /// CreatedBy: QDQuang (08/02/2021)
        public IEnumerable<TEntity> GetData(string sqlCommand = null, object parameters = null, CommandType commandType = CommandType.Text)
        {
            // Nếu sqlCommand là rỗng thì lấy mặc định theo tên bảng
            if(sqlCommand == null)
            {
                // Lấy tên bảng
                var tableName = typeof(TEntity).Name;
                // Tạo câu Query lấy tất cả bản ghi
                sqlCommand = $"SELECT * FROM {tableName}";
                // Lấy dữ liệu
                var entities = _dbConnection.Query<TEntity>(sqlCommand);

                return entities;
            } else
            {
                // Lấy dữ liệu theo tiêu chí
                var entities = _dbConnection.Query<TEntity>(sqlCommand, param: parameters, commandType: commandType);

                return entities;
            }
        }

        /// <summary>
        /// Thêm mới bản ghi
        /// </summary>
        /// <param name="entity">Object</param>
        /// <returns>Int (Số hàng tác động vào cơ sở dữ liệu)</returns>
        /// CreatedBy: QDQuang (08/02/2021)
        public int Insert(TEntity entity)
        {
            // Lấy tên bảng
            var tableName = typeof(TEntity).Name;
            // Lấy tên Procedure
            var storeName = $"Proc_Insert{tableName}";
            // Lưu bản ghi vào cơ sở dữ liệu và trả về số bản ghi tác động vào cơ sở dữ liệu
            var affectedRows = _dbConnection.Execute(storeName, entity, commandType: CommandType.StoredProcedure);

            return affectedRows;
        }

        /// <summary>
        /// Cập nhập thông tin bản ghi
        /// </summary>
        /// <param name="entity">Object</param>
        /// <returns>Int (Số hàng tác động vào cơ sở dữ liệu)</returns>
        /// CreatedBy: QDQuang (08/02/2021)
        public int Update(TEntity entity)
        {
            // Lấy tên bảng
            var tableName = typeof(TEntity).Name;
            // Lấy tên Procedure
            var storeName = $"Proc_Update{tableName}";
            // Cập nhật bản ghi vào cơ sở dữ liệu và trả về số bản ghi tác động vào cơ sở dữ liệu
            var affectedRows = _dbConnection.Execute(storeName, entity, commandType: CommandType.StoredProcedure);

            return affectedRows;
        }

        /// <summary>
        /// Xóa bản ghi
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns>Int (Số hàng tác động vào cơ sở dữ liệu)</returns>
        /// CreatedBy: QDQuang (08/02/2021)
        public virtual int Delete(string id)
        {
            // Lấy tên bảng
            var tableName = typeof(TEntity).Name;
            // Lấy tên Procedure
            var storeName = $"Proc_Delete{tableName}";
            // Lấy Parameter
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add($"@{tableName}Id", id);
            // Xóa bản ghi và trả lại số lượng bản ghi tác động vào cơ sở dữ liệu
            var affectedRows = _dbConnection.Execute(storeName, dynamicParameters, commandType: CommandType.StoredProcedure);

            return affectedRows;
        }
        #endregion
    }
}
