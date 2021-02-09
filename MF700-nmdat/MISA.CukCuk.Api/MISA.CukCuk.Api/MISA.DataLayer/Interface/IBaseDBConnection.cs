using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace MISA.DataLayer.Interface
{
    /// <summary>
    /// interface base tham chiếu tới dbcontext version
    /// </summary>
    /// <typeparam name="T">Thực thể cần connect</typeparam>
    /// CreatedBy : NMDAT (08/02/2021)
    public interface IBaseDBConnection<T>
    {
        /// <summary>
        /// Hàm lấy dữ liệu
        /// </summary>
        /// <param name="sqlCommand">Câu lệnh truy vấn nếu không truyền mặc định là select * from T</param>
        /// <param name="parameters">Dữ liệu truyền vào</param>
        /// <param name="commandType">Kiểu lấy dữ liệu</param>
        /// <returns>Trả về danh sách dữ liệu</returns>
        IEnumerable<T> GetAll(string sqlCommand = null, object parameters = null, CommandType commandType = CommandType.Text);
        /// <summary>
        /// Hàm insert dữ liệu
        /// </summary>
        /// <param name="entity">Dữ liệu truyền vào</param>
        /// <param name="commandType">Kiểu insert(store hay text)</param>
        /// <returns>Số dòng insert thành công</returns>
        int InsertObject(T entity, CommandType commandType = CommandType.Text);
        /// <summary>
        /// Hàm update dữ liệu
        /// </summary>
        /// <param name="entity">Dữ liệu truyền vào</param>
        /// <param name="commandType">Kiểu insert(store hay text)</param>
        /// <returns>Số dòng insert thành công</returns>
        int UpdateObject(T entity, CommandType commandType = CommandType.Text);
        /// <summary>
        /// Hàm delete dữ liệu
        /// </summary>
        /// <param name="entity">Dữ liệu truyền vào</param>
        /// <param name="commandType">Kiểu insert(store hay text)</param>
        /// <returns>Số dòng insert thành công</returns>
        int DeleteObject(T entity, CommandType commandType = CommandType.Text);
    }
}
