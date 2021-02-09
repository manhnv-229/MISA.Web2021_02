using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure
{
    /// <summary>
    /// Giao diện của DBContext
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface IDbContext<TEntity>
    {
        /// <summary>
        /// Lấy danh sách các bản ghi 
        /// </summary>
        /// <returns>Danh sách các bản ghi</returns>
        public IEnumerable<TEntity> GetAll();
        /// <summary>
        /// Lấy thông tin của đối tượng theo Id
        /// </summary>
        /// <returns>Đối tượng cần tìm</returns>
        public TEntity GetById(Guid id);

        /// <summary>
        /// Thêm bản ghi mới vào cơ sở dữ liệu
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>Số bản ghi thêm mới vào cơ sở dữ liệu</returns>
        public int Insert(TEntity entity);
        /// <summary>
        /// Sửa một bản ghi có trong cơ sở dữ liệu
        /// </summary>
        /// <param name="entity">Đối tượng cần thêm mới</param>
        /// <returns>Số bản ghi được cập nhật</returns>
        public int Update(TEntity entity);
        /// <summary>
        /// Xóa một bản ghi trong cơ sở dữ liệu có Id bằng Id truyền vào
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns>Số bản ghi bị xóa</returns>
        public int Delete(Guid id);
        /// <summary>
        /// Kiểm tra sự tồn tại của bản ghi có trường tương ứng trong cơ sở dữ liệu
        /// </summary>
        /// <param name="propName">Tên trường</param>
        /// <param name="propValue">Giá trị của trường</param>
        /// <returns>Trả về true nếu tồn tại bản ghi cần tìm, ngược lại trả về false</returns>
        public bool CheckExist(string propName, string propValue);

    }
}
