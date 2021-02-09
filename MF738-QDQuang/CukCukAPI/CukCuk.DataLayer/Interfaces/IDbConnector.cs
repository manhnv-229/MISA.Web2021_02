using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace CukCuk.DataLayer.Interfaces
{
    /// <summary>
    /// INTERFACE cho kết nối tới cơ sở dữ liệu
    /// </summary>
    /// <typeparam name="TEntity">Kiểu Object</typeparam>
    /// CreatedBy: QDQuang (08/02/2021)
    public interface IDbConnector<TEntity>
    {
        /// <summary>
        /// Lấy dữ liệu theo tiêu chí khác nhau
        /// </summary>
        /// <param name="sqlCommand">Câu lệnh Query (mặc định = null)</param>
        /// <param name="parameters">Các tham số truyền vào trong câu query (mặc định = null)</param>
        /// <param name="commandType">Loại command (mặc định = Text)</param>
        /// <returns>Entities</returns>
        /// CreatedBy: QDQuang (08/02/2021)
        public IEnumerable<TEntity> GetData(string sqlCommand = null, object parameters = null, CommandType commandType = CommandType.Text);

        /// <summary>
        /// Thêm mới bản ghi
        /// </summary>
        /// <param name="entity">Object</param>
        /// <returns>Int (Số hàng tác động vào cơ sở dữ liệu)</returns>
        /// CreatedBy: QDQuang (08/02/2021)
        public int Insert(TEntity entity);

        /// <summary>
        /// Cập nhập thông tin bản ghi
        /// </summary>
        /// <param name="entity">Object</param>
        /// <returns>Int (Số hàng tác động vào cơ sở dữ liệu)</returns>
        /// CreatedBy: QDQuang (08/02/2021)
        public int Update(TEntity entity);

        /// <summary>
        /// Xóa bản ghi
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns>Int (Số hàng tác động vào cơ sở dữ liệu)</returns>
        /// CreatedBy: QDQuang (08/02/2021)
        public int Delete(string id);
    }
}
