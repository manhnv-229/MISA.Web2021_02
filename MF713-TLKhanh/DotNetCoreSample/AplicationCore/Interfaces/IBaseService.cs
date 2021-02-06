using AplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace AplicationCore.Interfaces
{
    public interface IBaseService<T>
    {
        /// <summary>
        /// Lấy ra tất cả bản ghi
        /// </summary>
        /// <returns>ServiceResult</returns>
        ServiceResult GetEntities();
        /// <summary>
        /// Lấy ra một bản ghi theo id
        /// </summary>
        /// <param name="id">Id của bản ghi cần lấy</param>
        /// <returns>ServiceResult</returns>
        ServiceResult GetEntity(string id);
        /// <summary>
        /// Thêm mới một bản ghi
        /// </summary>
        /// <param name="entity">Bản ghi cần thêm mới</param>
        /// <returns>ServiceResult</returns>
        ServiceResult InsertEntity(T entity);
        /// <summary>
        /// Cập nhật một bản ghi
        /// </summary>
        /// <param name="id">Id của bản ghi cần cập nhật</param>
        /// <param name="entity">Bản ghi thay thế bản ghi cũ</param>
        /// <returns>ServiceResult</returns>
        ServiceResult UpdateEntity(string id, T entity);
        /// <summary>
        /// Xóa một bản ghi theo id
        /// </summary>
        /// <param name="id">id của bản ghi cần xóa</param>
        /// <returns>ServiceResult</returns>
        ServiceResult DeleteEntity(string id);
    }
}
