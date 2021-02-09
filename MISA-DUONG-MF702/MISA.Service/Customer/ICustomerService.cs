using MISA.Common;
using MISA.Common.Filters;
using MISA.DataLayer.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Service.Customer
{
    public interface ICustomerService : IGenericRepository<MISA.Common.Models.Customer>
    {
        Task<IPagedList<MISA.Common.Models.Customer>> GetAll(GlobalParamFilter filters);
        Task<int> Insert(MISA.Common.Models.Customer model);
    }
}
