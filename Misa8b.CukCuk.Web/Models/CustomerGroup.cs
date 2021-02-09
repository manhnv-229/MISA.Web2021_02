using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Misa8b.CukCuk.Web.Models
{
    public class CustomerGroup
    {
        /// <summary>
        /// Mã nhóm khách hàng
        /// </summary>
        public Guid CustomerGroupId { get; set; }
        /// <summary>
        /// Tên nhóm khách hàng
        /// </summary>
        public string CustomerGroupName { get; set; }
        /// <summary>
        /// Ngày tạo
        /// </summary>
        public DateTime CreatedDate { get; set; }
        /// <summary>
        /// Người tạo
        /// </summary>
        public string CreatedBy { get; set; }
        /// <summary>
        /// Ngày chỉnh sửa gần nhất
        /// </summary>
        public DateTime ModifiedDate { get; set; }
        /// <summary>
        /// Chỉnh sửa bởi
        /// </summary>
        public string ModifiedBy { get; set; }
        /// <summary>
        /// Mô tả
        /// </summary>
        public string Description { get; set; }

    }
}
