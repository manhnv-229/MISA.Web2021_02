using MISA.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;
using MISA.DataLayer;
using MISA.Service.Interfaces;

namespace MISA.Service
{
    public class BaseService<MISAEntity>
    {
        /// <summary>
        /// Lấy dữ liệu
        /// </summary>
        /// <returns> Kết quả lấy dữ liệu: thành công, dữ liệu lấy được</returns>
        /// CreatedBy: PNTHANG (08/02/2021)
        public virtual ServiceResult GetData()
        {
            var serviceResult = new ServiceResult();
            var dbContext = new DbContext<MISAEntity>();
            serviceResult.Data = dbContext.GetAll();
            return serviceResult;
        }

        /// <summary>
        /// Thêm mới dữ liệu
        /// </summary>
        /// <param name="entity">đối tượng cần thêm vào database</param>
        /// <returns>Success = true - thành công, Success = false - không thành công và dữ liệu</returns>
        /// CreatedBy: PNTHANG (08/02/2021)
        public virtual ServiceResult Insert(MISAEntity entity)
        {
            var errorMsg = new ErrorMsg();
            var dbContext = new DbContext<MISAEntity>();
            var serviceResult = new ServiceResult();
            var isValidate = ValidateData(entity,errorMsg);
            // Xử lí nghiệp vụ:

            // Gửi lên DataLayer thực hiện thêm mới:
            if (isValidate == true)
            {
                var res = dbContext.InsertObject(entity);
                if (res > 0)
                {
                    serviceResult.Success = true;
                    serviceResult.Data = res;
                    return serviceResult;
                }
                else
                {
                    serviceResult.Success = true;
                    serviceResult.Data = res;
                    return serviceResult;
                }
            }
            else
            {
                serviceResult.Success = false;
                serviceResult.Data = errorMsg;
            }
            return serviceResult; 
        }
        /// <summary>
        /// Thực hiện validate
        /// </summary>
        /// <param name="entity">đối tượng cần validate</param>
        /// <returns>true - hợp lệ; false - không hợp lệ</returns>
        /// CreatedBy: PNTHANG (08/02/2021)
        protected virtual bool ValidateData(MISAEntity entity, ErrorMsg errorMsg = null)
        {
            return true;
        }
    }
}
