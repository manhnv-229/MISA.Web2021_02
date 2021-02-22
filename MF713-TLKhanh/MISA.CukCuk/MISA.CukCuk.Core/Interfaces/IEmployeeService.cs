using MISA.CukCuk.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.CukCuk.Core.Interfaces
{
     public interface IEmployeeService : IBaseService<Employee>
    {
        /// <summary>
        /// Lấy ra tất cả nhân viên kèm tên quyền , tình trạng công việc
        /// </summary>
        /// <returns>Danh sách nhân viên</returns>
        /// CreatedBy: TLKhanh (19/2/2021)
        ServiceResult GetEmployees();
        /// <summary>
        /// Lấy giá trị code lớn nhất trong hệ thống
        /// </summary>
        /// <returns></returns>
        /// CreatedBy: TLKhanh (19/2/2021)
        ServiceResult GetMaxCode();
        /// <summary>
        /// Lấy filter
        /// </summary>
        /// <param name="work_status"></param>
        /// <param name="gender"></param>
        /// <returns></returns>
        ServiceResult GetByWorkStatus(string workStatus = null);
    }
}
