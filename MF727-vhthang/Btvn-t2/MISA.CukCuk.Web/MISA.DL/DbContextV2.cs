using Dapper;
using MISA.DL.Interfaces;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace MISA.DL
{
    public class DbContextV2<TEntity> : IDbContext<TEntity>
    {
        //DbContextV2 sử dụng Db khác(MF727_VHTHANG) 
        //Muốn thay đổi trong startup.cs
        //Khởi tạo
        protected string _connectionString = "Host=103.124.92.43;User Id=nvmanh; password=12345678;Database=MF727_VHTHANG;port=3306;Character Set=utf8";
        protected IDbConnection _dbConnection;
        public DbContextV2()
        {
            _dbConnection = new MySqlConnection(_connectionString);
        }

        /// <summary>
        /// Lấy dữ liệu theo nhiều tiêu chí
        /// </summary>
        /// <typeparam name="TEntity">Loại đối tượng</typeparam>
        /// <param name="sqlCommand">Câu lệnh sql hoặc tên store</param>
        /// <param name="parameters">đối tượng chứa thông tin tham số của strore</param>
        /// <param name="commandType">Mặc định CommandType.Text</param>
        /// <returns></returns>
        public IEnumerable<TEntity> GetData(string sqlCommand = null, object parameters = null, CommandType commandType = CommandType.Text)
        {
            var tableName = typeof(TEntity).Name;
            if (sqlCommand == null)
            {
                sqlCommand = $"SELECT * FROM {tableName}";
            }
            var entity = _dbConnection.Query<TEntity>(sqlCommand, param: parameters, commandType: commandType);
            return entity;
        }

        /// <summary>
        /// Thêm mới bản ghi dữ liệu
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="entity">Bản ghi truyền vào</param>
        /// <returns>Số bản ghi được thêm</returns>
        public int Insert(TEntity entity)
        {
            var tableName = typeof(TEntity).Name;
            var sqlName = string.Empty;
            var sqlParam = string.Empty;
            var properties = typeof(TEntity).GetProperties();
            foreach (var property in properties)
            {
                var propName = property.Name;
                var propValue = property.GetValue(entity);
                if (propName.ToLower() == $"{tableName}Id".ToLower())
                {
                    property.SetValue(entity, Guid.NewGuid());
                }
                sqlName += $",{propName}";
                sqlParam += $",@{propName}";

            }
            sqlName = sqlName.Remove(0, 1);
            sqlParam = sqlParam.Remove(0, 1);
            var sqlString = $"INSERT INTO {tableName} ({sqlName}) VALUES ({sqlParam})";
            //Server=localhost\SQLEXPRESS;Database=master;Trusted_Connection=True;
            var query = _dbConnection.Execute(sqlString, entity, commandType: CommandType.Text);
            return query;
        }

        /// <summary>
        /// Lấy toàn bộ dữ liệu
        /// </summary>
        /// <returns>Dữ liệu</returns>
        public IEnumerable<TEntity> GetAll()
        {
            var tableName = typeof(TEntity).Name;
            var entities = _dbConnection.Query<TEntity>($"SELECT * FROM {tableName}", commandType: CommandType.Text);
            return entities;

        }

        /// <summary>
        /// Chỉnh sủa dữ liệu theo id
        /// </summary>
        /// <param name="entity">Đối tượng truyền vào</param>
        /// <returns>Số bản ghi đã chỉnh</returns>
        public int Update(TEntity entity)
        {
            var tableName = typeof(TEntity).Name;
            var sqlParam = string.Empty;
            var properties = typeof(TEntity).GetProperties();
            foreach (var property in properties)
            {
                var propName = property.Name;
                var propValue = property.GetValue(entity);
                var propertyType = property.PropertyType;
                sqlParam += $",{propName} = @{propName}";

            }

            sqlParam = sqlParam.Remove(0, 1);
            var sqlString = $"UPDATE {tableName} SET {sqlParam} WHERE {tableName}Id = @{tableName}Id";
            var query = _dbConnection.Execute(sqlString, entity, commandType: CommandType.Text);
            return query;
        }

        /// <summary>
        /// Xóa dữ liệu theo id
        /// </summary>
        /// <param name="entity">dữ liệu</param>
        /// <returns>Số bản ghi đã bị xóa</returns>
        public int Delete(TEntity entity)
        {
            var tableName = typeof(TEntity).Name;
            var sqlString = $"DELETE FROM {tableName} WHERE {tableName}Id = @{tableName}Id";
            var query = _dbConnection.Execute(sqlString, entity, commandType: CommandType.Text);
            return query;
        }

    }
}
