using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using MISA.Common.Model;
using MISA.DataLayer.Interface;

namespace MISA.CUKCUK.DataLayer
{
    public class LocalDbContext<T>: IDbContext<T> where T:class
    {
        #region DECLARE
        //Khai báo chuỗi kết nối tới db
        string _connectionString = "Host = 127.0.0.1;" +
            "Port = 3306;" +
            "Database = ms4_16_vuthanhthien_cukcuk;" +
            "User Id = root;" +
            "Password = ";
        // Khai báo kết nối
        private readonly IDbConnection _dbConnection ;
        #endregion

        #region CONTRUCTOR
        public LocalDbContext()
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

        public T QueryFirst(string sqlCommand, DynamicParameters parameters = null, CommandType commandType = CommandType.Text)
        {
            // Thực thi truy vấn bằng proceduce
            var entity = _dbConnection.Query<T>(sqlCommand, parameters, commandType: commandType).FirstOrDefault();

            // Trả về 
            return entity;
        }

        /// <summary>
        /// Thực thi câu lệnh SELECT
        /// </summary>
        /// <typeparam name="MISAEntity">Class</typeparam>
        /// <param name="sqlCommand">Câu lệnh sql hoặc tên procedure</param>
        /// <param name="parameters">Tham số truyền vào (mặc định là null)</param>
        /// <param name="commandType">Loại command (mặc định là text)</param>
        /// <returns></returns>
        public int Excute(string sqlCommand, DynamicParameters parameters = null, CommandType commandType = CommandType.Text)
        {
            var result = _dbConnection.Execute(sqlCommand, parameters, commandType: commandType);
            return result;
        }
        #endregion
    }
}
