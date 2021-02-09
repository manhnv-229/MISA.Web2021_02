using Dapper;
using MISA.DAO.Interfaces;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace MISA.DAO
{
    public class DbConnectorBackUp<T> :IDbConnector<T>
    {
        //Khởi tạo chuỗi kết nối
        protected String connectionString = "User Id=nvmanh;password = 12345678;" +
                                            "Host=103.124.92.43;port = 3306;" +
                                            "Database = MISACukCuk_MF738_QDQuang;" +
                                            "Character Set=utf8";
        protected IDbConnection db;
        //Hàm khơi tạo
        public DbConnectorBackUp()
        {
            db = new MySqlConnection(connectionString);
        }

        /// <summary>
        /// Lấy tất cả bản ghi của bảng
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sqlCommand">Ten store hoac cau truy van</param>
        /// <param name="parameters">Cac thuoc tinh can truy van</param>
        /// <param name="commandType">Text Hoac Store</param>
        /// <returns>Danh sách các bản ghi</returns>
        /// CreatedBy NDLuu (8/2/2021)
        public IEnumerable<T> GetAllData(string sqlCommand = null, object parameters = null, CommandType commandType = CommandType.Text)
        {
            var tableName = typeof(T).Name;
            if (sqlCommand == null)
            {
                sqlCommand = $"SELECT * FROM {tableName}";
            }
            //var store = $"Proc_Get{tableName}s";
            var entity = db.Query<T>(sqlCommand, param: parameters, commandType: commandType).ToList();
            return entity;
        }

        /// <summary>
        /// Lấy bản ghi theo mã
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id"></param>
        /// <returns>Một bản ghi</returns>
        public T getByID<T>(string id)
        {
            var tableName = typeof(T).Name;
            var store = $"Proc_Get{tableName}ByID";
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add($"@{tableName}ID", id);
            var entity = db.Query<T>(store, dynamicParameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            return entity;

        }

        /// <summary>
        /// Thêm mới 1 bản ghi
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        public int Insert(T entity)
        {
            var tableName = typeof(T).Name;
            var store = $"Proc_Insert{tableName}";
            var result = db.Execute(store, entity, commandType: CommandType.StoredProcedure);
            return result;
        }

        /// <summary>
        /// Cập nhật 1 bản ghi
        /// </summary>
        /// <param name="entity">đối tượng cập nhật</param>
        /// <returns></returns>
        public int Update(T entity)
        {
            var tableName = typeof(T).Name;
            var storeName = $"Proc_Update{tableName}";
            var affectedRows = db.Execute(storeName, entity, commandType: CommandType.StoredProcedure);

            return affectedRows;
        }


        /// <summary>
        /// Xóa 1 bản ghi
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns>Int (Số hàng tác động vào cơ sở dữ liệu)</returns>
        /// CreatedBy: QDQuang (08/02/2021)
        public virtual int Delete(string id)
        {
            var tableName = typeof(T).Name;
            var storeName = $"Proc_Delete{tableName}";
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add($"@{tableName}Id", id);
            var affectedRows = db.Execute(storeName, dynamicParameters, commandType: CommandType.StoredProcedure);

            return affectedRows;
        }

    }
}
