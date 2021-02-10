using System;
using System.Collections.Generic;
using System.Text;
using MISA.Service.Entities;

namespace MISA.Service.Interfaces
{
    public interface IEmployeeReposity : IBaseReposity<Employee>
    {
        /// <summary>
        /// Lấy Mã Nhân viên lớn nhất trong db
        /// </summary>
        /// <returns>Trả vễ mã nhân viên lớn nhất tại thời điểm gọi hàm</returns>
        /// Created By : NHLong (07/02/2021)
        Employee GetLastestEmployeeCode();
    }
}