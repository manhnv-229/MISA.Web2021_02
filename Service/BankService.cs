using Common;
using MISA.Common;
using MISA.DataLayer.Interfaces;
using MISA.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Service
{
    public class BankService: BaseService<Bank>,IBankService
    {
        #region DECLARE
        
        #endregion

        #region CONTRUCTOR
        public BankService(IBankRepository<Bank> bankRepository,IEmployeeeRepository<Employeee> employeeeRepository) : base(bankRepository)
        {
            _dbContext2 = (IDbContext<Employeee>)employeeeRepository;
        }
        #endregion

        #region METHODS
        /// <summary>
        /// Thêm mới 1 bản ghi
        /// </summary>
        /// <param name="entity">Thực thể cần thêm vào database</param>
        /// <param name="entityCode">Mã thực thể mà chủ thể có khóa ngoại chỉ tới</param>
        /// <returns>Số bản ghi được thêm mới</returns>
        public ServiceResult Post(Bank entity,string entityCode = null)
        {
            var serviceResult = new ServiceResult();
            ErrorMessenger errorMessenger = new ErrorMessenger();

            //Validate dữ liệu
            if (!Validate(entity, errorMessenger))
            {
                serviceResult.Data = errorMessenger;
                return serviceResult;
            }

            if (entityCode != null)
            {
                //set Up khoa ngoai
                object employeees = _dbContext2.GetAll($"Select * from Employeee where EmployeeeCode = '{entityCode}'");
                var employeeesTake = (List<Employeee>) employeees;
                if (employeeesTake.Count != 0)
                {
                    entity.UserId = employeeesTake[0].EmployeeeId;
                }
            }
            serviceResult.Data = _dbContext.Insert(entity);
            serviceResult.Success = true;

            return serviceResult;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="entityId"></param>
        /// <param name="way"></param>
        /// <returns></returns>
        public override ServiceResult Delete(string entityId,int way = 1)
        {
            ServiceResult serviceResult = new ServiceResult();
            serviceResult.Data = _dbContext.Delete(entityId,way);
            return serviceResult;
        }
        #endregion
    }
}
