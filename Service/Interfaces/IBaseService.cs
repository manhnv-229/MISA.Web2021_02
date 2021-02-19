using Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Service.Interfaces
{
    public interface IBaseService<TEntity>
    {
        /// <summary>
        /// Lấy toàn bộ dữ liệu
        /// </summary>
        /// <returns>Toàn bộ dữ liệu</returns>
        /// CreatedBy: TLMinh (07/02/2021)
        public ServiceResult Get();

        /// <summary>
        /// Thêm một bản ghi 
        /// </summary>
        /// <param name="entity">Thực thể cần thêm</param>
        /// <param name="entityCode">Mã thực thể mà chủ thể có khóa ngoại chỉ tới</param>
        /// <returns>Số bản ghi được thêm</returns>
        /// CreatedBy: TLMinh (07/02/2021)
        public ServiceResult Post(TEntity entity,string entityCode = null);

        /// <summary>
        /// Xóa một bản ghi 
        /// </summary>
        /// <param name="entityId">Id của thực thể cần xóa</param>
        /// <param name="way">1 xóa theo id chính, 2 xóa theo id ngoại</param>
        /// <returns>Số bản ghi được xóa</returns>\
        /// CreatedBy: TLMinh (07/02/2021)
        public ServiceResult Delete(string entityId,int way = 1);

        /// <summary>
        /// Sửa thông tin bản ghi
        /// </summary>
        /// <param name="entity">Thực thể đã sửa thông tin</param>
        /// <param name="entityCode">Mã thực thể(nếu có, là trường thông tin khác Id, vd: employeeCode)</param>
        /// <returns>Số bản ghi được sửa</returns>
        /// CreatedBy: TLMinh (07/02/2021)
        public ServiceResult Put(TEntity entity, string entityCode = null);

    }
}

