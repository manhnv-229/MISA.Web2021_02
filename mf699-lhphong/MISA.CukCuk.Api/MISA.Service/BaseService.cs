using System;
using System.Collections.Generic;
using System.Text;
using MISA.Common.Model;
using MISA.DATALayer;
using MISA.DATALayer.Interface;
using MISA.Service.Interface;

namespace MISA.Service
{
    public class BaseService<MisaEntity>: IBaseService<MisaEntity>
    {
        IDbContext<MisaEntity> _dbContext;
        public BaseService(IDbContext<MisaEntity> dbContext)
        {
            _dbContext = dbContext;
        }
        /// <summary>
        /// Base service lấy Data
        /// </summary>
        /// <returns>kết quả cho controller xử lý</returns>
        /// CreatedBy: LHPHONG (8/2/2021)
        public virtual ServiceResult GetData()
        {
            var serviceResult = new ServiceResult();
            serviceResult.Data = _dbContext.GetAll();
            return serviceResult;
        }  

        /// <summary>
        /// Base service thêm data
        /// </summary>
        /// <param name="entity">đối tượng cần thêm</param>
        /// <returns>kết quả cho controller xử lý</returns>
        /// CreatedBy: LHPHONG (8/2/2021)
        public virtual ServiceResult Insert(MisaEntity entity)
        {
            var serviceResult = new ServiceResult();
            var errorMsg = new ErrorMsg();
            var isValid = validateData(entity, errorMsg);

            
            //Gửi lên DB thực hiện thêm mới
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
                    serviceResult.Success = true;
                serviceResult.Data = res;
                return serviceResult;
            }
            else
            {
                serviceResult.Success = false;
                serviceResult.Data = errorMsg;
            }
            return serviceResult;
        }

        /// <summary>
        /// thực hiện validate dữ liệu
        /// </summary>
        /// <param name="entity">đối tượng validate</param>
        /// trả về true - hợp lệ, false - ko hợp lệ
        /// CreatedBy: LHPHONG (8/2/2021)
        protected virtual bool validateData(MisaEntity entity, ErrorMsg errorMsg = null)
        {
            return true;
        }
    }
}
