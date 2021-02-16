using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.DataLayer.Interface
{
    public interface IBaseDL<T> where T: class
    {
        /// <summary>
        /// Lấy tất cả
        /// </summary>
        /// <returns></returns>
        IEnumerable<T> GetAll();

        /// <summary>
        /// Lấy theo id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        T GetById(Guid id);

        /// <summary>
        /// Thêm mới
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        int Insert(T entity);

        /// <summary>
        /// Sửa
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        int Update(T entity);

        /// <summary>
        /// Xóa
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        int Delete(Guid id);

        /// <summary>
        /// Check trùng mã
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        T GetEntityByCode(string code);

        /// <summary>
        /// Check trùng theo tên trường
        /// </summary>
        /// <param name="fieldName"></param>
        /// <returns></returns>
        T GetEntityByField(string fieldName, string fieldValue);
    }
}
