using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.CukCuk.Core.Entities
{
    public class WorkStatus
    {
        /// <summary>
        /// Khóa chính
        /// </summary>
        public Guid WorkStatusId { get; set; }
        /// <summary>
        /// tình trạng công việc
        /// </summary>
        public string WorkStatusName { get; set; }
    }
}
