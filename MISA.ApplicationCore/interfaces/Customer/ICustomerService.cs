using MISA.ApplicationCore.Entity;
using MISA.ApplicationCore.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.ApplicationCore.interfaces.Customer
{
    public interface ICustomerService
    {
        #region Method
        /// <summary>
        /// Lấy danh sách khách hàng
        /// </summary>
        /// <returns>Danh sách khách hàng</returns>
        /// CreatedBy: BDHIEU (07/02/2021)
        ServiceResult GetCustomers();
        #endregion
    }
}
