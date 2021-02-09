using System;
using System.Collections.Generic;
using System.Text;

namespace Misa.Common.Results
{
    public class PageResult<T>
    {
        /// <summary>
        /// Danh sách trả về
        /// </summary>
        public IEnumerable<T> Items { set; get; }

        /// <summary>
        /// Tổng số bản ghi
        /// </summary>
        public int TotalRecord { get; set; }
    }
}
