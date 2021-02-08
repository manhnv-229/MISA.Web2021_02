using MISA.ApplicationCore.Entity;
using MISA.ApplicationCore.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.ApplicationCore.interfaces.Customer
{
    public interface ICustomerGroupService
    {
        /// <summary>
        /// Thêm mới nhóm khách hàng
        /// </summary>
        /// <returns>Nhóm khách hàng thêm mới</returns>
        /// CreatedBy: BDHIEU (08/02/2021)
        ErrorMsg InsertCustomerGroup(CustomerGroup customerGroup);
    }
}
