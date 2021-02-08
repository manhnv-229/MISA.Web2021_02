using System;
using System.Linq;

namespace Kimerce.Backend.Infrastructure.SmartTable
{
    public static class SmartTableExtension
    {
        public static SmartTableResult<TResult> ToSmartTableResult<TModel, TResult>(this IQueryable<TModel> query, SmartTableParam param, Func<TModel, TResult> selector)
        {
            if (param.Pagination.Number <= 0)
            {
                param.Pagination.Number = 1;
            }
            if (param.Pagination.PageSize <= 0)
            {
                param.Pagination.PageSize = 15;
            }
            var totalRecord = 0;
            try
            {
                totalRecord = query.Count();
            }
            catch (Exception exception)
            {
                var b = "bug";
                throw;
            }

//            query = !string.IsNullOrWhiteSpace(param.Sort.Predicate) ? query.OrderByName(param.Sort.Predicate, param.Sort.Reverse) : query.OrderByName("Id", false);

            var items = query
                .Skip(param.Pagination.Start)
                .Take(param.Pagination.PageSize)
                .Select(selector).ToList();

            return new SmartTableResult<TResult>
            {
                Items = items,
                TotalRecord = totalRecord,
                NumberOfPages = (int)Math.Ceiling((double)totalRecord / param.Pagination.Number)
            };
        }

        public static SmartTableResult<TResult> ToSmartTableResult2<TModel, TResult>(this IQueryable<TModel> query, SmartTableParam param, Func<TModel, TResult> selector)
        {
            if (param.Pagination.Number <= 0)
            {
                param.Pagination.Number = 1;
            }
            if (param.Pagination.PageSize <= 0)
            {
                param.Pagination.PageSize = 10;
            }
            var totalRecord = 0;
            try
            {
                totalRecord = query.Count();
            }
            catch (Exception)
            {
                //var b = "bug";
                throw;
            }

            query = !string.IsNullOrWhiteSpace(param.Sort.Predicate) ? query.OrderByName(param.Sort.Predicate, param.Sort.Reverse) : query.OrderByName("Id", true);

            var items = query
                .Skip(param.Pagination.Start)
                .Take(param.Pagination.PageSize)
                .Select(selector).ToList();

            return new SmartTableResult<TResult>
            {
                Items = items,
                TotalRecord = totalRecord,
                NumberOfPages = (int)Math.Ceiling((double)totalRecord / param.Pagination.Number)
            };
        }
    }
}
