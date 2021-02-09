using MISA.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Service.Interfaces
{
    public interface IBaseService<MISAEntity>
    {
        /// <summary>
        /// Lấy dữ liệu của thực thể truyền vào
        /// </summary>
        /// <returns>Và mã lỗi Http và Toàn bộ dữ liệu lấy được</returns>
        /// CreatedBy: PNTHANG (08/02/2021)
        ServiceResult GetData();

        /// <summary>
        /// Thêm mới dữ liệu
        /// </summary>
        /// <param name="entity">Đối tượng cần thêm vào</param>
        /// <returns>true - thành công, false - thất bại và số bản ghi</returns>
        ServiceResult Insert(MISAEntity entity);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        ServiceResult Update(MISAEntity entity);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        ServiceResult Delete(Guid id);
    }
}
