using MISA.Common.Model;
using MISA.DL;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Service
{
    public class CustomerGroupService:BaseService<CustomerGroup>
    {
        /// <summary>
        /// Lấy danh sách nhóm khác hàng
        /// </summary>
        /// <returns>actionServiceResult</returns>
        /// CreatedBy: dvcuong (07/02/2021)
        //public ActionServiceResult GetCustomerGroup()
        //{
        //    var actionServiceResult = new ActionServiceResult();
        //    var dbContext = new DbContext<CustomerGroup>();
        //    actionServiceResult.data = dbContext.GetAll("select * from CustomerGroup");
        //    return actionServiceResult;
        //}
        public ActionServiceResult InsertCustomerGroup(CustomerGroup customerGroup)
        {
            var actionServiceResult = new ActionServiceResult();
            var dbContext = new DbContext<CustomerGroup>();
            actionServiceResult.data = dbContext.InsertObject(customerGroup); 
            return actionServiceResult;
        }
    }
}
