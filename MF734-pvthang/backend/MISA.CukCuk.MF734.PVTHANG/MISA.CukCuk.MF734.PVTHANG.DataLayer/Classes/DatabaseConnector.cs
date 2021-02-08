using Dapper;
using MISA.CukCuk.MF734.PVTHANG.DataLayer.Interfaces;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace MISA.CukCuk.MF734.PVTHANG.DataLayer.Classes
{
    public class DatabaseConnector: IDatabaseConnector
    {
        protected String _connectionString;
        protected IDbConnection _dbConnection;
        public DatabaseConnector()
        {
            _connectionString = "User Id=nvmanh;Password=12345678;Database=MS3_06_PVTHANG_CuckCuk;Port=3306;Host=103.124.92.43;Character Set=utf8";
            _dbConnection = new MySqlConnection(_connectionString);
        }

        /// <summary>
        /// Lấy một dòng dữ liệu đầu tiên
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="procName">tên procedure</param>
        /// <param name="input">object chứa đầu vào của procedure</param>
        /// <param name="type"></param>
        /// <returns></returns>
        /// CREATED BY: PHẠM VIỆT THẮNG
        public virtual TEntity GetFirst<TEntity>(String procName, Object input, CommandType type = CommandType.StoredProcedure)
        {
            return _dbConnection.Query<TEntity>(procName, input, commandType: type).FirstOrDefault();
        }

        /// <summary>
        /// Lấy danh sách dữ liệu
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="procName">tên procedure</param>
        /// <param name="input">object chứa đầu vào của procedure</param>
        /// <param name="type"></param>
        /// <returns></returns>
        /// CREATED BY: PHẠM VIỆT THẮNG
        public virtual IEnumerable<TEntity> GetList<TEntity>(String procName, Object input, CommandType type = CommandType.StoredProcedure)
        {
            return _dbConnection.Query<TEntity>(procName, input, commandType: type).ToList();
        }


        /// <summary>
        /// Thay đổi dữ liệu trong Database: Thêm, sửa, xóa
        /// </summary>
        /// <param name="procName">tên procedure</param>
        /// <param name="input">object chứa đầu vào của procedure</param>
        /// <param name="type"></param>
        /// <returns>Số dòng thay đổi trong Database</returns>
        /// CREATED BY: PHẠM VIỆT THẮNG
        public virtual int Change(String procName, Object input, CommandType type = CommandType.StoredProcedure)
        {
            return _dbConnection.Execute(procName, input, commandType: type);
        }
    }
}
