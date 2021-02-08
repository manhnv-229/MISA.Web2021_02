using MISA.Common.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Common.Interfaces
{
    public interface IBaseService<MISAEntity>
    {
        /// <summary>
        /// Lấy dữ liệu các bản ghi trong database
        /// </summary>
        /// <returns>Trả về danh sách các đối tượng</returns>
        /// CreatedBy: NQDAT (07/02/2021)
        IEnumerable<MISAEntity> Get();

        /// <summary>
        /// Thêm mới một bản ghi vào database
        /// </summary>
        /// <param name="entity">Đối tượng</param>
        /// <returns>Số bản ghi bị ảnh hưởng</returns>
        ServiceResult Insert(MISAEntity entity);

        /// <summary>
        /// Sửa một bản ghi trong database
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>Số bản ghi bị ảnh hưởng</returns>
        /// CreatedBy: NQDAT (07/02/2021)
        ServiceResult Update(MISAEntity entity);

        /// <summary>
        /// Xóa một bản ghi trong database
        /// </summary>
        /// <param name="entity">Đối tượng</param>
        /// <returns>Số bản ghi bị ảnh hưởng</returns>
        /// CreatedBy: NQDAT (07/02/2021)
        ServiceResult Delete(MISAEntity entity);
    }
}
