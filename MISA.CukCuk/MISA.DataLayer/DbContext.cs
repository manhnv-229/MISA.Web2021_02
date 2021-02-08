using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Dapper;
using System.Linq;
using MISA.Common.Model;

namespace MISA.DataLayer
{
    public class DbContext<MISAEntity>
    {
        #region DECLARE
        protected string _connectionString = "" +
                "Host = 103.124.92.43;" +
                "Port = 3306;" +
                "Database = MS0_147_NVMANH_CukCuk;" +
                "User Id = nvmanh;" +
                "Password = 12345678";
        protected IDbConnection _dbConnection;
        #endregion

        #region Constructor
        public DbContext()
        {
            _dbConnection = new MySqlConnector.MySqlConnection(_connectionString);
        }
        #endregion

        #region Method
        public IEnumerable<MISAEntity> GetAll()
        {
            var className = typeof(MISAEntity).Name;

            //Thực thi truy vấn lấy dữ liệu 
            var entities= _dbConnection.Query<MISAEntity>($"SELECT * FROM {className}", commandType: CommandType.Text);

            //Trả về kết quả cho Client 
            return entities;
        }

        public IEnumerable<MISAEntity> GetAll(string sqlCommand, CommandType commandType = CommandType.Text)
        {
            //Thực thi truy vấn lấy dữ liệu 
            var entities = _dbConnection.Query<MISAEntity>(sqlCommand, commandType: CommandType.Text);

            //Trả về kết quả cho Client 
            return entities;
        }

        /// <summary>
        /// Lấy dữ liệu theo nhiều tiêu chí khác nhau
        /// </summary>
        /// <typeparam name="MISAEntity">Type của object</typeparam>
        /// <param name="sqlCommand">Tên store hoặc mã SQL (nếu lấy tất cả thì không cần truyền đối số này)</param>
        /// <param name="parameters">Đối tượng chứa thông tin tham số Store (tùy chọn)</param>
        /// <param name="commandType">Mặc định là CommandType.Text</param>
        /// <returns></returns>
        /// CreatedBy: Đào Đức Thao (05/02/2021)
        public IEnumerable<MISAEntity> GetData(string sqlCommand = null, object parameters = null, CommandType commandType = CommandType.Text)
        {
            var className = typeof(MISAEntity).Name;
            if(sqlCommand == null)
            {
                sqlCommand = $"SELECT * FROM {className}";
            }
            // Lấy dữ liệu 
            var data = _dbConnection.Query<MISAEntity>(sqlCommand, param: parameters, commandType: commandType);
            return data;
        }

        /// <summary>
        /// Thực hiện thêm mới object vào database 
        /// </summary>
        /// <param name="entity">object cần thêm mới</param>
        /// <returns>Số lượng bản ghi thêm được vào database</returns>
        /// CreatedBy: Đào Đức Thao (03/02/2021)
        public int InsertObject(MISAEntity entity)
        {
            var sqlCommand = "INSERT INTO CustomerGroup " +
                "(CustomerGroupId, " +
                "CustomerGroupName, " +
                "Description, " +
                "CreatedDate, " +
                "CreatedBy, " +
                "ModifiedDate, " +
                "ModifiedBy) " +
                "VALUES('', '', '', NOW(), '', NOW(), ''); ";

            var sqlPropName = string.Empty;
            var sqlPropValue = string.Empty;
            var className = typeof(MISAEntity).Name;
            var sqlInsertFinal = $"INSERT INTO {className} ({sqlPropName}) VALUE ({sqlPropValue})";
            // Lấy ra các property của object:
            var properties = typeof(MISAEntity).GetProperties();
            // Duyệt từng Property - lấy tên và giá trị của property 
            // - Tên thì đặt là tên param trong câu truy vấn sql
            // - Value thì sẽ gán là giá trị của param tương ứng trong câu lệnh SQL.

            foreach(var property in properties)
            {
                var propName = property.Name;
                var propValue = property.GetValue(entity);
                sqlPropName = sqlPropName + $",{propName}";
                if(property.PropertyType == typeof(Guid) || property.PropertyType == typeof(string))
                {
                    sqlPropValue = sqlPropValue + $",'{propValue}'";
                }
                else if (property.PropertyType == typeof(DateTime) || property.PropertyType == typeof(DateTime?))
                {
                    var datetime = (DateTime)propValue;
                    string dateTimeString = datetime.ToString("yyyy-MM-dd hh:mm:ss");
                    sqlPropValue = sqlPropValue + $",'{dateTimeString}'";
                }
                else
                {
                    sqlPropValue = sqlPropValue + $",{propValue}";
                }
            }
            sqlPropName = sqlPropName.Remove(0, 1);
            sqlPropValue = sqlPropValue.Remove(0, 1);

            sqlInsertFinal = $"INSERT INTO {className} ({sqlPropName}) VALUE ({sqlPropValue})";

            //var res = _dbConnection.Execute("Proc_InsertCustomer", param: entity, commandType: CommandType.StoredProcedure);
            return 0;
        }


       
        #endregion
    }
}
