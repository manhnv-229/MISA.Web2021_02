using MISA.CukCuk.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.CukCuk.Core.Interfaces
{
    public interface IEmployeeRepository : IBaseRepository<Employee>
    {
        /// <summary>
        /// lấy ra nhân viên kèm tên quyền, trạng thái công việc
        /// </summary>
        /// <returns>Danh dách nhân viên</returns>
        IEnumerable<Employee> GetEmployees();
        /// <summary>
        /// Lấy về mã nhân viên lớn nhất trong hệ thống
        /// </summary>
        /// <returns></returns>
        Employee GetMaxCode();
    }
}
