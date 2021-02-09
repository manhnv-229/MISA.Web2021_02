using Common.Other;
using System;

namespace ApplicationCore.Interfaces
{
    /// <summary>
    /// Giao diện của tầng nghiệp vụ
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface IBaseService<TEntity>
    {
        /// <summary>
        /// Lấy danh sách các đối tượng
        /// </summary>
        /// <returns>Object Collection</returns> 
        public ServiceResult GetData();
        /// <summary>
        /// Thêm thông tin đối tượng
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>Object Collection</returns>
        public ServiceResult Insert(TEntity entity);
        /// <summary>
        /// Cập nhật thông tin đối tượng
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>Object Collection</returns>
        public ServiceResult Update(TEntity entity);
        /// <summary>
        /// Xóa thông tin đối tượng
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Object Collection</returns>
        public ServiceResult Delete(Guid id);
        /// <summary>
        /// Kiểm tra, xác thực dữ liệu đầu vào
        /// </summary>
        public void ValidateData(TEntity entity);
    }
}
