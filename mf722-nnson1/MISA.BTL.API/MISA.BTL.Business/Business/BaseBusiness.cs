using System;
using System.Collections.Generic;
using System.Text;
using Dapper;
using MISA.BTL.Business.Interfaces;
using MISA.BTL.Common;
using MISA.BTL.Database;
using MISA.BTL.Database.Interfaces;

namespace MISA.BTL.Business
{
    public class BaseBusiness<T>:IBaseBusiness<T>
    {
        IDbConnector<T> _dbConnector;

        /// <summary>
        /// Hàm khởi tạo
        /// </summary>
        /// <param name="dbConnector"></param>
        /// CreatdBy: NNSON (08/02/2021)
        public BaseBusiness(IDbConnector<T> dbConnector)
        {
            _dbConnector = dbConnector;
        }

        /// <summary>
        /// Lấy toàn bộ dữ liệu
        /// </summary>
        /// <returns></returns>
        /// CreatdBy: NNSON (08/02/2021)
        public virtual ServiceResult GetData()
        {
            var serviceResult = new ServiceResult();

            serviceResult.Data = _dbConnector.GetData();
            serviceResult.Success = true;

            return serviceResult;
        }

        /// <summary>
        /// Thêm dữ liệu
        /// </summary>
        /// <param name="entity">object cần thêm mới</param>
        /// <returns></returns>
        /// CreatdBy: NNSON (08/02/2021)
        public virtual ServiceResult Insert(T entity)
        {
            var serviceResult = new ServiceResult();
            var errorMsg = new ErrorMsg();

            var isValid = ValidateData(entity, errorMsg);

            if (isValid == true)
            {
                serviceResult.Success = true;
                serviceResult.Data = _dbConnector.Insert(entity);
                return serviceResult;
            }
            else
            {
                serviceResult.Success = false;
                serviceResult.Data = errorMsg;
                return serviceResult;
            }
        }

        /// <summary>
        /// Sửa thông tin dữ liệu
        /// </summary>
        /// <param name="entity">object đã sửa</param>
        /// <returns></returns>
        /// CreatdBy: NNSON (08/02/2021)
        public virtual ServiceResult Update(T entity)
        {
            var serviceResult = new ServiceResult();
            var errorMsg = new ErrorMsg();

            var isValid = ValidateData(entity, errorMsg);

            if (isValid == true)
            {
                serviceResult.Success = true;
                serviceResult.Data = _dbConnector.Update(entity);
                return serviceResult;
            }
            else
            {
                serviceResult.Success = false;
                serviceResult.Data = errorMsg;
                return serviceResult;
            }
        }

        /// <summary>
        /// Xóa dữ liệu
        /// </summary>
        /// <param name="id">id của object cần xóa</param>
        /// <returns></returns>
        /// CreatdBy: NNSON (08/02/2021)
        public virtual ServiceResult Delete(string id)
        {
            var serviceResult = new ServiceResult();
            serviceResult.Data = _dbConnector.Delete(id);
            serviceResult.Success = true;
            return serviceResult;
        }

        /// <summary>
        /// Xác thực dữ liệu
        /// </summary>
        /// <param name="entity">object cần kiểm tra</param>
        /// <param name="errorMsg">thông tin lỗi nếu có</param>
        /// <returns></returns>
        /// CreatdBy: NNSON (08/02/2021)
        protected virtual bool ValidateData(T entity, ErrorMsg errorMsg = null)
        {
            return true;
        }
    }
}
