using System;
using System.Collections.Generic;
using System.Text;
using MISA.BTL.Business.Interfaces;
using MISA.BTL.Common;
using MISA.BTL.Database;
using MISA.BTL.Database.Interfaces;

namespace MISA.BTL.Business
{
    public class CustomerGroupBusiness : BaseBusiness<CustomerGroup>, ICustomerGroupBusiness
    {
        IDbConnector<CustomerGroup> _dbConnector;
        public CustomerGroupBusiness(IDbConnector<CustomerGroup> dbConnector):base(dbConnector)
        {
            _dbConnector = dbConnector;
        }

        /*public ServiceResult GetDataById(string id)
        {
            var serviceResult = new ServiceResult();
            var errorMsg = new ErrorMsg();
            if (customerGroupRepository.CheckCustomerGroupIdExist(id) == false)
            {
                errorMsg.UserMsg.Add(Properties.Resources.Erro_Group_Not_Exist);
                serviceResult.Data = errorMsg;
                serviceResult.Success = false;
            }
            else
            {
                serviceResult.Data = customerGroupRepository.GetData($"Proc_GetCustomerGroupById", new { CustomerGroupId = id }, System.Data.CommandType.StoredProcedure);
                serviceResult.Success = true;
            }
            return serviceResult;
        }*/

        /// <summary>
        /// Xác thực dữ liệu nhóm khách hàng
        /// </summary>
        /// <param name="customerGroup">object nhóm khách hàng cần kiểm tra</param>
        /// <param name="errorMsg">thông tin lỗi nếu có</param>
        /// <returns>true: dữ liệu xác thực đúng; false: dữ liệu xác thực sai</returns>
        /// CreatdBy: NNSON (08/02/2021)
        protected override bool ValidateData(CustomerGroup customerGroup, ErrorMsg errorMsg = null)
        {
            var isValid = true;
            // 1. check tên nhóm khách hàng để trống: 
            if (_dbConnector.CheckEmptyCustomerGroupName(customerGroup.CustomerGroupName) == true)
            {
                errorMsg.UserMsg.Add(MISA.BTL.Common.Properties.Resources.Erro_Required_CustomerGroupName);
                isValid = false;
            }
            // 2. check trùng tên nhóm khách hàng:
            if (_dbConnector.CheckCustomerGroupNameExist(customerGroup.CustomerGroupName) == true)
            {
                errorMsg.UserMsg.Add(MISA.BTL.Common.Properties.Resources.Erro_Duplicate_CustomerGroupName);
                isValid = false;
            }

            return isValid;

        }
    }
}
