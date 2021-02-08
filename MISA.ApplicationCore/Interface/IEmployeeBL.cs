using MISA.Common;
using MISA.Common.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.ApplicationCore.Interface
{
    /// <summary>
    /// 
    /// </summary>
    /// CreatedBy: PNVĐ (02/02/2021)
    public interface IEmployeeBL:IBaseBL<Employee>
    {
        /// <summary>
        /// Lấy dữ liệu nhân viên có mã nhân viên lớn nhất
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        IEnumerable<T> GetEmployeeCodeM<T>();
        /// <summary>
        /// Lấy dữ liệu nhân viên trong 1 trang
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="offset">Vị trí bắt đầu lấy trong database</param>
        /// <param name="size">Số lượng cần lấy</param>
        /// <returns></returns>
        IEnumerable<T> GetDataPage<T>(int offset, int size);
        /// <summary>
        /// Lấy số lượng dữ liệu thuộc tính T có trong data
        /// </summary>
        /// <typeparam name="T">Thuộc tính chung</typeparam>
        /// <returns></returns>
        long GetCountData<T>();
        /// <summary>
        /// Lấy dữ liệu nhân viên theo khóa chính
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id">Khóa chính</param>
        /// <returns></returns>
        IEnumerable<T> GetDataById<T>(string id);
        /// <summary>
        /// thêm mới nhân viên
        /// </summary>
        /// <param name="employee">thuộc tính nhân viên</param>
        /// <returns></returns>
        ServiceResult InsertEmployee(Employee employee);
        /// <summary>
        /// Cập nhật dữ liệu nhân viên
        /// </summary>
        /// <param name="employee">thuộc tính nhân viên</param>
        /// <returns></returns>
        ServiceResult UpdateEmployee(Employee employee);
        /// <summary>
        /// Xóa nhân viên 
        /// </summary>
        /// <param name="employee">thuộc tính nhân viên</param>
        /// <returns></returns>
        int DeleteEmployee(Employee employee);
        /// <summary>
        /// Kiểm tra properties không được trùng khi thêm mới dữ liệu
        /// </summary>
        /// <param name="employee">Thuộc tính nhân viên</param>
        /// <returns>Trả về error message nếu không có lỗi trả về null</returns>        
        ServiceResult CheckDuplicateInsert(Employee employee);
        /// <summary>
        /// Kiểm tra properties bắt buộc nhập có để trống khống
        /// </summary>
        /// <param name="employee">thuộc tính nhân viên</param>
        /// <returns>Trả về error message nếu không có lỗi trả về null</returns>
        ServiceResult CheckEmpty(Employee employee);
        /// <summary>
        /// Kiểm tra properties không được phép trùng khi cập nhật dữ liệu
        /// </summary>
        /// <param name="employee">thuộc tính nhân viên</param>
        /// <returns>Trả về error message nếu không có lỗi trả về null</returns>
        ServiceResult CheckDuplicateUpDate(Employee employee);
    }
}
