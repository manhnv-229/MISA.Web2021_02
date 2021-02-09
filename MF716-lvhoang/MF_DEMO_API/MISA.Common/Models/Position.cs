using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.Common.Models
{
    public class Position
    {
        public Guid PositionId { get; set; }
        public String PositionId_
        {
            get
            {
                return PositionId.ToString();
            }
        }
        public string PositionName { get; set; }
    }
}
