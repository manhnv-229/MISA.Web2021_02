using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Common
{
    public class Office
    {
        /// <summary>
        /// Phòng Id
        /// </summary>
        public Guid? OfficeId { get; set; }
        /// <summary>
        /// Tên phòng
        /// </summary>
        public string OfficeName { get; set; }
        /// <summary>
        /// Miêu tả phòng
        /// </summary>
        public string Description { get; set; }
    }
}
