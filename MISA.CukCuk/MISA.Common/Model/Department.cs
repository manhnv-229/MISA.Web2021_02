using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Common.Model
{
    public class Department
    {
        #region Constructor
        public Department()
        {
            DepartmentId = Guid.NewGuid();
        }
        #endregion
        #region Property
        /// <summary>
        /// Khóa chính
        /// </summary>
        public Guid DepartmentId { get; set; }
        
        /// <summary>
        /// Tên phòng ban
        /// </summary>
        public string DepartmentName { get; set; }
        
        /// <summary>
        /// Mô tả phòng ban
        /// </summary>
        public string Description { get; set; }
        
        /// <summary>
        /// Ngày tạo bản ghi
        /// </summary>
        public DateTime? CreatedDate { get; set; }
        
        /// <summary>
        /// Người tạo bản ghi
        /// </summary>
        public string CreatedBy { get; set; }
        
        /// <summary>
        /// Ngày chỉnh sửa gần nhất
        /// </summary>
        public DateTime? ModifiedDate { get; set; }
        
        /// <summary>
        /// Người chỉnh sửa gần nhất
        /// </summary>
        public string ModifiedBy { get; set; }
        #endregion
    }
}
