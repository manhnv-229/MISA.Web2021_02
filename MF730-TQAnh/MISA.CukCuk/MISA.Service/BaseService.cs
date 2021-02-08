using MISA.Common.Model;
using MISA.DataLayer;
using MISA.DataLayer.Interfaces;
using MISA.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Service
{
    /// <summary>
    /// base chung cho service
    /// </summary>
    /// <typeparam name="Entity"> loại đối tượng thêm vào  </typeparam>
    /// CreatedBy: TQAnh ( 08/02/2021)
    public class BaseService<Entity> : IBaseService<Entity>
    {

        #region DECLARE
        // khai báo các thuộc tính
        protected ServiceResult serviceResult;
        protected IDbContext<Entity> _dbContext;
        #endregion

        #region Constructor

        /// <summary>
        /// hàm khởi tạo 
        /// </summary>
        /// <param name="dbContext"> một interface của IDbContext<Entity> </param>
        /// CreatedBy: TQAnh ( 08/02/2021)
        public BaseService(IDbContext<Entity> dbContext)
        {
            serviceResult = new ServiceResult();
            _dbContext = dbContext;
        }



        #endregion

        #region Method

        /// <summary>
        /// lấy danh sách 
        /// </summary>
        /// <returns> trả về một ServiceResult  </returns>
        ///  CreatedBy: TQAnh ( 08/02/2021)
        public ServiceResult GetData()
        {

            serviceResult.Data = _dbContext.GetAll();
            return serviceResult;
        }

        /// <summary>
        /// thêm mới đối tượng
        /// </summary>
        /// <param name="entity">đối tượng cần thêm mới </param>
        /// <returns> trả về một ServiceResult  </returns>
        ///  CreatedBy: TQAnh ( 08/02/2021)
        public ServiceResult Insert(Entity entity)
        {

            var erroMsg = new ErroMsg();
            var isValid = ValidateData(entity, erroMsg);
            if (isValid == true)
            {
                serviceResult.Data = _dbContext.Insert(entity);
            }
            else
            {
                serviceResult.Success = false;
                serviceResult.Data = erroMsg;

            }
            return serviceResult;
        }

        /// <summary>
        /// chỉnh sửa đối tượng 
        /// </summary>
        /// <param name="id"> khóa chính đối tượng cần thay đổi</param>
        /// <param name="entity">đối tượng cần thay đổi </param>
        /// <returns> trả về một ServiceResult  </returns>
        ///  CreatedBy: TQAnh ( 08/02/2021)
        public ServiceResult Delete(Guid id)
        {


            serviceResult.Data = _dbContext.Delete(id);

            return serviceResult;
        }

        /// <summary>
        /// xóa đối tượng
        /// </summary>
        /// <param name="id">khóa chính đối tượng cần xóa</param>
        /// <returns> trả về một ServiceResult  </returns>
        ///  CreatedBy: TQAnh ( 08/02/2021)
        public ServiceResult Update(Guid id, Entity entity)
        {
            serviceResult.Data = _dbContext.Update(id,entity);

            return serviceResult;
        }


        protected virtual bool ValidateData(Entity entity, ErroMsg erroMsg)
        { return true; }

      
        #endregion


    }
}
