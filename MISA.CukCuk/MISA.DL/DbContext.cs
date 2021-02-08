using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Dapper;
using System.Linq;
using MISA.Common.Model;

namespace MISA.DL
{
    public class DbContext<MISAEntity>
    {
        #region Declare
        protected string _connectionString = "Host=103.124.92.43;port=3306;Database=MS2-39-DVCuong_CukCuk;user=nvmanh;password=12345678;";
        protected IDbConnection _dbConnection;
        #endregion
        #region constructor
        public DbContext()
        {
            _dbConnection = new MySqlConnector.MySqlConnection(_connectionString);
        }
        #endregion

        #region method

        /// <summary>
        /// Lấy danh sách bản ghi
        /// </summary>
        /// <typeparam name="MISAEntity">Kiểu dữ liệu</typeparam>
        /// <returns>Trả về bản ghi</returns>
        /// Trường hợp lấy hết
        public IEnumerable<MISAEntity> GetAll()
        {
            var className = typeof(MISAEntity).Name;
            //thực thi truy vấn dữ liệu
            var entites = _dbConnection.Query<MISAEntity>($"Select * From {className}", commandType: CommandType.Text);
            //Trả kết quả về client
            return entites;
        }

        //Trường hợp tinh chỉnh command type
        public IEnumerable<MISAEntity> GetAll(string sqlCommand, CommandType commandType = CommandType.Text)
        {

            //thực thi truy vấn dữ liệu
            var entites = _dbConnection.Query<MISAEntity>(sqlCommand, commandType: commandType);
            //Trả kết quả về client
            return entites;
        }
        /// <summary>
        /// Lấy dữ liệu theo các tiêu chí
        /// </summary>
        /// <typeparam name="MISAEntity">Kiểu Object</typeparam>
        /// <param name="sqlCommand">Tên store</param>
        /// <param name="parameters">Đối tượng chứa tham số của store</param>
        /// <param name="commandType"></param>
        /// <returns></returns>
        public IEnumerable<MISAEntity> GetData(string sqlCommand = null, object parameters = null, CommandType commandType = CommandType.Text)
        {
            var className = typeof(MISAEntity).Name;

            //DynamicParameters dynamicParameters = new DynamicParameters();
            //dynamicParameters.Add("@CustomerCodeContains", 9956);
            //dynamicParameters.Add("@PhoneNumberContains");
            if(sqlCommand == null)
            {
                sqlCommand = $"SELECT * FROM {className}";
                return _dbConnection.Query<MISAEntity>(sqlCommand);
            }
            if(parameters != null)
            {

            return _dbConnection.Query<MISAEntity>(sqlCommand, param: parameters, commandType:commandType);
            
            }
            var data = _dbConnection.Query<MISAEntity>(sqlCommand, commandType: commandType);
            return data;
        }

        public int InsertObject(MISAEntity entity)
        {
            var className = typeof(MISAEntity).Name;
            //Lấy ra các property của object:
            var properties = typeof(MISAEntity).GetProperties();
            string sqlPropName = string.Empty;
            string sqlPropValue = string.Empty;
            var sqlPropParam = string.Empty;
            var sqlCommand = string.Empty;
            //Duyệt từng property - lấy tên và giá trị của property
            DynamicParameters dynamicParameters = new DynamicParameters();

            #region Truyền với param
            foreach (var property in properties)
            {
                var propName = property.Name;
                var propValue = property.GetValue(entity);

                if((property.PropertyType == typeof(Guid)|| property.PropertyType == typeof(Guid?)) && propName.ToLower() == $"{className}Id".ToLower())
                    propValue = Guid.NewGuid();

                sqlPropName = sqlPropName + $",{propName}";
                sqlPropParam = sqlPropParam + $",@{propName}";
                dynamicParameters.Add($"@{propName}", propValue);
            }
            sqlCommand = $"INSERT INTO {className}({sqlPropName.Remove(0, 1)}) VALUES ({sqlPropParam.Remove(0, 1)})";
            var res = _dbConnection.Execute(sqlCommand,param:dynamicParameters, commandType: CommandType.Text);
            return res;
            #endregion

        //    #region Truyền thẳng value
        //    foreach (var property in properties)
        //    {
        //        var propName = property.Name;
        //        var propValue = property.GetValue(entity);
        //        sqlPropName = sqlPropName + $",{propName}";
                
        //        if (property.PropertyType == typeof(Guid) || property.PropertyType == typeof(string))
        //        {
        //            sqlPropValue = sqlPropValue + $",'{propValue}'";
        //        }else if (property.PropertyType == typeof(Guid?))
        //        {
        //            if (propValue == null)
        //            {
        //                sqlPropValue = sqlPropValue + $",NULL";
        //            }
        //            else
        //            {
        //                sqlPropValue = sqlPropValue + $",'{propValue}'";
        //            }
        //        }
        //        else if(property.PropertyType == typeof(DateTime) || property.PropertyType == typeof(DateTime?))
        //        {
        //            var dateTime = (DateTime)propValue;
        //            string dateTimeString = dateTime.ToString("yyyy-MM-dd hh:mm:ss");
        //            sqlPropValue = sqlPropValue + $",'{dateTimeString}'";
        //        }
        //        else
        //        {
        //            sqlPropValue = sqlPropValue + $",'{propValue}'";
        //        }
        //    }

        //    sqlCommand = $"INSERT INTO {className}({sqlPropName.Remove(0, 1)}) VALUES ({sqlPropValue.Remove(0, 1)})";
        //    var res = _dbConnection.Execute(sqlCommand, commandType: CommandType.Text);
        //    return res;
        //#endregion
        }
        /// <summary>
        /// Sửa Object
        /// </summary>
        /// <param name="id">id object cần sửa</param>
        /// <param name="entity">đối tượng cần sửa</param>
        /// <returns></returns>
        /// created by: dvcuong (08/02/2021)
        public int UpdateObject(Guid id, MISAEntity entity)
        {
            var className = typeof(MISAEntity).Name;
            // Lấy ra các property của object
            var properties = typeof(MISAEntity).GetProperties();

            // khởi tạo các biến string để lưu các giá trị property
            var parameters = new DynamicParameters();
            var sqlParamBuider = string.Empty;
            // duyệt từng property
            foreach (var property in properties)
            {
                var propetyName = property.Name;
                var propetyValue = property.GetValue(entity);

                parameters.Add($"@{propetyName}", propetyValue);

                sqlParamBuider += $",{propetyName}=@{propetyName}";

            }

            var sql = $"UPDATE  {className} SET {sqlParamBuider.Remove(0, 1)} Where {className}id='{id.ToString()}'";
            var efectRows = _dbConnection.Execute(sql, parameters, commandType: CommandType.Text);
            return efectRows;
        }

        public int DeleteObject(Guid id)
        {
            var className = typeof(MISAEntity).Name;
            var sqlCommand = $"Delete From  {className}  Where {className}id='{id.ToString()}'";
            var efectRows = _dbConnection.Execute(sqlCommand);
            return efectRows;

        }

    }
    #endregion
}
