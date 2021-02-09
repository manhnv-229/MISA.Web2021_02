using System;
using System.Collections.Generic;
using System.Text;

namespace Misa.Common.Requests
{
    public class PageRequestBase
    {
        /// <summary>
        /// Trang số
        /// </summary>
        public int PageIndex { set; get; }

        /// <summary>
        /// số bản ghi/trang
        /// </summary>
        public int PageSize { set; get; }

        public PageRequestBase(int pageIndex = 1, int pageSize = 10)
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
        }
    }
}
