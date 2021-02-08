using System;
using System.Collections.Generic;
using System.Text;

namespace MisaCukCuk_Entity.Models
{
    public class Position
    {
        /// <summary>
        /// ID chức vụ
        /// CreateBy: MinhHq(08/02/2021)
        /// </summary>
        public Guid PositionId { get; set; }
        public string Id
        {
            get
            {
                return PositionId.ToString();
            }
            set
            {
            }
        }
        /// <summary>
        /// Tên chức vụ
        /// </summary>
        public string PositionName { get; set; }
        /// <summary>
        /// Miêu tả
        /// CreateBy: MinhHq(08/02/2021)
        /// </summary>
        public string Description { get; set; }
    }
}
