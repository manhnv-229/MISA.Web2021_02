using System;
using System.Collections.Generic;
using System.Text;
using MISA.ApplicationCore.Entity;

namespace MISA.ApplicationCore.interfaces.Customer
{
    public interface ICustomerRepository
    {
        #region Method
        /// <summary>
        /// Lấy danh sách khách hàng
        /// </summary>
        /// <returns>Danh sách khách hàng</returns>
        /// CreatedBy: BDHIEU (07/02/2021)
        IEnumerable<Customers> GetCustomers();
        #endregion
    }
}
