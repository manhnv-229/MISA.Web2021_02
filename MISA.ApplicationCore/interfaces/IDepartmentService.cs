using MISA.ApplicationCore.Entity;
using MISA.ApplicationCore.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.ApplicationCore.interfaces
{
    public interface IDepartmentService
    {
        /// <summary>
        /// Lấy danh sách phòng ban
        /// </summary>
        /// <returns>Danh sách phòng ban</returns>
        /// CreatedBy: BDHIEU (01/02/2021)
        ServiceResult GetDepartments();
        /// <summary>
        /// Lấy phòng ban theo id
        /// </summary>
        /// <param name="departmentId"></param>
        /// <returns>Một phòng ban</returns>
        /// CreatedBy: BDHIEU (01/02/2021)
        string GetDepartmentById(int departmentId);
    }
}
