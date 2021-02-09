using MISA.Common.Model;
using MISA.DataLayer;
using MISA.DataLayer.Interfaces;
using MISA.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Service
{
    public class BaseService<MISAEntity>:IBaseService<MISAEntity>
    {
        protected IBaseData<MISAEntity> _dbContext;
        /// <summary>
        /// Khởi tạo đường dẫn đến dataLayer
        /// </summary>
        /// <param name="dbContext"></param>
        public BaseService(IBaseData<MISAEntity> dbContext)
        {
            _dbContext = dbContext;
        }
        public virtual ServiceResult GetData()
        {
            var serviceResult = new ServiceResult();
            serviceResult.Data = _dbContext.GetAll();
            return serviceResult;
        }
        /// <summary>
        /// THêm mới dữ liệu
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>Trả về kết quả ServiceResult</returns>
        public virtual ServiceResult Insert(MISAEntity entity)
        {
            var serviceResult = new ServiceResult();
            var errorMsg = new ErrorMsg(); 
            //Xử lý nghiệp vụ
            var isValid = ValidateData(entity, errorMsg);
            //Gửi lên dataLayer thêm mới vào database
            if (isValid == true)
            {
                var res = _dbContext.InsertObject(entity);
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
        /// Validate dữ liệu
        /// </summary>
        /// <param name="entity">Đối tượng cần validate</param>
        /// <returns>true: dữ liệu hợp lệ, false: dữ liệu k hợp lệ</returns>
        protected virtual bool ValidateData(MISAEntity entity, ErrorMsg errorMsg = null)
        {
            return true;
        }
    }
}
