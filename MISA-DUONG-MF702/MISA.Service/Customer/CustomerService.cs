using MISA.Common;
using MISA.Common.Filters;
using MISA.Common.Models;
using MISA.DataLayer;
using MISA.DataLayer.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Service.Customer
{
    public class CustomerService : GenericRepository<MISA.Common.Models.Customer>, ICustomerService
    {
        //public CustomerService(DbContext1 context) : base(context)
        //{

        //}
        public async Task<IPagedList<Common.Models.Customer>> GetAll(GlobalParamFilter filters)
        {
            var query=await _context.GetData<MISA.Common.Models.Customer>();
            query = this.SortData(query.AsQueryable(), filters.SortBy, filters.OrderBy);

            var results =  query.ToList();

            // Return to list with paging
            return new PagedList<Common.Models.Customer>(results, filters.PageIndex, filters.PageSize);
        }
        public async Task<int> Insert(MISA.Common.Models.Customer model)
        {
            int result=await _context.Insert<MISA.Common.Models.Customer>(model);
            return result;
        }
        private IQueryable<MISA.Common.Models.Customer> SortData(IQueryable<MISA.Common.Models.Customer> query, string sortBy, string orderBy)
        {
            if (!string.IsNullOrEmpty(sortBy))
            {
                switch (sortBy.ToUpper())
                {

                    default:
                        {
                            query = orderBy.Equals(Constants.OrderByData.Asc, StringComparison.OrdinalIgnoreCase) ?
                                query.OrderBy(c => c.CustomerId) : query.OrderByDescending(c => c.CustomerId);
                            break;
                        }
                }
            }
            else
            {
                query = orderBy.Equals(Constants.OrderByData.Asc, StringComparison.OrdinalIgnoreCase) ?
                    query.OrderBy(c => c.CustomerId) : query.OrderByDescending(c => c.CustomerId);
            }

            return query;
        }

    }
}
