using System;
using System.Collections.Generic;
using System.Text;

namespace MisaCukCuk_Entity.Models
{
    public class CustomerGroup
    {
        /// <summary>
        /// Id nhóm khách hàng
        /// CreateBy: MinhHq(08/02/2021)
        /// </summary>
        public Guid CustomerGroupId { get; set; }
        public string Id
        {
            get
            {
                return CustomerGroupId.ToString();
            }
            set
            {

            }
        }
        /// <summary>
        /// Tên nhóm khách hàng
        /// CreateBy: MinhHq(08/02/2021)
        /// </summary>
        public string CustomerGroupName { get; set; }
        /// <summary>
        /// Miêu tả
        /// CreateBy: MinhHq(08/02/2021)
        /// </summary>
        public string Description { get; set; }
    }
}
