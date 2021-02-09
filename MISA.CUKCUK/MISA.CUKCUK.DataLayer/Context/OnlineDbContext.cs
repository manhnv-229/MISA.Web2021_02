using Dapper;
using MISA.DataLayer.Interface;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace MISA.DataLayer.Context
{
    /// <summary>
    /// Db online
    /// </summary>
    public class OnlineDbContext<T> : IDbContext<T> where T:class
    {
        #region DECLARE
        //Khai báo chuỗi kết nối tới db
        string _connectionString = "Server=103.124.92.43;" +
            "port=3306;" +
            "Database=MS4_16_VuThanhThien_CukCuk;" +
            "User=nvmanh;" +
            "Password=12345678;";

        // Khai báo kết nối
        private readonly IDbConnection _dbConnection;
        #endregion

        #region CONTRUCTOR
        //Khởi tạo kết nối
        public OnlineDbContext()
        {
            _dbConnection = new MySqlConnection(_connectionString);
        }
        #endregion

        #region METHOD

        /// <summary>
        /// Thực thi câu lệnh SELECT
        /// </summary>
        /// <typeparam name="MISAEntity">Class</typeparam>
        /// <param name="sqlCommand">Câu lệnh sql hoặc tên procedure</param>
        /// <param name="parameters">Tham số truyền vào (mặc định là null)</param>
        /// <param name="commandType">Loại command (mặc định là text)</param>
        /// <returns></returns>
        public IEnumerable<T> Query(string sqlCommand, DynamicParameters parameters = null, CommandType commandType = CommandType.Text)
        {
            // Thực thi truy vấn bằng proceduce
            var entites = _dbConnection.Query<T>(sqlCommand, parameters, commandType: commandType);

            // Trả về 
            return entites;
        }
        /// <summary>
        /// Thực thi các câu lệnh thêm, sửa, xóa
        /// </summary>
        /// <param name="sqlCommand">Câu lệnh sql hoặc tên procedure</param>
        /// <param name="parameters">Tham số truyền vào (mặc định là null)</param>
        /// <param name="commandType">Loại command (mặc định là text)</param>
        /// <returns></returns>
        public int Excute(string sqlCommand, DynamicParameters parameters = null, CommandType commandType = CommandType.Text)
        {
            var result = _dbConnection.Execute(sqlCommand, parameters, commandType: commandType);
            return result;
        }

        public T QueryFirst(string sqlCommand, DynamicParameters parameters = null, CommandType commandType = CommandType.Text)
        {
            // Thực thi truy vấn bằng proceduce
            var entity = _dbConnection.Query<T>(sqlCommand, parameters, commandType: commandType).FirstOrDefault();

            // Trả về 
            return entity;
        }
        #endregion
    }
}
