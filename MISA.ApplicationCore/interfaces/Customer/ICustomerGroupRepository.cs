using MISA.ApplicationCore.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.ApplicationCore.interfaces.Customer
{
    public interface ICustomerGroupRepository
    {
        /// <summary>
        /// Lấy danh sách nhóm khách hàng
        /// </summary>
        /// <returns>Danh sách nhóm khách hàng</returns>
        /// CreatedBy: BDHIEU (07/02/2021)
        IEnumerable<CustomerGroup> GetCustomerGroups();

        /// <summary>
        /// Thêm mới nhóm khách hàng
        /// </summary>
        /// <param name="customerGroup">Dữ liệu thêm </param>
        /// <returns>Số bản ghi thêm thành công</returns>
        /// CreatedBy: BDHIEU (08/02/2021)
        int InsertCustomerGroup(CustomerGroup customerGroup);
    }
}
