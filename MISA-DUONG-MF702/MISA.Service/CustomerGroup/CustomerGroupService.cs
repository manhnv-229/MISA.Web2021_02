
using MISA.Common;
using MISA.Common.Filters;
using MISA.DataLayer.Base;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.Service.CustomerGroup
{
    public class CustomerGroupService : GenericRepository<MISA.Common.Models.CustomerGroup>, ICustomerGroupService
    {
        //public CustomerService(DbContext1 context) : base(context)
        //{

        //}
        public async Task<IPagedList<Common.Models.CustomerGroup>> GetAll(GlobalParamFilter filters)
        {
            var query = await _context.GetData<MISA.Common.Models.CustomerGroup>();
            query = this.SortData(query.AsQueryable(), filters.SortBy, filters.OrderBy);

            var results = query.ToList();

            // Return to list with paging
            return new PagedList<Common.Models.CustomerGroup>(results, filters.PageIndex, filters.PageSize);
        }
        public async Task<int> Insert(MISA.Common.Models.CustomerGroup model)
        {
            int result = await _context.Insert<MISA.Common.Models.CustomerGroup>(model);
            return result;
        }
        private IQueryable<MISA.Common.Models.CustomerGroup> SortData(IQueryable<MISA.Common.Models.CustomerGroup> query, string sortBy, string orderBy)
        {
            if (!string.IsNullOrEmpty(sortBy))
            {
                switch (sortBy.ToUpper())
                {
                    default:
                        {
                            query = orderBy.Equals(Constants.OrderByData.Asc, StringComparison.OrdinalIgnoreCase) ?
                                query.OrderBy(c => c.CustomerGroupId) : query.OrderByDescending(c => c.CustomerGroupId);
                            break;
                        }
                }
            }
            else
            {
                query = orderBy.Equals(Constants.OrderByData.Asc, StringComparison.OrdinalIgnoreCase) ?
                    query.OrderBy(c => c.CustomerGroupId) : query.OrderByDescending(c => c.CustomerGroupId);
            }

            return query;
        }
    }
}