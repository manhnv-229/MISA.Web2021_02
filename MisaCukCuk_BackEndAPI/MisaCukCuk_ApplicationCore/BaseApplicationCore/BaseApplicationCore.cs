using MisaCukCuk_Entity.Common;
using MisaCukCuk_Infarstructure;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MisaCukCuk_ApplicationCore.BaseApplicationCore
{
    public class BaseApplicationCore<T> : IBaseApplicationCore<T>
    {
        IMisaCukCukContext<T> _db;
        public BaseApplicationCore(IMisaCukCukContext<T> misaCukCukContext)
        {
            _db = misaCukCukContext;
        }
        /// <summary>
        /// Lấy tất cả danh sách
        /// CreateBy: MinhHq(08/02/2021)
        /// </summary>
        /// <returns>object</returns>
        public virtual async Task<ServiceResult> GetData()
        {
            var service = new ServiceResult();
            service.Data = await _db.GetAllData();
            return service;
        }
        /// <summary>
        /// Xóa danh sách
        /// CreateBy: MinhHq(08/02/2021)
        /// </summary>
        /// <param name="code"></param>
        /// <returns>object</returns>
        public virtual async Task<ServiceResult> DeleteData(Guid code)
        {
            var service = new ServiceResult();
            service.Data = await _db.DeleteById(code);
            return service;
        }
        /// <summary>
        /// Lấy danh sách theo id
        /// CreateBy: MinhHq(08/02/2021)
        /// </summary>
        /// <param name="code"></param>
        /// <returns>object</returns>
        public virtual async Task<ServiceResult> GetById(Guid code)
        {
            var service = new ServiceResult();
            service.Data = await _db.GetByID(code);
            return service;
        }
        /// <summary>
        /// Thêm mới danh sách
        /// CreateBy: MinhHq(08/02/2021)
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>object</returns>
        public virtual async Task<ServiceResult> Insert(T entity)
        {
            var service = new ServiceResult();
            var errorMsg = new ErrorMsg();

            #region Validate dữ liệu
            var isValid = await ValidateDataInsert(entity, errorMsg);

            if (isValid == true)
            {
                var rs = await _db.Insert(entity);
                if (rs > 0)
                {
                    service.Success = true;
                    service.Data = MisaCukCuk_Entity.Properties.Resources.AddSuccess;
                    return service;
                }
                else
                {
                    service.Success = true;
                    service.Data = rs;
                    return service;
                }
            }
            else
            {
                service.Success = false;
                service.Data = errorMsg;
            }
            #endregion

            return service;
        }

        /// <summary>
        /// Sửa thông tin bản ghi
        /// CreateBy: MinhHq(08/02/2021)
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>object</returns>
        public virtual async Task<ServiceResult> Update(T entity)
        {
            var service = new ServiceResult();
            var errorMsg = new ErrorMsg();

            #region Validate dữ liệu
            var isValid = await ValidateDataUpdate(entity, errorMsg);
            if (isValid == true)
            {
                var rs = await _db.Update(entity);
                if (rs > 0)
                {
                    service.Success = true;
                    service.Data = MisaCukCuk_Entity.Properties.Resources.UpdateSuccess;
                    return service;
                }
                else
                {
                    service.Success = true;
                    service.Data = rs;
                    return service;
                }
            }
            else
            {
                service.Success = false;
                service.Data = errorMsg;
            }
            #endregion

            return service;
        }

        /// <summary>
        /// Validate mã và số điện thoại khi thêm mới
        /// CreateBy: MinhHq(08/02/2021)
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="errorMsg"></param>
        /// <returns>true: không trùng; false: trùng số điện thoại hoặc mã</returns>
        protected virtual async Task<bool> ValidateDataInsert(T entity, ErrorMsg errorMsg = null)
        {
            return true;
        }

        /// <summary>
        /// Validate mã
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="errorMsg"></param>
        /// <returns>true: không trùng; false: trùng số điện thoại hoặc mã</returns>
        protected virtual async Task<bool> ValidateDataUpdate(T entity, ErrorMsg errorMsg = null)
        {
            return true;
        }

    }
}
