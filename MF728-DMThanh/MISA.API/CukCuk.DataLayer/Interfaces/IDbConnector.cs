using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace CukCuk.DataLayer.Interfaces
{
    /// <summary>
    /// Interface dữ liệu
    /// </summary>
    /// <typeparam name="T">Kiểu Object</typeparam>
    /// CreatedBy: DMThanh (06/02/2021)
    public interface IDbConnector<T>
    {
        /// <summary>
        /// Lấy dữ liệu
        /// </summary>
        /// <param name="sqlCommand">Câu lệnh Query (mặc định = null)</param>
        /// <param name="parameters">Tham số truyền vào</param>
        /// <param name="commandType">Loại command</param>
        /// <returns>Danh sách bản ghi từ SQL</returns>
        /// CreatedBy: DMThanh (06/02/2021)
        public IEnumerable<T> GetData(string sqlCommand = null, object parameters = null, CommandType commandType = CommandType.Text);

        /// <summary>
        /// Thêm mới bản ghi
        /// </summary>
        /// <param name="entity">Object</param>
        /// <returns>Sô bản ghi được thêm thành công</returns>
        /// CreatedBy: DMThanh (06/02/2021)
        public int Insert(T entity);

        /// <summary>
        /// Cập nhập thông tin khách hàng
        /// </summary>
        /// <param name="entity">Object</param>
        /// <returns>Sô bản ghi được sửa thành công</returns>
        /// CreatedBy: DMThanh (06/02/2021)
        public int Update(T entity);

        /// <summary>
        /// Xóa bản ghi
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns>Số bản ghi được xoá thành công</returns>
        /// CreatedBy: DMThanh (06/02/2021)
        public int Delete(string id);
    }
}
