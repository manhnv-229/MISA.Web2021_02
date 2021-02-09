using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace MISA.DAO.Interfaces
{
    public interface IDbConnector<T>
    {
        /// <summary>
        /// Lay Du Lieu
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sqlCommand"></param>
        /// <param name="parameters"></param>
        /// <param name="commandType"></param>
        /// <returns></returns>
        /// CreatedBy: NDLuu (8/2/2021)
        IEnumerable<T> GetAllData(string sqlCommand = null, object parameters = null, CommandType commandType = CommandType.Text);

        /// <summary>
        /// Them moi ban ghi
        /// </summary>
        /// <param name="entity">Đối tượng cần thêm</param>
        /// <returns> số lượng bản ghi thêm vào</returns>
        /// CreatedBy: NDLuu (8/2/2021)
        int Insert(T entity);

        /// <summary>
        /// Cap nhat ban ghi
        /// </summary>
        /// <param name="entity">đối tượng cần cập nhật</param>
        /// <returns>Số lượng bản ghi cập nhật</returns>
        /// CreatedBy: NDLuu (8/2/2021)
        public int Update(T entity);

        /// <summary>
        /// Xoa Ban ghi
        /// </summary>
        /// <param name="id">id của đối tượng cần xoá</param>
        /// <returns>số lượng bản ghi xoá</returns>
        /// CreatedBy: NDLuu (8/2/2021)
        int Delete(string id);


    }
}
