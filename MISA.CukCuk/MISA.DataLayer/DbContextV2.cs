using Dapper;
using MISA.DataLayer.Interfaces;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace MISA.DataLayer
{
    public class DbContextV2<MISAEntity> : IBaseData<MISAEntity>
    {
        #region DECLARE
        protected String _connectionString = "Host=103.124.92.43; " +
            "Port=3306; User Id=nvmanh; password=12345678; " +
            "Database=MS2_23_PhamVanNgoc_CukCuk; Character Set=utf8;";
        protected IDbConnection _dbConnection;
        #endregion

        #region Constructor
        public DbContextV2()
        {
            _dbConnection = new MySqlConnection(_connectionString);
        }
        #endregion

        #region Method
        /// <summary>
        /// Lấy toàn bộ dữ liệu
        /// </summary>
        /// <returns>Collection Object</returns>
        /// CreatedBy: NTANH (08/02/2021)
        public IEnumerable<MISAEntity> GetAll()
        {
            var className = typeof(MISAEntity).Name;
            var res = _dbConnection.Query<MISAEntity>($"SELECT * FROM {className} LIMIT 1", commandType: CommandType.Text);
            return res;
        }

        /// <summary>
        /// Thêm mới object vào db
        /// </summary>
        /// <param name="entity">Kiểu của object cần thêm</param>
        /// <returns>Số bản ghi được thêm (ở đây fix cứng)</returns>
        /// CreatedBy: NTANH (08/02/2021)
        public int InsertObject(MISAEntity entity)
        {
            return 1111;
        }
        #endregion
    }
}
