using MISA.BL.Interfaces;
using MISA.Common;
using MISA.Common.Entities;
using MISA.Common.Properties;
using MISA.CukCuk.Web.Models;
using MISA.DL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MISA.BL
{
    public class CustomerGroupBL:BaseBL<CustomerGroup> , ICustomerGroupBL
    {
        ICustomerGroupDL _customerGroupDL;
        IDbContext<CustomerGroup> _dbContext;
        public CustomerGroupBL(IDbContext<CustomerGroup> dbContext, ICustomerGroupDL customerGroupDL) : base(dbContext)
        {
            _customerGroupDL = customerGroupDL;
            _dbContext = dbContext;
        }

        /// <summary>
        /// Overrride hàm kiểm tra dữ liệu
        /// </summary>
        /// <param name="customerGroup">Nhóm khách hàng</param>
        /// <returns>ServiceResult</returns>
        protected override ServiceResult Validate(CustomerGroup customerGroup)
        {
            var serviceResult = new ServiceResult();
            //Kiểm tra trùng mã
            var props = typeof(CustomerGroup).GetProperties();
            var checkName = _customerGroupDL.CheckDuplicate(props[0].Name, customerGroup.CustomerGroupName);
            if (checkName.Count() > 0)
            {
                var msg = new
                {
                    devMsg = new { fieldName = props[0].Name, Messenger = Resources.ErroService_DuplicateCustomerGroupName },
                    userMsg = Resources.ErroService_DuplicateCustomerGroupName,
                };
                serviceResult.MISACode = MISACode.NotValid;
                serviceResult.Messenger = Resources.ErroService_DuplicateCustomerGroupName;
                serviceResult.Data = msg;
                return serviceResult;
            }
            serviceResult.MISACode = MISACode.IsValid;
            serviceResult.Messenger = Resources.SuccessService_IsVaid;
            serviceResult.Data = 1;
            return serviceResult;
        }
    }
}
