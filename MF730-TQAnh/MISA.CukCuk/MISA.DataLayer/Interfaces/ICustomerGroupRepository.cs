using MISA.Common.Model;
using System;
using System.Collections.Generic;
using System.Text;


namespace MISA.DataLayer.Interfaces
{
    /// <summary>
    /// interface cho kho lưu trữ nhóm khách hàng 
    /// </summary>
    ///   CreatedBy: TQAnh (08/02/2021)
    public interface ICustomerGroupRepository : IDbContext<CustomerGroup>
    {
    }
}
