using System;
using System.Collections.Generic;
using System.Text;
using MISA.Service.Entities;

namespace MISA.Service.Interfaces
{
    public interface IBaseReposity<TEntity>
    {   
        /// <summary>
        /// Lấy tất cẩ thực thể
        /// </summary>
        /// <returns>Trả về list các thực thể</returns>
        /// Created By : NHLong (06/02/2021)
        IEnumerable<TEntity> GetEntities();

        /// <summary>
        /// Lấy Thực thể theo Guid
        /// </summary>
        /// <param name="EntityID">Guid của thực thể</param>
        /// <returns>Trả về thực thể nếu có tồn tại</returns>
        /// Created By : NHLong (06/02/2021)
        TEntity GetEntityByID(Guid entityId);
        /// <summary>
        /// Trả về thực thể theo mã của thực thể
        /// </summary>
        /// <param type="string" name="entityCode">Mã Thực thể</param>
        /// <returns>Trả về thực thể tương ứng nếu có tồn tại </returns>
        /// Created By : NHLong (06/02/2021)
        TEntity GetEntityByCode(string entityCode);
        /// <summary>
        /// Thêm Đối tượng vào database
        /// </summary>
        /// <param name="entity">Object Đối tượng</param>
        /// <returns>Số dòng bị ảnh hưởng</returns>
        /// CreatedBy : NHLong (06/02/2021)
        int AddEntity(TEntity entity);

        /// <summary>
        /// Cập nhật đối tượng
        /// </summary>
        /// <param name="entity">Object Đối tượng</param>
        /// <returns>Số dòng bị ảnh hưởng trong Database</returns>
        /// CreatedBy : NHLong (06/02/2021)
        int UpdateEntity(TEntity entity);

        /// <summary>
        /// Xóa đối tượng khỏi database dựa vào Guid
        /// </summary>
        /// <param name="employee">GUID của đối tượng</param>
        /// <returns>Số dòng bị ảnh hưởng trong Database</returns>
        /// CreatedBy : NHLong (06/02/2021)
        int DeleteEntity(List<Guid> entityIdList);
        
    }
}