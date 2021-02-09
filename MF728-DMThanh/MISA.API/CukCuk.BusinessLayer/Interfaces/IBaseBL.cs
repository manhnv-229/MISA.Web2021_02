using CukCuk.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CukCuk.BusinessLayer.Interfaces
{
    /// <summary>
    /// Base interface
    /// </summary>
    /// <typeparam name="T">Object</typeparam>
    /// CreatedBy: DMThanh (06/02/2021)
    public interface IBaseBL<T>
    {
        /// <summary>
        /// Lấy dữ liệu
        /// </summary>
        /// <returns></returns>
        /// CreatedBy: DMThanh (06/02/2021)
        ServiceResult GetData();

        /// <summary>
        /// Thêm mới khách hàng
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        ServiceResult Insert(T entity);

        /// <summary>
        /// Cập nhật bản ghi
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>ServiceResult</returns>
        /// CreatedBy: DMThanh (06/02/2021)
        ServiceResult Update(T entity);

        /// <summary>
        /// Xóa bản ghi
        /// </summary>
        /// <param name="id"></param>
        /// <returns>ServiceResult</returns>
        /// CreatedBy: DMThanh (06/02/2021)
        ServiceResult Delete(string id);
    }
}
