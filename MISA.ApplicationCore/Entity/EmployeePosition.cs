using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.ApplicationCore.Entity
{
    /// <summary>
    /// Vị trí nhân viên
    /// CreatedBy: BDHieu (01/02/2021)
    /// </summary>
    public class EmployeePosition
    {
        #region Property
        /// <summary>
        /// Khóa chính
        /// </summary>
        public int PositionId { get; set; }
        /// <summary>
        /// Tên vị trí
        /// </summary>
        public string PositionName { get; set; }
        #endregion
    }
}
