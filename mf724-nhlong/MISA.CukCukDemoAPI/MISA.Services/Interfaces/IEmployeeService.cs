using System;
using System.Collections.Generic;
using System.Text;
using MISA.Service.Entities;

namespace MISA.Service.Interfaces
{
    public interface IEmployeeServices : IBaseService<Employee>
    {   
        /// <summary>
        /// Service thực hiện lấy dữ liệu để phân trang
        /// </summary>
        /// <param name="limit">Số bản ghi/trang</param>
        /// <param name="offset">Số thứ tự của trang</param>
        /// <returns> Kết quả Service ( Success, Data - Danh sách nhân viên theo trang)</returns>
        /// Created By : NHLong (07/02/2021)
        ServiceResult GetEmployeePaging(int limit,int offset);

        /// <summary>
        /// Serviec thực hiện lấy dữ liệu theo phòng ban
        /// </summary>
        /// <param name="departmentID">ID cua phòng ban</param>
        /// <returns>Kết quả Service( Success, Data- Danh sách nhân viên theo phòng ban)</returns>
        /// Created By : NHLong (07/02/2021)
        ServiceResult GetEmployeesByDepartment(Guid departmentID);

        /// <summary>
        ///  Serviec thực hiện lấy dữ liệu theo vị trí
        /// </summary>
        /// <param name="JobPosition">Mã Vị trí của nhân viên</param>
        /// <returns>Kêt quả service (success, data- danh sách nhân viên)</returns>
        /// Created By : NHLong(07/02/2021)
        ServiceResult GetEmployeesByPosition(int JobPosition);
        /// <summary>
        /// Service thực hiện lấy mã nhân viên lớn nhất trong db
        /// </summary>
        /// <returns>Trả về kết quả service ( success, data- mã nhân viên lớn nhất)</returns>
        ServiceResult GetLastestEmployeeCode();
    }
}