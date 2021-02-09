using MISA.Common.Model;
using MISA.DL;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Service
{
    public class BaseService<MISAEntity>
    {
        /// <summary>
        /// Lấy dữ liệu
        /// </summary>
        /// <returns></returns>
        public ActionServiceResult GetData()
        {
            var actionServiceResult = new ActionServiceResult();
            var dbContext = new DbContext<MISAEntity>();
            actionServiceResult.data = dbContext.GetAll();
            return actionServiceResult;
        }

        /// <summary>
        /// Thêm mới dữ liệu
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public virtual ActionServiceResult Insert(MISAEntity entity)
        {
            var actionServiceResult = new ActionServiceResult();
            var dbContext = new DbContext<MISAEntity>();
            var isValid = true;
            //Xử lý nghiệp vụ
            isValid = ValidateData(entity);
            //Gửi lên DL thực hiện thêm mới vào db:
            if (isValid == true)
            {
            actionServiceResult.data = dbContext.InsertObject(entity);

            }
            else
            {
                actionServiceResult.Success = false;
                actionServiceResult.MISACode = MISA.Common.Model.Enumarations.MISACode.Validate;
            }
            return actionServiceResult;
        }

        /// <summary>
        /// Sửa object
        /// </summary>
        /// <param name="id">id object cần sửa</param>
        /// <param name="entity">đối tượng sửa</param>
        /// <returns></returns>
        public virtual ActionServiceResult Update(Guid id, MISAEntity entity)
        {
            var actionServiceResult = new ActionServiceResult();
            var dbContext = new DbContext<MISAEntity>();
            var isValid = true;
            //Xử lý nghiệp vụ
            isValid = ValidateData(entity);
            //Gửi lên DL thực hiện thêm mới vào db:
            if (isValid == true)
            {
                actionServiceResult.data = dbContext.UpdateObject(id, entity);

            }
            else
            {
                actionServiceResult.Success = false;
                actionServiceResult.MISACode = MISA.Common.Model.Enumarations.MISACode.Validate;
            }
            return actionServiceResult;
        }

        public virtual ActionServiceResult Delete(Guid id)
        {
            var actionServiceResult = new ActionServiceResult();
            var dbContext = new DbContext<MISAEntity>();
            actionServiceResult.data = dbContext.DeleteObject(id);

            return actionServiceResult;
        }
        /// <summary>
        /// Thực hiện validate dữ liệu
        /// </summary>
        /// <param name="entity">đối tượng cần validate</param>
        /// <returns>true: hợp lệ, false: ko hợp lệ</returns>
        /// CreatedBy: dvcuong (07/02/2021)
        private bool ValidateData(MISAEntity entity)
        {
            return true;
        }

    }
}
