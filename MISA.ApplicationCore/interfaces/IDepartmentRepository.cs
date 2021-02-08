using MISA.ApplicationCore.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.ApplicationCore.interfaces
{
    public interface IDepartmentRepository
    {
        /// <summary>
        /// Lấy danh sách phòng ban
        /// </summary>
        /// <returns>Danh sách phòng ban</returns>
        /// CreatedBy: BDHIEU (01/02/2021)
        IEnumerable<EmployeeDepartment> GetDepartments();
        /// <summary>
        /// Lấy phòng ban theo id
        /// </summary>
        /// <param name="departmentId"></param>
        /// <returns>Một phòng ban</returns>
        /// CreatedBy: BDHIEU (01/02/2021)
        string GetDepartmentById(int departmentId);
    }
}
