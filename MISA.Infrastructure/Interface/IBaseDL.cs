using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Infrastructure.Interface
{
    public interface IBaseDL<T>
    {
        /// <summary>
        /// Lấy toàn bộ dữ liệu có thuộc tính T trong data
        /// </summary>
        /// <typeparam name="T">thuộc tính chung</typeparam>
        /// <returns></returns>
        IEnumerable<T> GetData();
        /// <summary>
        /// thêm mới dữ liệu
        /// </summary>
        /// <param name="entity">thuộc tính chung</param>
        /// <returns>số lượng bản ghi thêm mới thành công</returns>
        int InsertData(T entity);
        /// <summary>
        /// Cập nhật dữ liệu
        /// </summary>
        /// <param name="entity">thuộc tính chung</param>
        /// <returns>sô bản ghi sửa thành công</returns>
        int UpdateData(T entity);
    }
}
