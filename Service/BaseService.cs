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
        /// <returns>toàn bộ dữ liệu(ServiceResutl.Data)</returns>
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
        /// <returns>Số bản ghi được thêm mới(ServiceResutl.Data)</returns>
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
        /// <param name="entityCode">Mã thực thể có thông tin cần validate(nếu có)</param>
        /// <param name="identidy">số chứng minh thư nhân dân(nếu thực thể là nhân viên)</param>
        /// <returns>true: nếu dữ liệu hợp lệ; false: nếu dữ liệu không hợp lệ</returns>
        /// CreatedBy: TLMinh(20/02/2021)
        public virtual bool Validate(TEntity entity, ErrorMessenger errorMessenger,string entityCode = null,string identidy = null)
        {
            return true;
        }

        /// <summary>
        /// Xóa một bản ghi 
        /// </summary>
        /// <param name="entityId">Id của thực thể cần xóa</param>
        /// <returns>Số bản ghi bị xóa(ServiceResutl.Data)</returns>
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
        /// <param name="identidy">số chứng minh thư nhân dân(nếu thực thể là nhân viên)</param>
        /// <returns>Số bản ghi bị chỉnh sửa(ServiceResutl.Data)</returns>
        /// CreatedBy: TLMinh (07/02/2021)
        public virtual ServiceResult Put(TEntity entity, string entityCode = null,string identidy = null)
        {
            var serviceResult = new ServiceResult();
            ErrorMessenger errorMessenger = new ErrorMessenger();

            //Validate dữ liệu
            if (!Validate(entity, errorMessenger,entityCode,identidy))
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
