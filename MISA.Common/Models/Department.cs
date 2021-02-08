using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.Common.Models
{
    public class Department
    {
        #region Declare
        /// <summary>
        /// Id phòng ban
        /// </summary>
        public Guid EmployeeDepartmentId { get; set; }
        /// <summary>
        /// Tên phòng ban
        /// </summary>
        public String EmployeeDepartmentName { get; set; }
        /// <summary>
        /// Ngày tạo
        /// </summary>
        public DateTime? CreateDate { get; set; }
        /// <summary>
        /// Người tạo
        /// </summary>
        public string CreatedBy { get; set; }
        /// <summary>
        /// Ngày chỉnh sửa gần nhất
        /// </summary>
        public DateTime? ModifiedDate { get; set; }
        /// <summary>
        /// Người sửa
        /// </summary>
        public string ModifiedBy { get; set; }
        #endregion
    }
}
