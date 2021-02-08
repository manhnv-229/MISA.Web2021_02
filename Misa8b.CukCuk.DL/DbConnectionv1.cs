using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Misa8b.CukCuk.DL.Interfaces;
using Misa.CukCuk.Common;

namespace Misa8b.CukCuk.DL
{
    /// <summary>
    /// kết nối với database
    /// </summary>
    public class DbConnectionv1: StringDbV2
    {
        protected IDbConnection dbConnection;
        //protected IStringDb _stringDb;
        //public DbConnectionv1(IStringDb stringDb)
        //{
        //    _stringDb = stringDb;

        //    dbConnection = new MySqlConnection(_stringDb.getStringDb());
        //}
        public DbConnectionv1()
        {
            dbConnection = new MySqlConnection(stringConnectionDb);
        }
        /// <summary>
        /// lấy toàn bộ dữ liệu 
        /// 
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns>danh sách dữ liệu T</returns>
        public List<T> GetAllData<T>()
        {
            return dbConnection.Query<T>($"Proc_Get{typeof(T).Name}s", commandType: CommandType.StoredProcedure).ToList();
        }
        /// <summary>
        /// lấy dữ liệu bằng pagging
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="limit"></param>
        /// <param name="ofset"></param>
        /// <returns>danh sách dữ liệu</returns>
        public List<T> GetAllDataWithPagging<T>(int limit, int ofset)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add($"@LimitParam", limit);
            dynamicParameters.Add($"@OffsetParam", ofset);
            return dbConnection.Query<T>($"Proc_GetEmployeesPagging", dynamicParameters, commandType: CommandType.StoredProcedure).ToList();
        }
        /// <summary>
        /// lấy dữ liệu bằng id
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id"></param>
        /// <returns>1 bản ghi dữ liệu có id nhập vào</returns>
        public T GetDataById<T>(Guid id)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add($"@{typeof(T).Name}Id", id.ToString());
            return dbConnection.Query<T>($"Proc_Get{typeof(T).Name}ById", dynamicParameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
        }
        /// <summary>
        /// thêm mới dữ liệu
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        public void Insert<T>(T t)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            // Đọc các thuộc tính 
            var properties = typeof(T).GetProperties();
            foreach (var property in properties)
            {
                var propertyName = property.Name;
                var propertyValue = property.GetValue(t);
                if (propertyValue != null && propertyValue.GetType().ToString() == "System.Guid")
                {
                    var a = propertyValue.ToString();
                    dynamicParameters.Add($"@{propertyName}", a);
                }
                else
                {
                    var b = propertyValue;
                    dynamicParameters.Add($"@{propertyName}", b);
                }

            }
            dbConnection.Execute($"Proc_Insert{typeof(T).Name}", dynamicParameters, commandType: CommandType.StoredProcedure);
        }
        /// <summary>
        /// sửa dữ liệu
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        public void Update<T>(T t)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            // Đọc các thuộc tính 
            var properties = typeof(T).GetProperties();
            foreach (var property in properties)
            {
                var propertyName = property.Name;
                var propertyValue = property.GetValue(t);
                if (propertyValue != null && propertyValue.GetType().ToString() == "System.Guid")
                {
                    var a = propertyValue.ToString();
                    dynamicParameters.Add($"@{propertyName}", a);
                }
                else
                {
                    var b = propertyValue;
                    dynamicParameters.Add($"@{propertyName}", b);
                }

            }
            dbConnection.Execute($"Proc_Update{typeof(T).Name}", dynamicParameters, commandType: CommandType.StoredProcedure);
        }
        /// <summary>
        /// xóa dữ liệu
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id"></param>
        /// <returns></returns>
        public int DeleteData<T>(Guid id)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add($"@{typeof(T).Name}Id", id.ToString());
            return dbConnection.Execute($"Proc_Delete{typeof(T).Name}", dynamicParameters, commandType: CommandType.StoredProcedure);
        }
    }
}
