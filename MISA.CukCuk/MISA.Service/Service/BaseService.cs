using System;
using System.Collections.Generic;
using System.Text;
using MISA.Common.Model;
using MISA.DataLayer;
using MISA.DataLayer.Interfaces;
using MISA.Service.Interfaces;

namespace MISA.Service
{
    public class BaseService<MISAEntity>:IBaseService<MISAEntity>
    {
        #region DECLARE
        IBaseData<MISAEntity> _dbContext;
        #endregion

        #region Constructor
        public BaseService(IBaseData<MISAEntity> dbContext)
        {
            _dbContext = dbContext;
        }
        #endregion

        #region Method
        public virtual ServiceResult GetAll()
        {
            var serviceResult = new ServiceResult();
            var dbContext = new DbContext<MISAEntity>();
            serviceResult.Data = dbContext.GetAll();
            return serviceResult;
        }

        /// <summary>
        /// Hàm kiểm tra nghiệp vụ thêm mới
        /// </summary>
        /// <param name="entity">Kiểu của Object cần thêm</param>
        /// <returns>ServiceResult tương ứng</returns>
        /// CreatedBy: NTANH (08/02/2021)
        public virtual ServiceResult Insert(MISAEntity entity)
        {
            var serviceResult = new ServiceResult();
            var errorMsg = new ErrorMsg();
            var dbContext = new DbContext<MISAEntity>();
            var isValid = ValidateData(entity, errorMsg); 
            // Xử lý nghiệp vụ:

            // Gửi lên DataLayer thực hiện thêm mới vào Database:
            if (isValid == true)
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
        /// Thực hiện validate dữ liệu
        /// </summary>
        /// <param name="entity">Đối tượng cần Validate</param>
        /// <returns>true - hợp lệ; false - không hợp lệ</returns>
        /// CreatedBy: NTANH (08/02/2021)
        protected virtual bool ValidateData(MISAEntity entity, ErrorMsg errorMsg = null)
        {
            return true;
        }
        #endregion
    }
}
