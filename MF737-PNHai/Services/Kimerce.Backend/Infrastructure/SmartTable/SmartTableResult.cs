using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kimerce.Backend.Infrastructure.SmartTable
{
    public class SmartTableResult<T>
    {
        public IEnumerable<T> Items { get; set; }
        public double TotalRecord { get; set; }
        public int NumberOfPages { get; set; }
        public double From { get; set; }
        public double To { get; set; }
        public int LastPage { get; set; }
        

    }

}
