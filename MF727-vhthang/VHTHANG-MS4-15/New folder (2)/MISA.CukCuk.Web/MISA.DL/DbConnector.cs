using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.DL
{
    public class DbConnector
    {
        //Khởi tạo
        protected string connectionString = "Host=103.124.92.43;User Id=nvmanh; password=12345678;Database=MS4_15_VHTHANG_destiny;port=3306;Character Set=utf8";
        protected IDbConnection dbConnection;
        public DbConnector()
        {
            dbConnection = new MySqlConnection(connectionString);
        }
        //Lấy toàn bộ dữ liệu
        public IEnumerable<TEntity> GetAllData<TEntity>()
        {
            var tableName = typeof(TEntity).Name;
            var storeName = $"Proc_Get{tableName}s";
            var entity = dbConnection.Query<TEntity>(storeName, commandType: CommandType.StoredProcedure);
            return entity;
        }
        //Lấy dữ liệu theo số trang và sắp xếp
        public IEnumerable<TEntity> GetDataByNumAndType<TEntity>(int num,string type)
        {
            var EmployeeInOnePage = 20;
            var tableName = typeof(TEntity).Name;
            var storeName = $"Proc_Get{tableName}ByNumAndType";
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add($"@num1", num* EmployeeInOnePage);
            dynamicParameters.Add($"@num2", EmployeeInOnePage);
            dynamicParameters.Add($"@type", type);
            var entity = dbConnection.Query<TEntity>($"SELECT * FROM {tableName} ORDER BY {type} DESC LIMIT {num * EmployeeInOnePage}, {EmployeeInOnePage};");
            return entity;
        }
        //Lấy dữ liệu qua id
        public IEnumerable<TEntity> GetById<TEntity>(string id)
        {
            var tableName = typeof(TEntity).Name;
            var storeName = $"Proc_Get{tableName}ById";
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add($"@{tableName}Id", id);
            var entity = dbConnection.Query<TEntity>(storeName, dynamicParameters, commandType:CommandType.StoredProcedure);
            return entity;
        }
        //Lấy dữ liệu qua mã 
        public IEnumerable<TEntity> GetByCode<TEntity>(string code)
        {
            var tableName = typeof(TEntity).Name;
            var storeName = $"Proc_Get{tableName}ByCode";
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add($"@{tableName}Code", code);
            var entity = dbConnection.Query<TEntity>(storeName, dynamicParameters, commandType: CommandType.StoredProcedure);
            return entity;
        }
        //Lấy dữ liệu qua mã 
        public TEntity GetByCode1<TEntity>(string code)
        {
            var tableName = typeof(TEntity).Name;
            var storeName = $"Proc_Get{tableName}ByCode";
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add($"@{tableName}Code", code);
            var entity = dbConnection.Query<TEntity>(storeName, dynamicParameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            return entity;
        }
        //Lấy Dữ liệu theo sdt va mã
        public IEnumerable<TEntity> GetDataByPhoneAndCode<TEntity>(string phone,string code)
        {
            var tableName = typeof(TEntity).Name;
            var storeName = $"Proc_Get{tableName}ByPhoneAndCode";
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add($"@PhoneNumberContains", phone);
            dynamicParameters.Add($"@CustomerCodeContains", code);
            var entity = dbConnection.Query<TEntity>(storeName, dynamicParameters, commandType: CommandType.StoredProcedure);
            return entity;
        }
        //Thêm dữ liệu
        public int Insert<TEntity>(TEntity entity)
        {
            var tableName = typeof(TEntity).Name;           
            var storeName = $"Proc_Insert{tableName}";
            DynamicParameters dynamicParameters = new DynamicParameters();
            var properties = typeof(TEntity).GetProperties();
            foreach(var property in properties)
            {
                var propertyName = property.Name;
                var propertyValue = property.GetValue(entity);
                var propertyType = property.PropertyType;
                if (propertyType == typeof(Guid) || propertyType == typeof(Guid?))
                {
                    dynamicParameters.Add($"@{propertyName}", propertyValue, DbType.String);
                }
                else
                {
                    dynamicParameters.Add($"@{propertyName}", propertyValue);
                }
            }            
            var query = dbConnection.Execute(storeName, dynamicParameters, commandType:CommandType.StoredProcedure);
            return query;
        }
        //Lấy mã code cao nhất
        public List<string> GetCodeMax<TEntity>()
        {
            var tableName = typeof(TEntity).Name;
            var storeName = $"Proc_Get{tableName}CodeMax";
            var codeMax = dbConnection.Query<string>(storeName, commandType: CommandType.StoredProcedure).ToList();
            return codeMax;
        }
        //Thay đổi Thông tin nhân viên
        public int Update<TEntity>(TEntity entity)
        {
            var tableName = typeof(TEntity).Name;
            var storeName = $"Proc_Update{tableName}";
            DynamicParameters dynamicParameters = new DynamicParameters();
             var properties = typeof(TEntity).GetProperties();
            foreach (var property in properties)
            {
                var propertyName = property.Name;
                var propertyValue = property.GetValue(entity);
                var propertyType = property.PropertyType;
                if (propertyType == typeof(Guid) || propertyType == typeof(Guid?))
                {
                    dynamicParameters.Add($"@{propertyName}", propertyValue, DbType.String);
                }
                else
                {
                    dynamicParameters.Add($"@{propertyName}", propertyValue);
                }


            }
            var query = dbConnection.Execute(storeName, dynamicParameters, commandType: CommandType.StoredProcedure);
            return query;
        }
        //Check code va id có cùng của 1 nhân viên
        public IEnumerable<TEntity> GetDataByIdAndCode<TEntity>(string id, string code)
        {
            var tableName = typeof(TEntity).Name;
            var storeName = $"Proc_Get{tableName}ByIdAndCode";
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add($"@PhoneNumberContains", id);
            dynamicParameters.Add($"@CustomerCodeContains", code);
            var entity = dbConnection.Query<TEntity>(storeName, dynamicParameters, commandType: CommandType.StoredProcedure);
            return entity;
        }
        //Xóa Nhân viên
        public int Delete<TEntity>(string id)
        {
            var tableName = typeof(TEntity).Name;
            var storeName = $"Proc_Delete{tableName}ById";
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add($"@Id", id);
            var query = dbConnection.Execute(storeName, dynamicParameters, commandType: CommandType.StoredProcedure);
            return query;
        }

    }
}
