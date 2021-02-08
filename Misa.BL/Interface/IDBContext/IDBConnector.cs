using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Misa.BL.Interface.IDBContext
{
    public interface IDBConnector
    {
        /// <summary>
        /// lấy danh sách bản ghi theo fielName(option)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="offSet"></param>
        /// <param name="limmit"></param>
        /// <param name="fieldNames"></param>
        /// <param name="values"></param>
        /// <returns>danh sách các bản ghi</returns>
        /// createdBy: Manh Tien (5/2/2021)
        public IEnumerable<T> GetData<T>(long page, long limmit, List<string> fieldNames = null, List<string> values = null);

        /// <summary>
        /// lấy bản ghi bằng câu lệnh sql
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <returns>danh sách bản ghi</returns>
        /// createdBy: Mạnh Tiến(27/12/2020)
        public IEnumerable<T> GetData<T>(string sql);

        /// <summary>
        /// thêm mới 1 bản ghi
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <returns>số bảng ghi được thêm mới</returns>
        /// createdBy: Mạnh Tiến(26/12/2020)
        public int Insert<T>(T entity);

        /// <summary>
        /// cập nhật bản ghi
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <returns>số bản ghi được cập nhật</returns>
        /// createdBy: Mạnh Tiến(26/12/2020)
        public int Update<T>(T entity);

        /// <summary>
        /// xóa bản ghi theo id của đối tượng
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id"></param>
        /// <returns>số bản ghi bị xóa</returns>
        /// createdBy: Mạnh Tiến(26/12/2020)
        public int Delete<T>(string id);

        /// <summary>
        /// lấy tổng số bản ghi, không truyền tham số thì sẽ lấy tổng số bản ghỉ
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="fieldNames"></param>
        /// <param name="values"></param>
        /// <returns>số lượng bản ghi: long</returns>
        /// createdBy: Manh Tien (5/2/2021)
        public long Count<T>(List<string> fieldNames = null, List<string> values = null);

        /// <summary>
        /// lấy DBconnection của database
        /// </summary>
        /// <returns>connection của database</returns>
        /// createdBy: Manh Tien (8/2/2021)
        public IDbConnection GetDBConnection();

    }
}
