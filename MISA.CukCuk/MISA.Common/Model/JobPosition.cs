using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Common.Model
{
    public class JobPosition
    {
        #region Constructor
        public JobPosition()
        {
            JobPositionId = Guid.NewGuid();
        }
        #endregion

        #region Property
        /// <summary>
        /// Khóa chính
        /// </summary>
        public Guid JobPositionId { get; set; }

        /// <summary>
        /// Tên vị trí
        /// </summary>
        public string JobPositionName { get; set; }

        /// <summary>
        /// Mô tả vị trí
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
