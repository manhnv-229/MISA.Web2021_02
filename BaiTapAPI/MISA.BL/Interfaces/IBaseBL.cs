using MISA.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.BL.Interfaces
{
        public interface IBaseBL<T>
        {
            /// <summary>
            /// Lấy tất cả dữ liệu
            /// </summary>
            /// <returns>ServiceResult</returns>
            ServiceResult GetAllData();

            /// <summary>
            /// Thêm mới bản ghi
            /// </summary>
            /// <param name="entity"></param>
            /// <returns>ServiceResult</returns>
            ServiceResult Insert(T entity);

            /// <summary>
            /// Cập nhật bản ghi
            /// </summary>
            /// <param name="entity"></param>
            /// <returns>ServiceResult</returns>
            ServiceResult Update(T entity);

            /// <summary>
            /// Xóa bản ghi
            /// </summary>
            /// <param name="id"></param>
            /// <returns>ServiceResult</returns>
            ServiceResult Delete(string id);
        }
    
}
