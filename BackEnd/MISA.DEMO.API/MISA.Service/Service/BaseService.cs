
using MISA.Common;
using MISA.Common.Models;
using MISA.DataLayer;
using MISA.DataLayer.Interface;
using MISA.Service.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Service
{
    public class BaseService<MISAEntity> : IBaseService<MISAEntity>
    {
        #region Declare
        IDbContext<MISAEntity> _dbContext;
        #endregion

        #region Contructor
        public BaseService(IDbContext<MISAEntity> dbContext)
        {
            _dbContext = dbContext;
        }
        #endregion

        #region Method
        public virtual ServiceResult GetData(object param = null)
        {
            var serviceResult = new ServiceResult();
            serviceResult.Data = _dbContext.GetData(null, param);
            return serviceResult;
        }
        
        /// <summary>
        /// Thêm mới dữ liệu
        /// </summary>
        /// <param name="entity">Đối tượng cần thêm mới</param>
        /// <returns></returns>
        /// CreatedBy PVTRONG (7/2/2021)
        public virtual ServiceResult Insert(MISAEntity entity)
        {
            var serviceResult = new ServiceResult();
            var error = new ErrorMsg();
            var isValid = ValidateData(entity, error);
            
            // Xử lý nghiệp vụ: 
            if (isValid == true)
            {

                // Thêm mới khi dữ liệu đã hợp lệ
                // Gửi lên DataLayer thực hiện cất dữ liệu:
                var rowAffects = _dbContext.InsertObject(entity);

                serviceResult.MISACode = MISACode.Success;
                serviceResult.Msg = "Thêm thành công";
                serviceResult.Data = rowAffects;
                serviceResult.Success = true;
                return serviceResult;
            }
            // Xử lý các kiểu dữ liệu: 
            else
            {
                serviceResult.Success = false;
                serviceResult.Data = error;
            }
            return serviceResult;

            
        }

        /// <summary>
        /// Thực hiện Validate dữ liệu
        /// </summary>
        /// <param name="entity">Đối tượng cần validate</param>
        /// <returns>true: dữ liệu hợp lệ, false: không hợp lệ</returns>
        /// CreatedBy PVTRONG (7/2/2021)
        protected virtual  bool ValidateData(MISAEntity entity, ErrorMsg errorMsg = null)
        {
            return true;
        }

        public virtual ServiceResult Update(MISAEntity entity)
        {
            var serviceResult = new ServiceResult();
            var error = new ErrorMsg();
            var isValid = ValidateData(entity, error);
            // Xử lý nghiệp vụ: 
            if (isValid == true)
            {

                // Chỉnh sửa khi dữ liệu đã hợp lệ
                // Gửi lên DataLayer thực hiện cất dữ liệu:
                var rowAffects = _dbContext.UpdateObject(entity);

                serviceResult.MISACode = MISACode.Success;
                serviceResult.Msg = "Sửa thành công";
                serviceResult.Data = rowAffects;
                serviceResult.Success = true;
                return serviceResult;
            }
            // Xử lý các kiểu dữ liệu: 
            else
            {
                serviceResult.Success = false;
                serviceResult.Data = error;
            }
            return serviceResult;

        }
        #endregion
    }
}
