using MISA.BL.Interfaces;
using MISA.Common;
using MISA.DAO.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.BL
{
    public class BaseBL<T> : IBaseBL<T>
    {
        IDbConnector<T> _dbConnector;
        protected ServiceResult _serviceResult;

        #region constructor
        public BaseBL(IDbConnector<T> dbConnector)
        {
            _serviceResult = new ServiceResult();
            _dbConnector = dbConnector;
        }
        #endregion

        #region Delete
        /// <summary>
        /// Xoá bản ghi
        /// </summary>
        /// <param name="id"></param>
        /// <returns>ServiceResult</returns>
        /// CreatedBy: NDLuu (8/2/2021)
        public virtual ServiceResult Delete(string id)
        {
            _serviceResult.Data = _dbConnector.Delete(id);
            if ((int)_serviceResult.Data > 0)
                _serviceResult.Success = true;
            else
                _serviceResult.Success = false;

            return _serviceResult;
        }
        #endregion


        /// <summary>
        /// Lấy tất cả dữ liệu
        /// </summary>
        /// <returns></returns>
        /// CreatedBy: NDLuu (8/2/2021)
        public virtual ServiceResult GetAllData()
        {
            _serviceResult.Success = true;
            _serviceResult.Data = _dbConnector.GetAllData();

            return _serviceResult;
        }


        /// <summary>
        /// Thêm mới bản ghi
        /// </summary>
        /// <param name="entity">Bản ghi cần xoá</param>
        /// <returns></returns>
        /// CreatedBy: NDLuu (8/2/2021)
        public virtual ServiceResult Insert(T entity)
        {
            // Khởi tạo object thông báo lỗi
            var errMsg = new ErrorMsg();
            // Xử lý nghiệp vụ
            var isValidated = ValidateInsertData(entity, errMsg);
            // Kiểm tra và gửi lên tầng DataLayer thực hiện thêm mới vào cơ sở dữ liệu
            if (isValidated)
            {
                _serviceResult.Success = true;
                _serviceResult.Data = _dbConnector.Insert(entity);
            }
            else
            {
                _serviceResult.Success = false;
                _serviceResult.Data = errMsg;
            }

            return _serviceResult;
        }

        /// <summary>
        /// Cập nhật bản ghi
        /// </summary>
        /// <param name="entity">Bản ghi cần cập nhật</param>
        /// <returns></returns>
        /// CreatedBy: NDLuu (8/2/2021)
        public virtual ServiceResult Update(T entity)
        {
            var errMsg = new ErrorMsg();
            var isValidated = ValidateUpdateData(entity, errMsg);
            if (isValidated)
            {
                _serviceResult.Success = true;
                _serviceResult.Data = _dbConnector.Update(entity);
            }
            else
            {
                _serviceResult.Success = false;
                _serviceResult.Data = errMsg;
            }

            return _serviceResult;
        }


        /// <summary>
        /// Xử lý nghiệp vụ các thông tin nhập vào khi thêm
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="errMsg"></param>
        /// <returns></returns>
        /// CreatedBy: NDLuu (8/2/2021)
        protected virtual bool ValidateInsertData(T entity, ErrorMsg errMsg)
        {
            return true;
        }


        /// <summary>
        /// Xử lý nghiệp vụ các thông tin nhập vào khi cập nhật
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="errMsg"></param>
        /// <returns></returns>
        /// CreatedBy: NDLuu (8/2/2021)
        protected virtual bool ValidateUpdateData(T entity, ErrorMsg errMsg)
        {
            return true;
        }
    }
}
