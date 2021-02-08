using System;
using System.Collections.Generic;
using System.Text;

namespace MisaCukCuk_Entity.Models
{
    public class Department
    {
        /// <summary>
        /// Id phòng ban
        /// CreateBy: MinhHq(08/02/2021)
        /// </summary>
        public Guid DepartmentId { get; set; }
        public string Id
        {
            get
            {
                return DepartmentId.ToString();
            }
        }
        /// <summary>
        /// Tên phòng ban
        /// CreateBy: MinhHq(08/02/2021)
        /// </summary>
        public string DepartmentName { get; set; }
        /// <summary>
        /// Miêu tả
        /// CreateBy: MinhHq(08/02/2021)
        /// </summary>
        public string Description { get; set; }
    }
}
