﻿using Dapper;
using FresherProject.Common;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace FresherProject.DataLayer.Database
{
    public class DBConnectorV2<T> : IDisposable
    {
        protected static string connectionString = "User Id=nvmanh;" +
            "Host=103.124.92.43;" +
            "Port=3306;Database=MS2_01_NTAnh_CukCuk;" +
            "Password=12345678;Character Set=utf8";
        IDbConnection dBConnection;
        public DBConnectorV2()
        {
            dBConnection = new MySqlConnection(connectionString);
        }
        public void Dispose()
        {
            dBConnection.Close();
        }
        /// <summary>
        /// Get danh sách toàn bộ dữ liệu trong bảng
        /// </summary>
        /// <typeparam name="T">Đối tượng muốn lấy ra danh sách trong CSDL</typeparam>
        /// <returns>List of T</returns>
        public IEnumerable<T> GetAllData()
        {
            var tableName = typeof(T).Name;
            var storeName = $"Proc_Get{tableName}s";
            var entity = dBConnection.Query<T>(storeName, commandType: CommandType.StoredProcedure);

            //if (tableName == "Employee")
            //{
            //    var entitys = dBConnection.Query<Employee, EmployeeDepartment, EmployeePosition, Employee>(storeName, (e, department, position) =>
            //    {
            //        e.EmployeeDepartment = department;
            //        e.EmployeePosition = position;
            //        return e;
            //    }, splitOn: "EmployeeDepartmentId, EmployeePositionId", commandType: CommandType.StoredProcedure);
            //    return (IEnumerable<T>)entitys;
            //}

            return entity;
        }
        /// <summary>
        /// Lấy dữ liệu theo command Text truyền vào
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="commandText">Mã sql</param>
        /// <returns>Mảng các object lấy được từ database</returns>
        /// Created by: Ngoc (2/1/2021)
        public IEnumerable<T> GetAllData(string commandText)
        {
            string className = typeof(T).Name;
            var sql = commandText;
            var entities = dBConnection.Query<T>(sql);
            return entities;
        }
        public IEnumerable<T> GetById(Guid id)
        {
            var tableName = typeof(T).Name;
            var storeName = $"Proc_Get{tableName}ById";
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add($"@{tableName}Id", id.ToString());
            var entity = dBConnection.Query<T>(storeName, dynamicParameters, commandType: CommandType.StoredProcedure);
            return entity;
        }
        //public IEnumerable<T> GetByFilter<T>(string filter)
        //{
        //    var tableName = typeof(T).Name;
        //    var storeName = $"Proc_Get{tableName}ByFilter";
        //    var entity = dBConnection.Query<T>(storeName, new { Filter = filter}, commandType: CommandType.StoredProcedure);
        //    return entity;
        //}



        public int Insert(T entity)
        {
            var tableName = typeof(T).Name;
            var storeName = $"Proc_Insert{tableName}";
            DynamicParameters dynamicParameters = new DynamicParameters();
            //Đọc các property của T:
            var properties = typeof(T).GetProperties();
            foreach (var property in properties)
            {
                var propertyName = property.Name;
                var propertyValue = property.GetValue(entity);
                var propertyType = property.PropertyType.Name;
                if (propertyType != "String" && propertyType != "DateTime" && propertyValue != null)
                    propertyValue = property.GetValue(entity).ToString();
                dynamicParameters.Add($"@{propertyName}", propertyValue);
            }
            var affectRows = dBConnection.Execute(storeName, dynamicParameters, commandType: CommandType.StoredProcedure);
            return affectRows;
        }

        public int Delete(Guid id)
        {
            var tableName = typeof(T).Name;
            var storeName = $"Proc_Delete{tableName}";
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add($"@Delete{tableName}Id", id.ToString());
            var affectRows = dBConnection.Execute(storeName, dynamicParameters, commandType: CommandType.StoredProcedure);
            return affectRows;
        }
        public int Update(T entity)
        {
            var tableName = typeof(T).Name;
            var storeName = $"Proc_Update{tableName}";
            DynamicParameters dynamicParameters = new DynamicParameters();
            //Đọc các property của T:
            var properties = typeof(T).GetProperties();
            foreach (var property in properties)
            {
                var propertyName = property.Name;
                var propertyValue = property.GetValue(entity);
                var propertyType = property.PropertyType.Name;
                if (propertyType != "String" && propertyType != "DateTime")
                    propertyValue = property.GetValue(entity).ToString();
                dynamicParameters.Add($"@{propertyName}", propertyValue);
            }
            var affectRows = dBConnection.Execute(storeName, dynamicParameters, commandType: CommandType.StoredProcedure);
            return affectRows;
        }
    }
}
