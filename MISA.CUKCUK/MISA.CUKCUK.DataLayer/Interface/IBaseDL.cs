using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.DataLayer.Interface
{
    public interface IBaseDL<T> where T: class
    {
        //Lấy tất cả
        IEnumerable<T> GetAll();

        //Lấy theo id
        T GetById(Guid id);

        //Thêm mới
        int Insert(T entity);

        //Sửa
        int Update(T entity);

        //Xóa
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
