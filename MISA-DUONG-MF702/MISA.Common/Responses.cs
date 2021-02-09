using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace MISA.Common
{
    public class PagedResponse<TModel> : IPagedResponse<TModel>
    {
        public string Message { get; set; }

        public bool Success { get; set; }

        public IEnumerable<TModel> Data { get; set; }

        public int PageSize { get; set; }

        public int PageIndex { get; set; }

        public int TotalCount { get; set; }

        public int TotalPages { get; set; }
    }
    public interface IPagedResponse<TModel> : IListResponse<TModel>
    {
        int TotalCount { get; set; }

        int TotalPages { get; }
    }
    public interface IListResponse<TModel> : IResponse
    {
        IEnumerable<TModel> Data { get; set; }
    }
    public interface IResponse
    {
        string Message { get; set; }

        /// <summary>
        /// 1 : success
        /// 0 : false
        /// </summary>
        bool Success { get; set; }
    }
    public static class ResponseExtensions
    {
        public static IActionResult ToHttpResponse<TModel>(this IListResponse<TModel> response)
        {
            var status = HttpStatusCode.OK;

            if (!response.Success)
                status = HttpStatusCode.InternalServerError;
            else if (response.Data == null)
                status = HttpStatusCode.NoContent;

            return new ObjectResult(response)
            {
                StatusCode = (int)status
            };
        }
   
        public static IActionResult ToHttpResponse(this IResponse response)
            => new ObjectResult(response)
            {
                StatusCode = (int)(!response.Success ? HttpStatusCode.InternalServerError : HttpStatusCode.OK)
            };

        public static IActionResult ToHttpResponse<TModel>(this ISingleResponse<TModel> response)
        {
            var status = HttpStatusCode.OK;

            if (!response.Success)
                status = HttpStatusCode.InternalServerError;
            else if (response.Data == null)
                status = HttpStatusCode.NotFound;

            return new ObjectResult(response)
            {
                StatusCode = (int)status
            };
        }
        public interface ISingleResponse<TModel> : IResponse
        {
            TModel Data { get; set; }
        }
        public static IActionResult ToHttpCreatedResponse<TModel>(this ISingleResponse<TModel> response)
        {
            var status = HttpStatusCode.Created;

            if (!response.Success)
                status = HttpStatusCode.InternalServerError;
            else if (response.Data == null)
                status = HttpStatusCode.NotFound;

            return new ObjectResult(response)
            {
                StatusCode = (int)status
            };
        }
        public class Response : IResponse
        {
            public string Message { get; set; }

            public bool Success { get; set; }
        }

    }
}
