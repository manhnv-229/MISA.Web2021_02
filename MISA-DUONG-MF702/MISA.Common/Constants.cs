using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace MISA.Common
{
    public static class Constants
    {
        public class SortByData
        {
            public const string Name = "NAME";

            public const string Status = "STATUS";

            public const string CreateDate = "CREATEDATE";

            public const string UpdatedDate = "UPDATEDDATE";

            public const string Sentiment = "SENTIMENT";

            public const string OrderBy = "ORDERBY";
        }
        public class OrderByData
        {
            public const string Desc = "DESC";

            public const string Asc = "ASC";
        }
        public class Status
        {
            [Description("Active")]
            public const int Active = 1;

            [Description("In Active")]
            public const int InActive = 0;
        }
    }
}
