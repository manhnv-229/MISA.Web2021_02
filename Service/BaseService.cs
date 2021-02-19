using Common;
using MISA.Common;
using MISA.DataLayer;
using MISA.DataLayer.Interfaces;
using MISA.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Service
{
    public class BaseService<TEntity>:IBaseService<TEntity>
    {
        #region DECLARE
        protected IDbContext<TEntity> _dbContext;
        protected IDbContext<Employeee> _dbContext2;
        #endregion

        #region CONTRUCTOR
        public BaseService(IDbContext<TEntity> dbContext)
        {
            _dbContext = dbContext;
        }

        #endregion

        #region Methods
        /// <summary>
        /// Lấy toàn bộ dữ liệu 
        /// </summary>
        /// <returns>toàn bộ dữ liệu</returns>
        /// CreatedBy: TLMinh (03/02/2021)
        public virtual ServiceResult Get()
        {
            var serviceResult = new ServiceResult();
            var tableName = typeof(TEntity).Name;
            serviceResult.Data = _dbContext.GetAll($"Select * from {tableName}");
            return serviceResult;
        }

        /// <summary>
        /// Thêm mới 1 bản ghi
        /// </summary>
        /// <param name="entity">Thực thể cần thêm vào database</param>
        /// <param name="entityCode">Mã thực thể mà chủ thể có khóa ngoại chỉ tới</param>
        /// <returns>Số bản ghi được thêm mới</returns>
        public ServiceResult Post(TEntity entity,string entityCode = null)
        {
            var serviceResult = new ServiceResult();
            ErrorMessenger errorMessenger = new ErrorMessenger();

            //Validate dữ liệu
            if (!Validate(entity, errorMessenger))
            {
                serviceResult.Data = errorMessenger;
                return serviceResult;
            }

            serviceResult.Data = _dbContext.Insert(entity);
            serviceResult.Success = true;

            return serviceResult;
        }

        /// <summary>
        /// Validate dữ liệu
        /// </summary>
        /// <param name="entity">Thực thể cần validate thông tin</param>
        /// <param name="errorMessenger">Tập các thông báo lỗi</param>
        /// <returns></returns>
        public virtual bool Validate(TEntity entity, ErrorMessenger errorMessenger,string entityCode = null)
        {
            return true;
        }

        /// <summary>
        /// Xóa một bản ghi 
        /// </summary>
        /// <param name="entityId">Id của thực thể cần xóa</param>
        /// <returns>Số bản ghi bị xóa</returns>
        /// CreatedBy: TLMinh (07/02/2021)
        public virtual ServiceResult Delete(string entityId,int way = 1)
        {
            var serviceResult = new ServiceResult();
            serviceResult.Data = _dbContext.Delete(entityId);
            return serviceResult;
        }

        /// <summary>
        /// Sửa thông tin thực thể 
        /// </summary>
        /// <param name="entity">Thực thể đã sửa thông tin</param>
        /// <param name="entityCode">Mã của thực thể cần sửa</param>
        /// <returns>Số bản ghi bị chỉnh sửa</returns>
        /// CreatedBy: TLMinh (07/02/2021)
        public virtual ServiceResult Put(TEntity entity, string entityCode = null)
        {
            var serviceResult = new ServiceResult();
            ErrorMessenger errorMessenger = new ErrorMessenger();

            //Validate dữ liệu
            if (!Validate(entity, errorMessenger,entityCode))
            {
                serviceResult.Data = errorMessenger;
                return serviceResult;
            }

            serviceResult.Data = _dbContext.Put(entity);
            serviceResult.Success = true;

            return serviceResult;
        }
        #endregion
    }
}
