using System;
using System.Collections.Generic;
using System.Text;
using MISA.Common.Model;
using MISA.DataLayer;

namespace MISA.Service
{
    public class CustomerGroupService
    {
        /// <summary>
        /// Lấy toàn bộ danh sách nhóm khách hàng 
        /// </summary>
        /// <returns>ServiceResult</returns>
        /// CreatedBy: Đào Đức Thao (04/02/2021)
        public ServiceResult GetCustomerGroups()
        {
            var serviceResult = new ServiceResult();
            var dbContext = new DbContext<CustomerGroup>();
            serviceResult.Data = dbContext.GetAll();
            //serviceResult.Data = dbContext.GetData<CustomerGroup>("SELECT * FROM CustomerGroup WHERE CustomerGroupName LIKE CONCAT('%',@CustomerGroupName,'%')", new { CustomerGroupName = "VIP", PhoneNumber = "09" });
            return serviceResult;
        }
    }
}
