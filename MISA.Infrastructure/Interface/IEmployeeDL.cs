using MISA.Common;
using MISA.Common.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Infrastructure.Interface
{
    /// <summary>
    /// 
    /// </summary>
    /// CreatedBy: PNVĐ (02/02/2021)
    public interface IEmployeeDL:IBaseDL<Employee>
    {
        
        /// <summary>
        /// Lấy dữ liệu có thuộc tính T và mã code lớn nhất trong data
        /// </summary>
        /// <typeparam name="T">thuộc tính chung</typeparam>
        /// <returns></returns>
        IEnumerable<T> GetEmployeeCodeM<T>();
        /// <summary>
        /// Lấy dữ liệu thuộc tính T cho 1 trang
        /// </summary>
        /// <typeparam name="T">thuộc tính chung</typeparam>
        /// <param name="offset">Vị trí bắt đầu lấy dữ liệu trong data</param>
        /// <param name="size">Số lượng cần lấy</param>
        /// <returns></returns>
        IEnumerable<T> GetDatapage<T>(int offset,int size);
        /// <summary>
        /// Đếm số lượng dữ liệu có thuộc tính T trong data 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        long GetCountdata<T>();
        /// <summary>
        /// lấy dữ liệu thuộc tính T theo khóa chính
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id">khóa chính</param>
        /// <returns></returns>
        IEnumerable<T> GetEmployeeById<T>(string id);

        /// <summary>
        /// Xóa nhân viên
        /// </summary>
        /// <param name="employee">thuộc tính nhân viên</param>
        /// <returns>Số bản ghi xóa thành công</returns>
        int DeleteEmployee(Employee employee);
        /// <summary>
        /// kiểm tra tồn tại của nhân viên theo khóa chính
        /// </summary>
        /// <param name="id">khóa chính</param>
        /// <returns>Trả về true nếu đúng</returns>
        bool CheckDuplicateEmployeeId(string id);
        /// <summary>
        /// Kiểm tra tồn tại nhân viên trùng mã nhân viên
        /// </summary>
        /// <param name="employee">thuộc tính nhân viên</param>
        /// <returns></returns>
        bool CheckDuplicateEmployeeCode(Employee employee);

        /// <summary>
        /// Kiểm tra trùng sđt khi thêm mới nhân viên
        /// </summary>
        /// <param name="employee">thuộc tính nhân viên</param>
        /// <returns></returns>
        bool CheckDuplicatePhone(Employee employee);
        /// <summary>
        /// kiểm tra trùng cmt khi thêm mới nhân viên
        /// </summary>
        /// <param name="employee">thuộc tính nhân viên</param>
        /// <returns></returns>
        bool CheckDuplicateIndentify(Employee employee);

        /// <summary>
        /// Kiểm tra trùng cmt khi sửa dữ liệu nhân viên
        /// </summary>
        /// <param name="employee">thuộc tính nhân viên</param>
        /// <returns></returns>
        bool CheckDuplicateIndentifyandId(Employee employee);
        /// <summary>
        /// Kiểm tra trùng sđt khi sửa dữ liệu nhân viên
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        bool CheckDuplicatePhoneandId(Employee employee);

        /// <summary>
        /// Kiểm tra những trường bắt buộc không được để trống
        /// </summary>
        /// <param name="employee">thuộc tính nhân viên</param>
        /// <returns></returns>
        int CheckEmpty(Employee employee);
    }
}
