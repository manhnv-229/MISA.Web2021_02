using MISA.Common.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Service.Interface
{
    /// <summary>
    /// Interface base 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// CreatedBy: NMDAT(07/02/2021)
    public interface IBaseService<T>
    {
        /// <summary>
        /// Phương thức Get
        /// </summary>
        /// <returns></returns>
        ServiceResult Get();
        /// <summary>
        /// Phương thức thêm
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        ServiceResult Insert(T entity);
        /// <summary>
        /// Phương thức Sửa
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        ServiceResult Update(T entity);
        /// <summary>
        /// Phương thức xóa
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        ServiceResult Delete(T entity);
    }
}
