using System;
using System.Collections.Generic;
using System.Text;
using MISA.Service.Entities;

namespace MISA.Service.Interfaces
{
    public interface IBaseService<TEntity>
    {
        /// <summary>
        /// Service thực hiện lấy danh sách đối tượng
        /// </summary>
        /// <returns>Kết quả của Service ( success, data .. )</returns>    
        /// CreatedBy: NHLong (07/02/2021)
        ServiceResult GetEntities();

        /// <summary>
        /// Service thực hiện lấy Đối tượng dựa vào Guid 
        /// </summary>
        /// <param name="entityId">Guid của đối tượng</param>
        /// <returns>Kêt quả Service ( success, data)</returns>
        /// CreatedBy : NHLong (07/02/2021)
        ServiceResult GetEntityByID(Guid entityId);
        /// <summary>
        /// Service thực hiện lấy Đối tượng dựa vào code
        /// </summary>
        /// <param name="entityCode">String dãy code</param>
        /// <returns>Kết quả của Service (success, data)</returns>
        /// CreatedBy: NHLong (07/02/2021)
        ServiceResult GetEntityByCode(string entityCode);

        /// <summary>
        /// Service thực hiện thêm đối tượng
        /// </summary>
        /// <param name="entity">Đối tượng cần thêm</param>
        /// <returns>Kết quả của Service ( success, data - số dòng bị ảnh hưởng trong db) </returns>
        /// CreatedBy: NHLong ( 07/02/2021)
        ServiceResult AddEntity(TEntity entity);

        /// <summary>
        /// Service thực hiện cập nhật đối tượng
        /// </summary>
        /// <param name="entity">Object đối tượng cần sửa</param>
        /// <returns>Kết quả của Service ( success, data - số dòng bị ảnh hưởng trong db )</returns>
        /// CreatedBy : NHLong (07/02/2021)
        ServiceResult UpdateEntity(TEntity entity);

        /// <summary>
        /// Service thực hiện xóa các đối tượng dựa trên danh sách Guid
        /// </summary>
        /// <param name="entityId">Danh sách Guid của các đối tượng cần xóa</param>
        /// <returns>Kết quả của Service (success, data - số dòng bị ảnh hưởng )</returns>
        ServiceResult DeleteEntity(List<Guid> entityId);

    }
}