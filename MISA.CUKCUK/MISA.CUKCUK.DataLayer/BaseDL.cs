using Dapper;
using MISA.DataLayer.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace MISA.DataLayer
{
    /// <summary>
    /// Interface Datalayer
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BaseDL<T>: IBaseDL<T> where T: class
    {
        private readonly IDbContext<T> _dbContext;

        public BaseDL(IDbContext<T> dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// Thực thi proceduce lấy tất cả
        /// Đặt tên proc theo kiểu Proc_GetAll...
        /// </summary>
        /// <returns>Danh sách thực thể</returns>
        /// CreatedBy Vtthien 09/02/21
        public IEnumerable<T> GetAll()
        {
            var procName = "Proc_GetAll" + typeof(T).Name;
            var listEntity = _dbContext.Query(procName, commandType: CommandType.StoredProcedure);
            return listEntity;
        }

        /// <summary>
        /// Thực thi proceduce lấy theo id
        /// Đặt tên proc theo kiểu Proc_Get...ById
        /// </summary>
        /// <param name="id">Id</param>
        /// CreatedBy Vtthien 09/02/21
        /// <returns>Danh sách thực thể</returns>
        public T GetById(Guid id)
        {
            var procName = "Proc_Get" + typeof(T).Name + "ById" ;
            var param = new
            {
                id = id.ToString()
            };
            var parameters = new DynamicParameters(param);
            var listEntity = _dbContext.QueryFirst(procName, parameters, commandType: CommandType.StoredProcedure);
            return listEntity;
        }

        /// <summary>
        /// Thực thi proceduce insert
        /// Đặt tên proc theo kiểu Proc_Insert...
        /// </summary>
        /// <param name="entity">Thực thể cần thêm</param>
        /// <returns>Số bản ghi thay đổi</returns>
        /// CreatedBy VTThien 09/02/21
        public int Insert(T entity)
        {
            var procName = "Proc_Insert" + typeof(T).Name;
            var parameters = new DynamicParameters(entity);
            var result = _dbContext.Excute(procName, parameters, CommandType.StoredProcedure);
            return result;
        }

        /// <summary>
        /// Thực thi proceduce update
        /// Đặt tên proc theo kiểu Proc_Update...
        /// </summary>
        /// <param name="entity">Thực thể cần sửa</param>
        /// <returns>Số bản ghi thay đổi</returns>
        /// CreatedBy VTThien 09/02/21
        public int Update(T entity)
        {
            var procName = "Proc_Update" + typeof(T).Name;
            var parameters = new DynamicParameters(entity);
            var result = _dbContext.Excute(procName, parameters, CommandType.StoredProcedure);
            return result;
        }

        /// <summary>
        /// Thực thi proceduce delete
        /// Đặt tên proc theo kiểu Proc_Delete...
        /// </summary>
        /// <param name="entity">Thực thể cần xóa</param>
        /// <returns>Số bản ghi thay đổi</returns>
        /// CreatedBy VTThien 09/02/21
        public int Delete(Guid id)
        {
            var procName = "Proc_Delete" + typeof(T).Name;
            // vì dynamicParam không parse được id ?
            var param = new
            {
                id = id.ToString()
            };
            var parameters = new DynamicParameters(param);
            var result = _dbContext.Excute(procName, parameters, CommandType.StoredProcedure);
            return result;
        }

        /// <summary>
        /// Check trùng mã
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public T GetEntityByCode(string code)
        {
            string tableName = typeof(T).Name;
            string fieldCode = tableName + "Code";

            var sql = $"SELECT * FROM {tableName} WHERE {fieldCode} = '{code}'";
            var result = _dbContext.QueryFirst(sql);
            return result;
        }

        /// <summary>
        /// Check trùng theo tên trường
        /// </summary>
        /// <param name="fieldName">Tên trường cần check trùng</param>
        /// <param name="fieldValue">Giá trị</param>
        /// <returns></returns>
        public T GetEntityByField(string fieldName, string fieldValue)
        {
            string tableName = typeof(T).Name;

            var sql = $"SELECT * FROM {tableName} WHERE {fieldName} = '{fieldValue}'";
            var result = _dbContext.QueryFirst(sql);
            return result;
        }

    }
}
