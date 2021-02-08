using Dapper;
using MISA.Common.Model;
using MISA.DataLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace MISA.DataLayer
{
    public class DbContext<MISAEntity>:IBaseData<MISAEntity>
    {
        #region DECLARE
        protected string _connectionString = "" +
            "Host = 103.124.92.43;" +
            "Port = 3306;" +
            "Database = MS1_17_NguyenHuuHung_CukCuk;" +
            "User Id = nvmanh;" +
            "Password = 12345678;";
        protected IDbConnection _dbConnection;
        #endregion

        #region Constructor
        public DbContext()
        {
            _dbConnection = new MySqlConnector.MySqlConnection(_connectionString);
        }
        #endregion
        public IEnumerable<MISAEntity> GetAll()
        {
            var className = typeof(MISAEntity).Name;

            var entities = _dbConnection.Query<MISAEntity>($"select * from {className}", commandType: CommandType.Text);

            return entities;
        }
        #region method
        public IEnumerable<MISAEntity> GetAll(string sqlCommand , CommandType commandType = CommandType.Text)
        {
            var entities = _dbConnection.Query<MISAEntity>(sqlCommand, commandType: commandType);
            return entities;
        }
        /// <summary>
        /// Lấy dữ liệu theo nhiều tiêu chí
        /// </summary>
        /// <typeparam name="MISAEntity">Type của object</typeparam>
        /// <param name="sqlCommand">Câu lệnh truyền vào</param>
        /// <param name="parameters">Tham số truyền vào</param>
        /// <param name="commandType"></param>
        /// <returns></returns>
        public IEnumerable<MISAEntity> GetData(string sqlCommand = null, object parameters = null, CommandType commandType = CommandType.Text)
        {
            var className = typeof(MISAEntity).Name;
            if (sqlCommand == null)
            {
                sqlCommand = $"Select * from {className}";
            }
            var data = _dbConnection.Query<MISAEntity>(sqlCommand, param: parameters, commandType: commandType);
            return data;
        }
        /// <summary>
        /// Them moi ban ghi vao object
        /// </summary>
        /// <param name="entity">object can them moi</param>
        /// <return>So luong ban ghi</return>
        /// CreatedBy: NhHung
        public int InsertObject(object entity)
        {
            var sqlPropName = string.Empty;
            var sqlPropValue = string.Empty;
            var sqlPropParam = string.Empty;
            var className = typeof(MISAEntity).Name;
            var sqlCommand = string.Empty;
            // Lấy các property của object
            var properties = typeof(MISAEntity).GetProperties();
            // Duyệt property, lấy tên và giá trị của property
            //(tên là tên param trong câu truy vấn sql)
            // (value: giá trị là giá trị param tương ứng trong câu lênh SQL)
            DynamicParameters dynamicParameters = new DynamicParameters();
            foreach (var property in properties)
            {
                var propName = property.Name;
                var propValue = property.GetValue(entity);
                if ((property.PropertyType == typeof(Guid) || property.PropertyType == typeof(Guid?)) && propName.ToLower() == $"{className}Id".ToLower())
                {
                    // Khi thêm mới thì sinh giá trị GUID mới cho khóa chính
                    //propValue = Guid.NewGuid();
                    property.SetValue(entity, Guid.NewGuid());
                }
                
                sqlPropName = sqlPropName + $",{propName}";
                sqlPropParam = sqlPropParam + $",@{propName}";
                //dynamicParameters.Add($"@{propName}", propValue);
            }
            sqlPropName = sqlPropName.Remove(0, 1);
            sqlPropParam = sqlPropParam.Remove(0, 1);   
            sqlCommand = $"Insert into {className} ({sqlPropName}) values ({sqlPropParam})";
            var res = _dbConnection.Execute(sqlCommand,param: entity, commandType: CommandType.Text);
            return res;
        }
        #endregion
    }
}
