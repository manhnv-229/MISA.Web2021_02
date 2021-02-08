using MisaCukCuk_Entity.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MisaCukCuk_ApplicationCore.BaseApplicationCore
{
    public interface IBaseApplicationCore<T>
    {
        #region
        /// <summary>
        /// Lấy tất cả các danh sách
        /// CreateBy: MinhHq(08/02/2021)
        /// </summary>
        /// <returns>object</returns>
        Task<ServiceResult> GetData();
        /// <summary>
        /// Lấy danh sách theo id
        /// CreateBy: MinhHq(08/02/2021)
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        Task<ServiceResult> GetById(Guid code);
        /// <summary>
        /// Xóa danh sách
        /// CreateBy: MinhHq(08/02/2021)
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        Task<ServiceResult> DeleteData(Guid code);
        /// <summary>
        /// Thêm mới danh sách
        /// CreateBy: MinhHq(08/02/2021)
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<ServiceResult> Insert(T entity);
        /// <summary>
        /// Sửa thông tin bản ghi
        /// CreateBy: MinhHq(08/02/2021)
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<ServiceResult> Update(T entity);
        #endregion

    }
}
