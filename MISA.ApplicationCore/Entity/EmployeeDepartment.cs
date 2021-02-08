using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.ApplicationCore.Entity
{
    /// <summary>
    /// Phòng ban nhân viên
    /// CreatedBy: BDHieu (01/02/2021)
    /// </summary>
    public class EmployeeDepartment
    {
        #region Property
        /// <summary>
        /// Khóa chính
        /// </summary>
        public int DepartmentId { get; set; }
        /// <summary>
        /// Tên phòng ban
        /// </summary>
        public string DepartmentName { get; set; }
        #endregion

    }
}
