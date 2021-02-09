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
        /// CreatedBy: NTTHIEM
        /// CreatedDate: 08/02/2021
        ServiceResult GetData();

        /// <summary>
        /// Thêm mới dữ liệu
        /// </summary>
        /// <param name="entity">Đối tượng cần thêm vào</param>
        /// <returns>true/false</returns>
        ServiceResult Insert(MISAEntity entity);
    }
}
