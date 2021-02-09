using MISA.Common;
using MISA.Common.Filters;
using MISA.DataLayer.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Service.CustomerGroup
{
    public interface ICustomerGroupService : IGenericRepository<MISA.Common.Models.CustomerGroup>
    {
        Task<IPagedList<MISA.Common.Models.CustomerGroup>> GetAll(GlobalParamFilter filters);
        Task<int> Insert(MISA.Common.Models.CustomerGroup model);
    }
}
