using MISA.Common.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Service.Interface
{
    /// <summary>
    /// Interface CustomerGroupService
    /// </summary>
    /// CreatedBy Vtthien( 08/02/21)
    public interface ICustomerGroupService: IBaseService<CustomerGroup>
    {
        ServiceResult InsertCustomerGroup(CustomerGroup customerGroup);

        ServiceResult UpdateCustomerGroup(Guid id, CustomerGroup customerGroup);
    }
}
