using MISA.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Service.interfaces
{
    public interface IBaseService<T>
    {
        /// <summary>
        /// Lấy danh sách tất cả các đối tượng 
        /// </summary>
        /// <typeparam name="T">Kiểu dữ liệu truyền vào</typeparam>
        /// <returns></returns>
        /// Created by PN Thuận : 6/2/2021
        ServiceResult GetAllData();
        /// <summary>
        /// Thêm đối tượng vào danh sách
        /// </summary>
        /// <typeparam name="T">Kiểu dữ liệu truyền vào</typeparam>
        /// <param name="entity">Đối tượng cần chèn</param>
        /// <returns></returns>
        /// Created by PN Thuận : 6/2/2021
        ServiceResult InsertEntity(T entity);
        /// <summary>
        /// Xóa đói tượng ra khỏi danh sách
        /// </summary>
        /// <typeparam name="T">Kiểu dữ liệu cần truyền vào</typeparam>
        /// <param name="id">Id của đối tượng cần xóa</param>
        /// <returns></returns>
        /// Created by PN Thuận : 6/2/2021
        ServiceResult DeleteEntityById(string id);
        /// <summary>
        /// Chỉnh sửa thông tin của đối tượng
        /// </summary>
        /// <typeparam name="T">Kiểu dữ liệu truyền vào</typeparam>
        /// <param name="entity">Đối tượng cần truyền</param>
        /// <param name="Id">Id của đối tượng đó</param>
        /// <returns></returns>
        /// Created by PN Thuận : 6/2/2021
        ServiceResult ModifiedEntity(T entity, string Id);
    }
}
