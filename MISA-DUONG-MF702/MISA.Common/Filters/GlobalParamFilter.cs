using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Common.Filters
{
    public class GlobalParamFilter
    {
        public GlobalParamFilter()
        {
            PageIndex = 1;
            PageSize = 10;
            SortBy = "ID";
            OrderBy = "DESC";
        }

        public string SortBy { get; set; }
        public string OrderBy { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }

        public int? Status { get; set; }
        public string StatusValue { get; set; }
        public string ParentId { get; set; }

        public string Keyword { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? UserId { get; set; }
        public string Type { get; set; }
        public int GroupId { get; set; }

        public string Language { get; set; }
    }
}
