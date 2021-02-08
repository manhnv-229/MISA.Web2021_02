
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Linq;
using MISA.DataLayer.Interfaces;

namespace MISA.DataLayer
{
    public class MariaDbContextV2<Entity> : IDbContext<Entity>
    {
        #region DECLARE

        protected string className = typeof(Entity).Name;
        // khai báo thông tin kết nối 
        String _connectionString = "Host=103.124.92.43;" +
        "Database =MISACukCuk_MF718_NQDat ;" +
        "Port=3306;User Id=nvmanh;" +
        " Password =12345678 ;" +
        "Character Set=utf8";

        // khởi tạo kết nối 
        protected IDbConnection _dbConnection;
        #endregion

        #region Constructor
        /// <summary>
        /// hàm khởi tạo 
        /// </summary>
        ///   CreatedBy: TQAnh (08/02/2021)
        public MariaDbContextV2()
        {
            _dbConnection = new MySqlConnector.MySqlConnection(_connectionString);
        }

        #endregion

        #region Method

        /// <summary>
        /// lấy dữ liệu 
        /// </summary>
        /// <returns>trả về thông tin cần lấy </returns>
        ///   CreatedBy: TQAnh (08/02/2021)
        public IEnumerable<Entity> GetAll()
        {



            // thực thi truy vấn
            var entities = _dbConnection.Query<Entity>($"Select * from {className}", commandType: CommandType.Text);

            // trả về cho client
            return entities;
        }
        /// <summary>
        /// Thêm mới object vào database
        /// </summary>
        /// <param name="entity">Đối tượng được thêm mới</param>
        /// <returns>số dòng thêm thành công</returns>
        /// CreatedBy: TQAnh (08/02/2021)
        public int Insert(Entity entity)
        {
            // lấy ra các property của object
            var properties = typeof(Entity).GetProperties();

            // khởi tạo các biến string để lưu các giá trị property

            var sqlPropName = string.Empty;
            var sqlPropParam = string.Empty;
            var dynamiParameters = new DynamicParameters();
            // Duyệt tùng properties để lấy giá trị
            foreach (var propety in properties)
            {

                var propName = propety.Name;

                // sinh id mới
                if ((propety.PropertyType == typeof(Guid) || propety.PropertyType == typeof(Guid?)) && propName.ToLower() == $"{className}Id".ToLower())
                    propety.SetValue(entity, Guid.NewGuid());
                var propValue = propety.GetValue(entity);


                sqlPropName = sqlPropName + $",{propName}";
                sqlPropParam = sqlPropParam + $",@{propName}";
                dynamiParameters.Add($"@{propName}", propValue);



            }

            // Xóa đi kí tự "," đầu câu 
            sqlPropParam = sqlPropParam.Remove(0, 1);
            sqlPropName = sqlPropName.Remove(0, 1);


            var sqlComand = $"INSERT INTO {className} ({sqlPropName}) Value ({sqlPropParam})";
            var res = _dbConnection.Execute(sqlComand, param: dynamiParameters, commandType: CommandType.Text);
            return res;


        }


        /// <summary>
        /// chỉnh sửa 1 đối tượng
        /// </summary>
        /// <param name="id"> khóa chính của đối tượng cần chỉnh sửa </param>
        /// <param name="entity">giá trị cần chỉnh sửa </param>
        /// <returns> số dòng thành công </returns>
        /// CreatedBy: TQAnh (08/02/2021)
        public int Update(Guid id, Entity entity)
        {

            // lấy ra các property của object
            var properties = typeof(Entity).GetProperties();

            // khởi tạo các biến string để lưu các giá trị property
            var parameters = new DynamicParameters();
            var sqlParamBuider = string.Empty;
            // duyệt từng property
            foreach (var propety in properties)
            {
                var propetyName = propety.Name;
                var propetyValue = propety.GetValue(entity);

                parameters.Add($"@{propetyName}", propetyValue);

                sqlParamBuider += $",{propetyName}=@{propetyName}";

            }

            var sql = $"UPDATE  {className} SET {sqlParamBuider.Substring(1)} Where {className}id='{id.ToString()}'";
            var efectRows = _dbConnection.Execute(sql, parameters, commandType: CommandType.Text);
            return efectRows;


        }

        /// <summary>
        /// xóa 1 đối tượng
        /// </summary>
        /// <param name="id">khóa chính đối tượng cần xóa</param>
        /// <returns> số dòng thành công </returns>
        /// CreatedBy: TQAnh (08/02/2021)
        public int Delete(Guid id)
        {

            var sql = $"Delete From  {className}  Where {className}id='{id.ToString()}'";
            var efectRows = _dbConnection.Execute(sql);
            return efectRows;

        }




        /// <summary>
        /// check trùng trong database
        /// </summary>
        /// <param name="propertyValue"> giá trị cần kiểm tra</param>
        /// <param name="propertyName">trường cần kiểm tra</param>
        /// <returns> true: tồn tại , false: không tồn tại  </returns>
        ///   CreatedBy: TQAnh (08/02/2021)
        public bool CheckExits(string propertyValue, string propertyName)
        {
            var sql = $"SELECT {propertyName} From Customer as C Where C.{propertyName}='{propertyValue}'";
            var customerCodeExits = _dbConnection.Query<string>(sql).FirstOrDefault();
            if (customerCodeExits == null)
                return false;

            else return true;
        }



        #endregion
    }
}
