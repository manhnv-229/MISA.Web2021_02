using Microsoft.AspNetCore.Mvc;
using MISA.ApplicationCore.Entity;
using MISA.ApplicationCore.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.ApplicationCore.interfaces
{
    public interface IEmployeeService
    {
        /// <summary>
        /// Thêm mới nhân viên
        /// </summary>
        /// <param name="enployee"></param>
        /// <returns>Số bản ghi thêm thành công</returns>
        /// CreatedBy: BDHIEU (01/02/2021)
        ServiceResult AddEmployee(Employee enployee);
        /// <summary>
        /// Cập nhật thông tin nhân viên
        /// </summary>
        /// <param name="enployee"></param>
        /// <returns>Số bản ghi cập nhật thành công</returns>
        /// CreatedBy: BDHIEU (01/02/2021)
        int UpdateEmployee(Employee enployee);
        /// <summary>
        /// Xóa nhân viên
        /// </summary>
        /// <param name="employeeId"></param>
        /// <returns>Số bản ghi xóa thành công</returns>
        /// CreatedBy: BDHIEU (01/02/2021)
        int DeleteEmployee(Guid employeeId);
        /// <summary>
        /// Lấy nhân viên theo id
        /// </summary>
        /// <param name="employeeId"></param>
        /// <returns>Nhân viên có id được tìm</returns>
        /// CreatedBy: BDHIEU (01/02/2021)
        Employee GetEmployeeById(Guid employeeId);
        /// <summary>
        /// Lấy mã nhân viên lớn nhất
        /// </summary>
        /// <returns>Mã nhân viên lớn nhất</returns>
        /// CreatedBy: BDHIEU (01/02/2021)
        string GetMaxEmployeeCode();
        /// <summary>
        /// Lấy số lượng nhân viên trong database
        /// </summary>
        /// <returns>Số lượng nhân viên trong database</returns>
        /// CreatedBy: BDHIEU (01/02/2021)
        int GetNumberOfEmployee();
        /// <summary>
        /// Lấy danh sách nhân viên theo vị trí
        /// </summary>
        /// <param name="positionId"></param>
        /// <returns>Danh sách nhân viên theo vị trí</returns>
        /// CreatedBy: BDHIEU (01/02/2021)
        IEnumerable<EmployeeInfo> GetEmployeeByPosition(int positionId);
        /// <summary>
        /// Lấy danh sách nhân viên theo vị trí
        /// </summary>
        /// <param name="departmentId"></param>
        /// <returns>Danh sách nhân viên theo vị trí</returns>
        /// CreatedBy: BDHIEU (01/02/2021)
        IEnumerable<EmployeeInfo> GetEmployeeByDepartment(int departmentId);
        /// <summary>
        /// Lấy danh sách nhân viên theo từ khóa tìm kiếm
        /// </summary>
        /// <param name="searchText"></param>
        /// <returns>Lấy danh sách nhân viên theo từ khóa tìm kiếm</returns>
        /// CreatedBy: BDHIEU (03/02/2021)
        IEnumerable<EmployeeInfo> GetEmployeeBySearchText(string searchText);
        /// <summary>
        /// Lấy danh sách nhân viên theo vị trí và số lượng nhân viên
        /// </summary>
        /// <param name="positionStart"></param>
        /// <param name="offset"></param>
        /// <returns>Danh sách nhân viên theo vị trí và số lượng nhân viên</returns>
        /// CreatedBy: BDHIEU (04/02/2021)
        IEnumerable<EmployeeInfo> GetEmployeeByIndexAndOffset(int positionStart, int offset);
    }
}
