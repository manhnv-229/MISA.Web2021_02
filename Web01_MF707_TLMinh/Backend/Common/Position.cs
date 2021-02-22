using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Common
{
    public class Position
    {
        /// <summary>
        /// Vị trí Id
        /// </summary>
        public Guid? PositionId { get; set; }
        /// <summary>
        /// Tên vị trí
        /// </summary>
        public string PositionName { get; set; }
        /// <summary>
        /// Miêu tả vị trí
        /// </summary>
        public string Description { get; set; }
    }
}
