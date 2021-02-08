using Microsoft.EntityFrameworkCore;
using MISA.ApplicationCore.interfaces;
using MISA.ApplicationCore.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.ApplicationCore
{
    public class BaseService: IBaseService
    {
        IDbContext _dbContext;

        public BaseService()
        {
        }

        public BaseService(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// Hàm chung lấy toàn bộ dữ liệu
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns>Toàn bộ dữ liệu</returns>
        public virtual ServiceResult GetData<T>()
        {
            var serviceResult = new ServiceResult();
            serviceResult.Data = _dbContext.GetAll<T>();
            return serviceResult;
        }

        public ServiceResult Insert<T>(T entity)
        {
            var errorMsg = new ErrorMsg();
            var serviceResult = new ServiceResult();
            var isValid = true;
            var className = typeof(T).Name;
            //validate
            isValid = ValidateData(entity, errorMsg);
            if (isValid == false)
            {
                serviceResult.Success = false;
                serviceResult.Data = errorMsg;
                return serviceResult;
            }
            else
            {
                errorMsg.devMsg.Add(MISA.ApplicationCore.Properties.Resources.ErrorMsg_AddEmployeeSuccess_dev);
                errorMsg.userMsg.Add(MISA.ApplicationCore.Properties.Resources.ErrorMsg_AddEmployeeSuccess_user);
                serviceResult.Success = true;
                serviceResult.Data = _dbContext.InsertData<T>($"Proc_Insert{className}", entity, commandType: System.Data.CommandType.StoredProcedure);
                return serviceResult;
            }
        }

        public virtual bool ValidateData<T>(T entity, ErrorMsg errorMsg = null)
        {
            return true;
        }
    }
}
